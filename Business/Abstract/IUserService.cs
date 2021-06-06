using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IUserService
    {
        IDataResult<List<User>> GetAll();       
        IDataResult<User> GetById(int carId);      
       // IDataResult<List<CarDetailsDto>> GetCarDetails();
        IResult Add(User user);
        IResult Delete(int id);
        IResult Update(User user);
    }
}
