using Business.Abstract;
using Business.Constants;
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
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage)
        {
            //carImage.Date = DateTime.Now.Date;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);

        }

        public IResult Delete(int id)
        {
            var deletedImage = _carImageDal.Get(c => c.CarId == id);
            _carImageDal.Delete(deletedImage);
            return new SuccessResult(Messages.DeletedCarImage);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(),Messages.CarImagesListed);
        }
        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.CarId == carImageId), Messages.CarImagesListed);
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }
    }
}
