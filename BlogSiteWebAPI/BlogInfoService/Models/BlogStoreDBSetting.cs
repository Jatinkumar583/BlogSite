namespace BlogInfoService.Models
{
    public class BlogStoreDBSetting : IBlogStoreDBSetting
    {
        public string UserRegCollectionName { get; set; }=string.Empty;
        public string BlogDtlsCollectionName { get; set; }=string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
