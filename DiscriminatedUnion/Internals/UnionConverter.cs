using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace System
{
    internal sealed class UnionConverter : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            if (!typeToConvert.IsGenericType)
            {
                return false;
            }
            if (typeToConvert.GetGenericTypeDefinition() == typeof(UnionOf<,>)
                || typeToConvert.GetGenericTypeDefinition() == typeof(UnionOf<,,>)
                || typeToConvert.GetGenericTypeDefinition() == typeof(UnionOf<,,,>))
            {
                return true;
            }
            return false;
        }
        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            Type[] typeArguments = typeToConvert.GetGenericArguments();
            return new UnionEngineConverter(options, typeArguments);
        }
    }
}
