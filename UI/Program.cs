using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMermory;
using Entities;
using System;

namespace UI
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //CarMethod();
            //CarBrandId();
            //CarColorId();
            //CarAdd();
            //GetCarDetails();
            //CarDelete();
            //CustomerList();
            //RentalDetails();

        }

        private static void RentalDetails()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetRentalDetails();
            if (result.Success == true)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.Id + "/" + item.Name + "/" + item.FirstName + "/" + item.Lastname + "/" + item.CompanyName + "/" + item.RentDate + "/" + item.ReturnDate);
                }
            }
        }

        private static void CustomerList()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetAll();
            if (result.Success == true)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.CompanyName);
                }
            }
        }

        private static void CarDelete()
        {
            CarManager carManager4 = new CarManager(new EfCarDal());
            var result = carManager4.Delete(6);
            if (result.Success==true)
            {
                Console.WriteLine(result.Success);
            }
            else
            {
                Console.WriteLine(result.Message);  
            }
           
        }

        private static void GetCarDetails()
        { 
            CarManager carManager3 = new CarManager(new EfCarDal());
            var result = carManager3.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var details in result.Data)
                {
                    Console.WriteLine(details.Name + "/" + details.ColorName + "/" + details.BrandName + "/" + details.ModelYear);
                    Console.WriteLine(result.Message);
                }
            }
            
        }

        private static void CarAdd()
        {
            Car car1 = new Car
            {
                Id = 8,
                BrandId = 3,
                ColorId = 2,
                Name = "Naci",
                ModelYear = 2011,
                DailyPrice = 22,
                Description = "Deneme6"
            };

            CarManager carManager2 = new CarManager(new EfCarDal());
            var result = carManager2.Add(car1);
            if (result.Success == true)
            {
                Console.WriteLine(result.Success);
                
                
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarColorId()
        {
            CarManager carManager1 = new CarManager(new EfCarDal());
            var result = carManager1.GetByColorId(2);
            if (result.Success == true)
            {
                foreach (var cars in result.Data)

                {
                    Console.WriteLine(cars.Description + " " + cars.DailyPrice);
                }
            }
        }

        private static void CarBrandId()
        {
            CarManager carManager1 = new CarManager(new EfCarDal());
            var result = carManager1.GetByBrandId(2);
            if (result.Success==true)
            {
                foreach (var cars in result.Data)

                {
                    Console.WriteLine(cars.Description + " " + cars.DailyPrice);
                }
            }
            
        }

        private static void CarMethod()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Name);                    
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
