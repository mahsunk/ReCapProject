using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstrack;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstrack;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p=>p.Id==rentalId));
        }

        public IResult Add(Rental rental)
        {
            var result = _rentalDal.Get(p => p.CarId == rental.CarId && p.ReturnDate == null);
            if (result!=null)
            {
                return new ErrorResult(Messages.RentalControl);
            }
            _rentalDal.Add(rental);
           return new SuccessResult(Messages.SuccessVoid);
        }

        public IResult Delete(Rental rental)
        {
            
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.SuccessVoid);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.SuccessVoid);
        }
    }
}
