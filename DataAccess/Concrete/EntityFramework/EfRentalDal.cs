
using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, Context>, IRentalDal
    {
      

        public List<RentalDetailsDto> GetRentalDetails()
        {
            using (Context context = new Context())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join cst in context.Customers
                             on r.CustomerId equals cst.UserId
                             join u in context.Users
                             on cst.UserId equals u.Id
                             join b in context.Brands
                             on c.BrandId equals b.BrandId

                             select new RentalDetailsDto { Id = r.Id, BrandName = b.BrandName, Name = c.Name, CompanyName = cst.CompanyName, RentDate = r.RentDate, ReturnDate = r.ReturnDate, FirstName = u.FirstName, Lastname = u.LastName };
                return result.ToList();
            }
        }
    }
}
