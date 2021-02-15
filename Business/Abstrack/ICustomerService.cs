using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Result;
using Entities.Concrete;

namespace Business.Abstrack
{
  public  interface ICustomerService
  {

      IDataResult<List<Customer>> GetAll();
      IDataResult<Customer> GetById(int customerId);
      IResult Add(Customer customer);
      IResult Delete(Customer customer);
      IResult Update(Customer customer);

  }
}
