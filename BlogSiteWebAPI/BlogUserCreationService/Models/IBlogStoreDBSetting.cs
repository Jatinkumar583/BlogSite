namespace BlogUserCreationService.Models
{
    public interface IBlogStoreDBSetting
    {
        string UserRegCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
