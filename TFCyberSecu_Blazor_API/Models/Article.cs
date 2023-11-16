using System.ComponentModel.DataAnnotations;

namespace TFCyberSecu_Blazor_API.Models
{
    public class Article
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public int Prix { get; set; }

        public string Categorie { get; set; }

        public string Description { get; set; }
    }
}
