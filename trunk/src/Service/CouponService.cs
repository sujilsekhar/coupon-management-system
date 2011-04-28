using Core.Model;
using Core.Repository;
using Core.Service;

namespace Service
{
    public class CouponService : CrudService<Coupon>, ICouponService
    {
        public CouponService(IRepo<Coupon> repo)
            : base(repo)
        {
        }

        #region ICouponService Members

        public void Recommend(int id)
        {
            repo.Get(id).IsRecommended = true;
            repo.Save();
        }

        public void UnRecommend(int id)
        {
            repo.Get(id).IsRecommended = false;
            repo.Save();
        }

        public void HasPic(int id)
        {
            repo.Get(id).HasPic = true;
            repo.Save();
        }

        #endregion
    }
}
