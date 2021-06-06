using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            ValidationTool.Validate(new UserValidator(), user);
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(int id)
        {
            var deletedUser = _userDal.Get(u => u.Id == id);
            _userDal.Delete(deletedUser);
            return new SuccessResult(Messages.DeletedUser);
        }

        public IDataResult<List<User>> GetAll()
        {
          return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }
       
        public IDataResult<User> GetById(int carId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == carId));
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            ValidationTool.Validate(new UserValidator(), user);
            _userDal.Update(user);
            return new SuccessResult(Messages.UpdatedUSer);
        }
    }
}
