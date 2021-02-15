using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstrack;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _cars;

        public InMemoryCarDal( )
        {
            _cars = new List<Car>
            {

                new Car
                {
                    Id = 1,
                    BrandId = 1,
                    ColorId = 1,
                    ModelYear = 2020,
                    DailyPrice = 700,
                    Description = "Mercedes GLA Serisi 200 1.3 AMG"
                },
                new Car
                {
                    Id = 2,
                    BrandId = 1,
                    ColorId = 1,
                    ModelYear = 2020,
                    DailyPrice = 600,
                    Description = "Mercedes A Serisi A180 1.4 Style"
                },
                new Car
                {
                    Id = 3,
                    BrandId = 2,
                    ColorId = 1,
                    ModelYear = 2012,
                    DailyPrice = 500,
                    Description = "Honda Jazz 1.4 Joy"
                },
                new Car
                {
                    Id = 4,
                    BrandId = 2,
                    ColorId = 1,
                    ModelYear = 2021,
                    DailyPrice = 400,
                    Description = "Honda Civic 1.5 Executive Plus CVT"
                },
                new Car
                {
                    Id = 5,
                    BrandId = 3,
                    ColorId = 1,
                    ModelYear = 2021,
                    DailyPrice = 300,
                    Description = "Peugeot 2008 1.2 GT-Line AT"
                },
                new Car
                {
                    Id = 6,
                    BrandId = 4,
                    ColorId = 1,
                    ModelYear = 2020,
                    DailyPrice = 200,
                    Description = "Jeep Renegade 1.6 Multijet Limited AT"
                }

            };
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
           _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car result = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(result);
        }

        public void Update(Car car)
        {
           Car carUpdate=_cars.SingleOrDefault(c => c.Id == car.Id);
           carUpdate.BrandId = car.BrandId;
           carUpdate.ColorId = car.ColorId;
           carUpdate.DailyPrice = car.DailyPrice;
           carUpdate.Description = car.Description;
           carUpdate.ModelYear = car.ModelYear;
        }

        public List<CarDetailsDto> GetAllCarDetailsDtos()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByID(int carID)
        {
           return _cars.Where(c => c.Id == carID).ToList();
        }
    }
}
