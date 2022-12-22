namespace DataAccessInterface
{
    public interface IImporterRepository
    {
        Task CreateTable(string script);
    }
}
