using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstrack;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfCarDal: EfEntityRepositoryBase<Car, RaCarContext>,ICarDal
    {
        public List<CarDetailsDto> GetAllCarDetailsDtos()
        {
            using (RaCarContext context=new RaCarContext())
            {
                var result = from c in context.Cars
                    join cl in context.Color on c.ColorId equals cl.ColorId
                    join b in context.Brand on c.BrandId equals b.BrandId
                    select new CarDetailsDto
                    {Id = c.Id,
                        CarName = c.CarName,
                        BrandName = b.BrandName,
                        ColorName = cl.ColorName,
                        DailyPrice = c.DailyPrice
                    };

                return result.ToList();
            }
        }
    }
}
