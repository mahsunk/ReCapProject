using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Result;
using Entities.Concrete;

namespace Business.Abstrack
{
  public  interface IBrandService
  {
     IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetById(int brandId);
      IResult Add(Brand brand);
      IResult Delete(Brand brand);
      IResult Update(Brand brand);

  }
}
