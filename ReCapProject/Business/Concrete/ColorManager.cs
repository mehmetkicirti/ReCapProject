using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly IColorDal _iColorDal;
        public ColorManager(IColorDal colorDal)
        {
            _iColorDal = colorDal;
        }
        public void Add(Color color)
        {
            _iColorDal.Add(color);
        }

        public void Delete(Color color)
        {
            _iColorDal.Remove(color);
        }

        public List<Color> GetAll()
        {
            return _iColorDal.GetAll();
        }

        public Color GetColorById(int id)
        {
            return _iColorDal.Get(c => c.Id == id);
        }

        public void Update(Color color)
        {
            _iColorDal.Update(color);
        }
    }
}
