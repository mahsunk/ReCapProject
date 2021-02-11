using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstrack;
using DataAccess.Abstrack;
using Entities.Concrete;

namespace Business.Concrete
{
   public class CarManager:ICarService
   {
       private ICarDal _carDal;

       public CarManager(ICarDal carDal)
       {
           _carDal = carDal;
       }

       public List<Car> GetAll()
        {
          return  _carDal.GetAll();
        }

       public void Add(Car car)
       {
           _carDal.Add(car);
       }

       public void Delete(Car car)
       {
           _carDal.Delete(car);
       }

       public void Update(Car car)
       {
         _carDal.Update(car);
       }

       public List<Car> GetByID(int carId)
       {
         return  _carDal.GetByID(carId);
       }

        
   }
}
