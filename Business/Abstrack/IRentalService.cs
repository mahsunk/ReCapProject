using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Result;
using Entities.Concrete;

namespace Business.Abstrack
{
   public interface IRentalService
   {
       IDataResult<List<Rental>> GetAll();
       IDataResult<Rental> GetById(int rentalId);
       IResult Add(Rental rental);
       IResult Delete(Rental rental);
       IResult Update(Rental rental);
   }
}
