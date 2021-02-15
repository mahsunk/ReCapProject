using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstrack;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstrack;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.SuccessVoid);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId), Messages.SuccessVoid);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId), Messages.SuccessVoid);
        }

        public IDataResult<List<CarDetailsDto>> GetAllCarDetailsDtos()
        {
            if (DateTime.Now.Hour==12)
            {
                return new ErrorDataResult<List<CarDetailsDto>>(Messages.ErrorVoid);
            }
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetAllCarDetailsDtos(), Messages.SuccessVoid);
        }

        public IResult Add(Car car)
        {
            if (!(car.CarName.Length >= 2 && car.DailyPrice > 0))
            {
                return new ErrorResult(Messages.CarNameControl);
            }

             

            _carDal.Add(car);
            return new SuccessResult(Messages.SuccessVoid);


        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.SuccessVoid);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.SuccessVoid);
        }



    }
}
