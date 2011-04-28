using Core.Model;
using Core.Repository;
using Core.Service;

namespace Service
{
    public class VendorService : CrudService<Vendor>, IVendorService
    {

        public VendorService(IRepo<Vendor> repo)
            : base(repo)
        {
        }

        #region IVendorService Members

        public void HasPic(int id)
        {
            repo.Get(id).HasPic = true;
            repo.Save();
        }

        #endregion
    }
}
