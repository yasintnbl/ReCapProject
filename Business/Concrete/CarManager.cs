using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarNameExist(car.Name));
            if (result!=null)
            {
                return result;
            }
            ValidationTool.Validate(new CarValidator(), car);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(int id)
        {
            var deletedcar = _carDal.Get(p => p.Id == id);
            _carDal.Delete(deletedcar);
            return new SuccessResult(Messages.DeletedCar);
        }

        public IDataResult<List<Car>> GetAll()
        {      
            //İş Kodları
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(b => b.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carId));
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(), Messages.CarDetailsList);
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            ValidationTool.Validate(new CarValidator(), car);
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
        private IResult CheckIfCarNameExist(string carName)
        {
            var result = _carDal.GetAll(c => c.Name == carName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExsist);
            }
            return new SuccessResult();
        }
    
    }
}
