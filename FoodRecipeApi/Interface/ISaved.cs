using FoodRecipeApi.Models;

namespace FoodRecipeApi.Interface
{
    public interface ISaved
    {
        public List<Saved> GetSavedDetails();
        public Saved GetSavedDetail(int id);


        Task<IEnumerable<Saved>> Searchbyid(int id);
        public void AddSaved(Saved saved);

    }
}
