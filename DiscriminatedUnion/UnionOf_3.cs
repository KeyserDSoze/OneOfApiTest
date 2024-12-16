using System.Text.Json.Serialization;

namespace System
{
    [JsonConverter(typeof(UnionConverter))]
    public class UnionOf<T0, T1, T2> : UnionOf<T0, T1>
    {
        private Wrapper? _wrapper2;
        public T2? AsT2 => Index == 2 && _wrapper2?.Entity != null ? (T2)_wrapper2.Entity : default;
        private protected override IEnumerable<Wrapper?> GetWrappers()
        {
            foreach (var wrapper in base.GetWrappers())
                yield return wrapper;
            yield return _wrapper2;
        }
        private protected override void SetWrappers(object? value)
        {
            base.SetWrappers(value);
            if (value != null && value is T2 v2)
            {
                Index = 2;
                _wrapper1 = new(v2);
            }
        }
        public static implicit operator UnionOf<T0, T1, T2>(T0 entity)
        {
            return new UnionOf<T0, T1, T2> { _wrapper0 = new(entity) };
        }
        public static implicit operator UnionOf<T0, T1, T2>(T1 entity)
        {
            return new UnionOf<T0, T1, T2> { _wrapper1 = new(entity) };
        }
        public static implicit operator UnionOf<T0, T1, T2>(T2 entity)
        {
            return new UnionOf<T0, T1, T2> { _wrapper2 = new(entity) };
        }
    }
}
