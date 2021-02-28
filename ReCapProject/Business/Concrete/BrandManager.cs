using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _iBrandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _iBrandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            _iBrandDal.Add(brand);
        }

        public void Delete(Brand brand)
        {
            _iBrandDal.Remove(brand);
        }

        public List<Brand> GetAll()
        {
            return _iBrandDal.GetAll();
        }

        public Brand GetBrandById(int id)
        {
            return _iBrandDal.Get(b => b.Id == id);
        }

        public void Update(Brand brand)
        {
            _iBrandDal.Update(brand);
        }
    }
}
