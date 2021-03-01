using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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
        public IResult Add(Color color)
        {
            _iColorDal.Add(color);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        public IResult Delete(Color color)
        {
            _iColorDal.Remove(color);
            return new SuccessResult(Messages.SuccessfullyDeleted);

        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_iColorDal.GetAll(),Messages.SuccessfullyListedObjects);
        }

        public IDataResult<Color> GetColorById(int id)
        {
            return new SuccessDataResult<Color>(_iColorDal.Get(c => c.Id == id),Messages.SuccessfullyGotObject);
        }

        public IResult Update(Color color)
        {
            _iColorDal.Update(color);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
    }
}
