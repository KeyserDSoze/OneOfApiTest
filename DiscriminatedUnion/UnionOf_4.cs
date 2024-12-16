using System.Text.Json.Serialization;

namespace System
{
    [JsonConverter(typeof(UnionConverter))]
    public class UnionOf<T0, T1, T2, T3> : UnionOf<T0, T1, T2>
    {
        private protected Wrapper? _wrapper3;
        public T3? AsT3 => Index == 3 && _wrapper3?.Entity != null ? (T3)_wrapper3.Entity : default;
        private protected override IEnumerable<Wrapper?> GetWrappers()
        {
            foreach (var wrapper in base.GetWrappers())
                yield return wrapper;
            yield return _wrapper3;
        }
        private protected override void SetWrappers(object? value)
        {
            base.SetWrappers(value);
            if (value != null && value is T3 v3)
            {
                Index = 3;
                _wrapper3 = new(v3);
            }
        }
        public static implicit operator UnionOf<T0, T1, T2, T3>(T0 entity)
        {
            return new UnionOf<T0, T1, T2, T3> { _wrapper0 = new(entity) };
        }
        public static implicit operator UnionOf<T0, T1, T2, T3>(T1 entity)
        {
            return new UnionOf<T0, T1, T2, T3> { _wrapper1 = new(entity) };
        }
        public static implicit operator UnionOf<T0, T1, T2, T3>(T2 entity)
        {
            return new UnionOf<T0, T1, T2, T3> { _wrapper2 = new(entity) };
        }
        public static implicit operator UnionOf<T0, T1, T2, T3>(T3 entity)
        {
            return new UnionOf<T0, T1, T2, T3> { _wrapper3 = new(entity) };
        }
    }
}
