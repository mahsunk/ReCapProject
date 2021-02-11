using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstrack
{
   public interface ICarDal
   {

       List<Car> GetAll();

       void Add(Car car);
       void Delete(Car car);
       void Update(Car car);

       List<Car> GetByID(int carID);

   }
}
