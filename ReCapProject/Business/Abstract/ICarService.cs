using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetCarsByBrandId(int brandId);
        List<Car> GetCarsByColorId(int colorId);
        List<Car> GetAll();
        Car GetCarById(int id);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
