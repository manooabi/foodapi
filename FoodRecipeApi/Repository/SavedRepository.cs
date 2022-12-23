using FoodRecipeApi.Interface;
using FoodRecipeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodRecipeApi.Repository
{
    public class SavedRepository:ISaved
    {
        readonly DatabaseContext _dbContext = new();

        public SavedRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddSaved(Saved saved)
        {
            try
            {
                _dbContext.Saved.Add(saved);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public List<Saved> GetSavedDetails()
        {
            try
            {
                return _dbContext.Saved.ToList();
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<Saved>> Searchbyid(int id)
        {
            IQueryable<Saved> query = _dbContext.Saved;

           /* if (!string.IsNullOrEmpty(id))
            {
                query = query.Where(e => e.UserId.Contains(id)
                            );
            }*/
            if (!string.IsNullOrEmpty(id.ToString()))
            {
                query = query.Where(e => e.UserId.Equals(id)
                            );
            }


            return await query.ToListAsync();
        }
        public Saved GetSavedDetail(int id)
        {
            try
            {
                Saved? saved = _dbContext.Saved.Find(id);
                if (saved != null)
                {
                    return saved;
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
