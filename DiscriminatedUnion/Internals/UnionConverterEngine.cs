using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace System
{
    internal sealed class UnionConverterEngine : JsonConverter<object>
    {
        private const string ValuePropertyName = "Value";
        private const string ReadMethodName = "Read";
        private const string WriteMethodName = "Write";
        private readonly JsonSerializerOptions _options;
        private readonly Type[] _types;
        private readonly Dictionary<Type, ReadHelper> _readers = [];
        private readonly Dictionary<Type, WriteHelper> _writers = [];
        private readonly Dictionary<Type, Dictionary<string, bool>> _properties = [];
        private readonly Type _unionOfType;
        private readonly PropertyInfo _value;
        public UnionConverterEngine(JsonSerializerOptions options, params Type[] types)
        {
            _options = options;
            _types = types;
            foreach (var type in types)
            {
                var converter = options.GetConverter(type);
                var readHelperType = typeof(ReadHelper<>).MakeGenericType(type);
                var jsonConvertType = typeof(JsonConverter<>).MakeGenericType(type!);
                var readMethod = jsonConvertType.GetMethods().First(x => x.Name == ReadMethodName);
                var writeMethod = jsonConvertType.GetMethods().First(x => x.Name == WriteMethodName);
                var reader = (Activator.CreateInstance(readHelperType, [converter, readMethod]) as ReadHelper)!;
                _readers.Add(type, reader);
                _writers.Add(type, new WriteHelper(converter, writeMethod));
                _properties.Add(type, []);
                AddProperties(null, type);
                void AddProperties(string? from, Type currentType)
                {
                    foreach (var property in currentType.GetProperties())
                    {
                        AddProperty(from, property);
                    }
                }
                void AddProperty(string? from, PropertyInfo propertyInfo)
                {
                    var name = $"{from}.{(propertyInfo.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? propertyInfo.Name)}";
                    _properties[type].Add(name, true);
                    if (propertyInfo.PropertyType.IsPrimitive())
                    {
                        return;
                    }
                    else if (propertyInfo.PropertyType.IsDictionary() || propertyInfo.PropertyType.IsEnumerable())
                    {
                        foreach (var genericType in propertyInfo.PropertyType.GetGenericArguments())
                        {
                            if (!genericType.IsPrimitive())
                                AddProperties(name, genericType);
                        }
                    }
                    else
                    {
                        AddProperties(name, propertyInfo.PropertyType);
                    }
                }
            }
            _unionOfType = GetUnionType(types.Length).MakeGenericType(_types);
            _value = _unionOfType.GetProperty(ValuePropertyName)!;

            static Type GetUnionType(int numberOfTypes)
            {
                return numberOfTypes switch
                {
                    2 => typeof(UnionOf<,>),
                    3 => typeof(UnionOf<,,>),
                    4 => typeof(UnionOf<,,,>),
                    _ => throw new NotSupportedException()
                };
            }
        }
        public override object Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null!;
            }
            var currentType = GetPossibleType(reader);
            if (currentType != null)
            {
                var instance = (dynamic)Activator.CreateInstance(_unionOfType)!;
                var readHelper = _readers[currentType];
                var result = readHelper.Read(ref reader, currentType, options);
                _value.SetValue(instance, result);
                return instance;
            }
            else
            {
                return null!;
            }
        }
        private Type? GetPossibleType(Utf8JsonReader reader)
        {
            if (reader.TokenType == JsonTokenType.String ||
                reader.TokenType == JsonTokenType.Number ||
                reader.TokenType == JsonTokenType.False ||
                reader.TokenType == JsonTokenType.True)
            {
                foreach (var type in _types.Where(x => x.IsPrimitive()))
                {
                    var isPrimitive =
                           (reader.TokenType == JsonTokenType.String && type == typeof(string))
                        || (reader.TokenType == JsonTokenType.Number && type.IsNumeric())
                        || ((reader.TokenType == JsonTokenType.True || reader.TokenType == JsonTokenType.False) && (type == typeof(bool) || type == typeof(bool?)));
                    if (isPrimitive)
                        return type;
                }
            }
            else
            {
                List<string> properties = [];
                var initialDepth = reader.CurrentDepth;
                string? prefix = null;
                string? name = null;
                while (reader.Read())
                {
                    if (initialDepth == reader.CurrentDepth && reader.TokenType == JsonTokenType.EndObject)
                        break;
                    else if (reader.TokenType == JsonTokenType.StartObject)
                    {
                        prefix = name;
                    }
                    else if (reader.TokenType == JsonTokenType.EndObject)
                    {
                        if (prefix != null)
                        {
                            prefix = string.Join('.', prefix.Split('.')[0..^1]);
                        }
                    }
                    else if (reader.TokenType == JsonTokenType.PropertyName)
                    {
                        name = $"{prefix}.{reader.GetString()!}";
                        properties.Add(name);
                    }
                }
                foreach (var type in _types.Where(x => !x.IsPrimitive()))
                {
                    var propertiesAsNameMap = _properties[type];
                    if (propertiesAsNameMap.Count >= properties.Count)
                    {
                        var correctType = true;
                        foreach (var property in properties)
                        {
                            if (!propertiesAsNameMap.ContainsKey(property))
                            {
                                correctType = false;
                                break;
                            }
                        }
                        if (correctType)
                            return type;
                    }
                }
            }
            return null;
        }
        public override void Write(
            Utf8JsonWriter writer,
            object value,
            JsonSerializerOptions options)
        {
            if (value != null)
            {
                var dynamicValue = ((dynamic)value).Value;
                if (dynamicValue != null)
                {
                    var currentType = (dynamicValue.GetType() as Type)!;
                    var writeHelper = _writers[currentType];
                    writeHelper.Write(writer, dynamicValue, options);
                }
            }
        }
    }
}
