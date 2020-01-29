namespace Entities
{
    public interface IEntityBase<TKey>
    {
        TKey Id { get; }
    }
}