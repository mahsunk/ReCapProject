﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Result;
using Entities.Concrete;

namespace Business.Abstrack
{
   public interface IColorService
   {
       IDataResult<List<Color>> GetAll();
      IDataResult< Color> GetById(int colorId);
       IResult Add(Color color);
       IResult Delete(Color color);
       IResult Update(Color color);
   }
}