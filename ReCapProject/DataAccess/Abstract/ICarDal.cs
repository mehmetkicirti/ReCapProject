﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ICarDal:IRepositoryBase<Car>
    {
        List<CarDetailDto> GetCarsDetails();
    }
}
