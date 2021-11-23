namespace BooksDb.Repositories
{
    public interface IEntityKey<T>
    {
        T Id { get; set; }
    }
}