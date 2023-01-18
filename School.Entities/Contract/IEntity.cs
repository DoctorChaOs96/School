namespace School.Entities.Contract
{
    public interface IEntity
    {
        int Id { get; set; }

        DateTime CreatedDate { get; set; }
    }
}
