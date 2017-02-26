namespace Services.DTO
{
    public class SuperTuple<T1>
    {
        public T1 ID { get; }
        public string Name { get; }

        internal SuperTuple(T1 id, string name)
        {
            ID = id;
            Name = name;
        }
    }

    public static class SuperTuple
    {
        public static SuperTuple<T1> Create<T1>(T1 id, string name)
        {
            return new SuperTuple<T1>(id, name);
        }
    }
}