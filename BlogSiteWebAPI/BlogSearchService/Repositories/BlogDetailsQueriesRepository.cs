﻿using BlogSearchService.Models;
using MongoDB.Driver;

namespace BlogSearchService.Repositories
{
    public class BlogDetailsQueriesRepository : IBlogDetailsQueriesRepository
    {
        private readonly IMongoCollection<BlogDetails> _blogDetails;

        public BlogDetailsQueriesRepository(IBlogStoreDBSetting settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _blogDetails = database.GetCollection<BlogDetails>(settings.BlogDtlsCollectionName);

        }
        public List<BlogDetails> GetAllBlogsByCategory(string category)
        {
            return _blogDetails.Find(blogs => blogs.Category == category).ToList();
        }
        public List<BlogDetails> GetAllBlogsByUserId(int userId)
        {
            return _blogDetails.Find(blogs => blogs.CreatedBy == userId).ToList();
        }
    }
}
