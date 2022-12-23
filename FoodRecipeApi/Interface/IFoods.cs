using FoodRecipeApi.Models;

namespace FoodRecipeApi.Interface
{
    public interface IFoods
    {
        public List<Foods> GetFoodDetails();
        public Foods GetFoodDetail(int id);
        public void AddFood(Foods food);

        Task<IEnumerable<Foods>> SearchbyCateogory(string name);

        Task<IEnumerable<Foods>> SearchbyType(string name);
        public void UpdateFood(Foods food);
        public Foods DeleteFood(int id);
    }
}
