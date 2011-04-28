using Core.Model;
using Core.Repository;
using Core.Service;

namespace Service
{
    public class MealService : CrudService<Meal>, IMealService
    {
        public MealService(IRepo<Meal> repo)
            : base(repo)
        {
        }

        public void HasPic(int id)
        {
            repo.Get(id).HasPic = true;
            repo.Save();
        }
    }
}