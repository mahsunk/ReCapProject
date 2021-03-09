using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string createGuidFile = Guid.NewGuid().ToString() + ".jpeg";
            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images");

            Console.WriteLine();
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Add(new Brand { BrandName = "Fiat" });

            //BrandList();
            // ColorList();
            //CarList();

            // CarDtoList();

            //UserManager userManager=new UserManager(new EfUserDal());
            //User userlist=new User();
            //userlist.Email = "mahsumkarakoyunn@gmail.com";
            //userlist.FirstName = "Mahsun";
            //userlist.LastName= "Karakoyun";
            //userlist.Password= "123456";

            ////userManager.Add(userlist);
            //Console.WriteLine(userManager.GetById(2).Data.FirstName);
            // CustomerManager customerManager=new CustomerManager(new EfCustomersDal());
            //  Customer customer=new Customer();
            //  customer.CompanyName = "TruSan";
            //  customer.UserId = 2;
            //  var result = customerManager.Add(customer);
            //  if (result.Success)
            //  {
            //      Console.WriteLine(result.Message);
            //      Console.WriteLine(customerManager.GetById(2).Data.CompanyName);
            //  }
            //RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //Rental rental = new Rental();
            //rental.CarId = 2;
            //rental.CustomerId = 2;
            //rental.RentDate = DateTime.Now;
            //rental.ReturnDate = null;
            //var result = rentalManager.Add(rental);
            //if (result.Success)
            //{
            //    Console.WriteLine(result.Message);
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}

        }

        private static void CarDtoList()
        {
            CarManager dtoCarManager = new CarManager(new EfCarDal());

            var result = dtoCarManager.GetAllCarDetailsDtos();
            if (result.Success)
            {
                Console.WriteLine("\nAraç\tMarka\t Renk\tÜcret");
                Console.WriteLine("------------------------------------------------");
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + "\t" + car.BrandName + "\t" + car.ColorName + "\t " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void BrandList()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void ColorList()
        {
            ColorManager calorManager = new ColorManager(new EfColorDal());
            foreach (var color in calorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
                Console.WriteLine("----------------------");
            }
        }

        private static void CarList()
        {
            CarManager carManager = new CarManager(new EfCarDal());


            foreach (var cars in carManager.GetAll().Data)
            {
                Console.WriteLine(cars.Description);
            }
        }
    }
}
