namespace DataAccess.Model
{
    public interface IEntity<T>
    {
        T ID { get; }
        string Name { get; }
    }
}