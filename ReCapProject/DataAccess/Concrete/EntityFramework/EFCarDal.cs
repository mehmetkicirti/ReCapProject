using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal : EntityRepositoryBase<Car, RentContext>, ICarDal
    {
        public List<CarDetailDto> GetCarsDetails()
        {
            using (var context = new RentContext())
            {
                var queryResult = from c in context.Cars
                                  join b in context.Brands
                                  on c.BrandId equals b.Id
                                  join co in context.Colors
                                  on c.ColorId equals co.Id
                                  select new CarDetailDto
                                  {
                                      CarId = c.Id,
                                      BrandName = b.Name,
                                      CarName = c.Description,
                                      ColorName = co.Name,
                                      DailyPrice = c.DailyPrice
                                  };
                return queryResult.ToList();
            }
        }
    }
}
