﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstrack
{
   public interface IUserDal:IEntityRepository<User>
    {
    }
}