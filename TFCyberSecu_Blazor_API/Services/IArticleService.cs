using TFCyberSecu_Blazor_API.Models;

namespace TFCyberSecu_Blazor_API.Services
{
    public interface IArticleService
    {
        void Create(Article article);
        IEnumerable<Article> GetAll();
        Article GetById(int id);
    }
}