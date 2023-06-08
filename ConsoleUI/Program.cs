using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

internal class Program
{
    public static void Main(string[] args)
    {
        GetAllCars();
        GetCarsById();
        GetCarsWithBrandId();
        GetCarsByColorId();

        static void GetCarsById()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("The brand ID of the car with ID 1");
            Console.WriteLine(carManager.GetById(1).BrandId);
        }

        static void GetCarsByColorId()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("The cars with color 2 ID: ");
            foreach (var cars in carManager.GetCarsWithBrandId(2))
            {
                Console.WriteLine(cars.Id);
            }
        }

        static void GetAllCars()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("All car IDs we own: ");
            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine(cars.Id);
            }
        }

        static void GetCarsWithBrandId()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("The model year of cars with Brand ID 2");
            foreach (var cars in carManager.GetCarsWithBrandId(2))
            {
                Console.WriteLine(cars.ModelYear);
            }
        }

    }
}