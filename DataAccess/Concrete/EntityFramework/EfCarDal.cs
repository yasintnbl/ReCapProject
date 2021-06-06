using Core.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, Context>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (Context context = new Context())
            {
                var result = from c in context.Cars
                             join clr in context.Colors                            
                             on c.ColorId equals clr.ColorId
                             join  b in context.Brands 
                             on c.BrandId equals b.BrandId

                             select new CarDetailsDto { Id = c.Id, ColorName = clr.ColorName, BrandName=b.BrandName, Name = c.Name, DailyPrice = c.DailyPrice, Description = c.Description, ModelYear = c.ModelYear};
               
                return result.ToList();
            }
        }
    }
}
