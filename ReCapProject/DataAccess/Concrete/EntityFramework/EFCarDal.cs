using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal:EntityRepositoryBase<Car,RentContext>,ICarDal
    {
    }
}
