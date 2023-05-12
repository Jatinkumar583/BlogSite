namespace BlogSearchService.Models
{
    public interface IBlogStoreDBSetting
    {
        string BlogDtlsCollectionName { get; set; }
        string UserRegCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
