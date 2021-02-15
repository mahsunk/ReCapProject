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
   public class CustomerManager:ICustomerService
   {
       private ICustomerDal _customerDal;

       public CustomerManager(ICustomerDal customerDal)
       {
           _customerDal = customerDal;
       }

       public IDataResult<List<Customer>> GetAll()
       {
           return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
       }

       public IDataResult<Customer> GetById(int customerId)
       {
           return new SuccessDataResult<Customer>(_customerDal.Get(p=>p.Id==customerId));
       }

       public IResult Add(Customer customer)
       {
        _customerDal.Add(customer);
        return  new SuccessResult(Messages.SuccessVoid);
       }

       public IResult Delete(Customer customer)
       {
           _customerDal.Delete(customer);
           return  new SuccessResult(Messages.SuccessVoid);
       }

       public IResult Update(Customer customer)
       {
           _customerDal.Update(customer);
           return new SuccessResult(Messages.SuccessVoid);
       }
   }
}
