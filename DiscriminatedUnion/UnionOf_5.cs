using System.Text.Json.Serialization;

namespace System
{
    [JsonConverter(typeof(UnionConverterFactory))]
    public class UnionOf<T0, T1, T2, T3, T4> : UnionOf<T0, T1, T2, T3>
    {
        private protected Wrapper? _wrapper4;
        public T4? AsT4 => TryGet<T4>(4, _wrapper4);
        private protected override IEnumerable<Wrapper?> GetWrappers()
        {
            foreach (var wrapper in base.GetWrappers())
                yield return wrapper;
            yield return _wrapper4;
        }
        private protected override void SetWrappers(object? value)
        {
            base.SetWrappers(value);
            if (value != null && value is T4 v4)
            {
                Index = 4;
                _wrapper4 = new(v4);
            }
        }
        public static implicit operator UnionOf<T0, T1, T2, T3, T4>(T0 entity)
        {
            return new() { _wrapper0 = new(entity) };
        }
        public static implicit operator UnionOf<T0, T1, T2, T3, T4>(T1 entity)
        {
            return new() { _wrapper1 = new(entity) };
        }
        public static implicit operator UnionOf<T0, T1, T2, T3, T4>(T2 entity)
        {
            return new() { _wrapper2 = new(entity) };
        }
        public static implicit operator UnionOf<T0, T1, T2, T3, T4>(T3 entity)
        {
            return new() { _wrapper4 = new(entity) };
        }
    }
}
