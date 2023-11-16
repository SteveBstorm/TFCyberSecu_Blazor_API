using Dapper;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using System.Data.SqlClient;
using TFCyberSecu_Blazor_API.Hubs;
using TFCyberSecu_Blazor_API.Models;

namespace TFCyberSecu_Blazor_API.Services
{
    public class ArticleService : IArticleService
    {
        private readonly SqlConnection _connection;
        private readonly ArticleHub _hub;

        public ArticleService(SqlConnection connection, ArticleHub hub)
        {
            _connection = connection;
            _hub = hub;
        }

        public IEnumerable<Article> GetAll()
        {
            string sql = "SELECT * FROM Article";
            return _connection.Query<Article>(sql);
        }

        public Article GetById(int id)
        {
            string sql = "SELECT * FROM Article WHERE Id = @id";
            return _connection.QueryFirst<Article>(sql, new { id });
        }

        public async Task Create(Article article)
        {
            string sql = "INSERT INTO Article (Nom, Prix, Description, Categorie) " +
                "VALUES (@Nom, @Prix, @Description, @Categorie)";
            _connection.Execute(sql, article);
            await _hub.NotifyNewArticle();
        }
    }
}
