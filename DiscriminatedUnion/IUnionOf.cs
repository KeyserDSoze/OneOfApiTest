namespace System
{
    public interface IUnionOf
    {
        object? Value { get; set; }
        int Index { get; }
    }
}
