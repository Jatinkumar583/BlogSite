﻿namespace BlogInfoService.Models
{
    public interface IBlogStoreDBSetting
    {
        string UserRegCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
