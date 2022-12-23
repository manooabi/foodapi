using System.ComponentModel.DataAnnotations;

namespace FoodRecipeApi.Models
{
    public class Saved
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int FoodId { get; set; }

        public string FoodName { get; set; }

        public string Photo { get; set; }
    }
}
