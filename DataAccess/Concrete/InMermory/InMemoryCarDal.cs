using DataAccess.Abstract;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMermory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car>()
            {
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear=1997,DailyPrice=15,Description="Bu Amerikan Tarz Bir Arabadır."},
                new Car{Id=2,BrandId=1,ColorId=2,ModelYear=2002,DailyPrice=150,Description="Bu İtalyan Tarz Bir Arabadır."},
                new Car{Id=3,BrandId=2,ColorId=3,ModelYear=2020,DailyPrice=35,Description="Bu Alman Tarz Bir Arabadır."},
                new Car{Id=4,BrandId=3,ColorId=4,ModelYear=2008,DailyPrice=5,Description="Bu Japon Tarz Bir Arabadır."},
            };
        }

        public void Add(Car entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _car.ToList();
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}
