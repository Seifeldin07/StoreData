namespace StoreData.Entities
{
    public class BaseEntity <T>
    {
        public T Id { get; set; }
        public DateTime CrratedAt { get; set; } = DateTime.Now;

    }
}
