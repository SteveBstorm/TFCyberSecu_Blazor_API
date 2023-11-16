using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TFCyberSecu_Blazor_API.Models;
using TFCyberSecu_Blazor_API.Services;

namespace TFCyberSecu_Blazor_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_articleService.GetAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody]Article a) { 
            _articleService.Create(a);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_articleService.GetById(id));
        }
    }
}
