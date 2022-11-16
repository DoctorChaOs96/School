namespace School.DataAccess.Contract
{
    public interface IEntity
    {
        int Id { get; set; }

        DateTime CreatedDate { get; set; }
    }
}
