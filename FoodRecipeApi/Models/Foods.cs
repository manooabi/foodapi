using System.ComponentModel.DataAnnotations;

namespace FoodRecipeApi.Models
{
    public class Foods
    {
        [Key]
        public int FoodId { get; set; }

        public string FoodName { get; set; }

        public string Categories { get; set; }

        public string Type { get; set; }

        public string Photo { get; set; }

        public string Description { get; set; }

        public string Indegredients { get; set; }
    }
}
