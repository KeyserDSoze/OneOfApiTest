using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace System
{
    [JsonConverter(typeof(UnionConverterFactory))]
    public class UnionOf<T0, T1>
    {
        private protected Q? Check<Q>(int index, Wrapper? wrapper)
        {
            if (Index != index)
                return default;
            if (wrapper == null)
                return default;
            if (wrapper.Entity == null)
                return default;
            var entity = (Q)wrapper.Entity;
            return entity;
        }
        private protected Wrapper? _wrapper0;
        private protected Wrapper? _wrapper1;
        public int Index { get; private protected set; } = -1;
        public T0? AsT0 => Check<T0>(0, _wrapper0);
        public T1? AsT1 => Check<T1>(1, _wrapper1);
        private protected virtual IEnumerable<Wrapper?> GetWrappers()
        {
            yield return _wrapper0;
            yield return _wrapper1;
        }
        private protected virtual void SetWrappers(object? value)
        {
            foreach (var wrapper in GetWrappers())
            {
                if (wrapper != null)
                    wrapper.Entity = null;
            }
            Index = -1;
            if (value == null)
                return;
            if (value is T0 v0)
            {
                Index = 0;
                _wrapper0 = new(v0);
            }
            else if (value is T1 v1)
            {
                Index = 1;
                _wrapper1 = new(v1);
            }
        }
        public object? Value
        {
            get
            {
                foreach (var wrapper in GetWrappers())
                {
                    if (wrapper != null)
                        return wrapper.Entity;
                }
                return null;
            }
            set
            {
                SetWrappers(value);
            }
        }
        public static implicit operator UnionOf<T0, T1>(T0 entity)
        {
            return new UnionOf<T0, T1> { _wrapper0 = new(entity) };
        }
        public static implicit operator UnionOf<T0, T1>(T1 entity)
        {
            return new UnionOf<T0, T1> { _wrapper1 = new(entity) };
        }
        public override string? ToString()
        {
            return Value?.ToString();
        }
        public override bool Equals(object? obj)
        {
            if (obj == null && Value == null)
                return true;
            var dynamicValue = ((dynamic)obj!).Value;
            return Value?.Equals(dynamicValue) ?? false;
        }
        public override int GetHashCode()
            => RuntimeHelpers.GetHashCode(Value);
    }
}
