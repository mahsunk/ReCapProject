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
   public class UserManager:IUserService
   {
       private IUserDal _userDal;

       public UserManager(IUserDal userDal)
       {
           _userDal = userDal;
       }

       public IDataResult<List<User>> GetAll()
        {
            return  new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(p=>p.Id==userId));
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return  new SuccessResult(Messages.SuccessVoid);

        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return  new SuccessResult(Messages.SuccessVoid);

        }

        public IResult Update(User user)
        {
           _userDal.Update(user);
           return  new SuccessResult(Messages.SuccessVoid);
        }
    }
}
