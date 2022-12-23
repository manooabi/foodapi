using FoodRecipeApi.Interface;
using FoodRecipeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodRecipeApi.Repository
{
    public class FoodsRepository : IFoods
    {
        readonly DatabaseContext _dbContext = new();

        public FoodsRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Foods> GetFoodDetails()
        {
            try
            {
                return _dbContext.Foods.ToList();
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<Foods>> SearchbyCateogory(string name)
        {
            IQueryable<Foods> query = _dbContext.Foods;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.Categories.Contains(name)
                            );
            }



            return await query.ToListAsync();
        }
        public async Task<IEnumerable<Foods>> SearchbyType(string name)
        {
            IQueryable<Foods> query = _dbContext.Foods;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.Type.Contains(name)
                            );
            }



            return await query.ToListAsync();
        }

        public Foods GetFoodDetail(int id)
        {
            try
            {
                Foods? food = _dbContext.Foods.Find(id);
                if (food != null)
                {
                    return food;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void AddFood(Foods food)
        {
            try
            {
                _dbContext.Foods.Add(food);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateFood(Foods food)
        {
            try
            {
                _dbContext.Entry(food).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Foods DeleteFood(int id)
        {
            try
            {
                Foods? food = _dbContext.Foods.Find(id);

                if (food != null)
                {
                    _dbContext.Foods.Remove(food);
                    _dbContext.SaveChanges();
                    return food;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        
    }
}
