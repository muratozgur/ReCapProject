//using Business.Abstract;
//using Business.Concrete;
//using Core.Utilities.Results;
//using DataAccess.Concrete.EntityFramework;
//using DataAccess.Concrete.InMemory;
//using Entities.Concrete;
//using Entities.DTOs;

//internal class Program
//{

//    public static void Main(string[] args)
//    {
//        //GetAllCars();
//        //GetCarsById(1);
//        //GetCarsWithBrandId();
//        //GetCarsByColorId();
//        //GetCarDetails();
//        //AddNewCar();

//        AddCustomer(new Customer() { UserId = 1, CompanyName = "Çağlayan A.Ş." });

//        static void AddCustomer(Customer customer)
//        {
//            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
//            customerManager.Add(customer);
//        }

//        static void GetCarsById(int id)
//        {
//            CarManager carManager = new CarManager(new EfCarDal());
//            IDataResult<Car> result = carManager.GetById(id);
//            if (result.Success)
//            {
//                Console.WriteLine(result);
//            }
//            else
//            {
//                Console.WriteLine(result.Message);
//            }
//        }

//        static void GetCarsByColorId()
//        {
//            CarManager carManager = new CarManager(new EfCarDal());
//            IDataResult<List<Car>> result = carManager.GetCarsByColorId(2);
//            if (result.Success)
//            {
//                foreach (var cars in result.Data)
//                {
//                    Console.WriteLine(cars.Id);
//                }
//            }
//            else
//            {
//                Console.WriteLine(result.Message);
//            }
//        }

//        static void GetAllCars()
//        {
//            CarManager carManager = new CarManager(new EfCarDal());
//            IDataResult<List<Car>> result = carManager.GetAll();

//            if (result.Success)
//            {
//                foreach (var cars in result.Data)
//                {
//                    Console.WriteLine(cars.Id);
//                }
//            }
//            else
//            {
//                Console.WriteLine(result.Message);
//            }
//        }
//        static void GetCarsWithBrandId()
//        {
//            CarManager carManager = new CarManager(new EfCarDal());
//            IDataResult<List<Car>> result = carManager.GetCarsWithBrandId(2);

//            if (result.Success)
//            {
//                foreach (var cars in result.Data)
//                {
//                    Console.WriteLine(cars.ModelYear);
//                }
//            }
//            else
//            {
//                Console.WriteLine(result.Message);
//            }

//        }
//    }
//    private static void AddNewCar()
//    {
//        CarManager carManager = new CarManager(new EfCarDal());
//        carManager.Add(new Car { BrandId = 1, ColorId = 3, DailyPrice = 2540, Description = "Top Level", ModelYear = 2023 });
//    }

//    private static void GetCarDetails()
//    {
//        CarManager carManager = new CarManager(new EfCarDal());

//        IDataResult<List<CarDetailDto>> result = carManager.GetCarDetails();

//        if (result.Success)
//        {
//            foreach (var car in result.Data)
//            {
//                Console.WriteLine(car.CarName + "/" + car.BrandName);
//            }
//        }
//        else
//        {
//            Console.WriteLine(result.Message);
//        }
//    }
//}