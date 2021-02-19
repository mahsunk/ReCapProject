using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Business.Abstrack;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstrack;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete
{
   public class BrandManager:IBrandService
   {
       private IBrandDal _brandDal;

       public BrandManager(IBrandDal brandDal)
       {
           _brandDal = brandDal;
       }


       public IDataResult<List<Brand>> GetAll()
       {
           return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.SuccessVoid); 
       }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == brandId), Messages.SuccessVoid);  
        }
        
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
          return  new SuccessResult(Messages.SuccessVoid); 
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return  new SuccessResult(Messages.SuccessVoid);
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.SuccessVoid);
        }
    }
}
