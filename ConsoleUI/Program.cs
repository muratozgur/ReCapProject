using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

internal class Program
{
    public static void Main(string[] args)
    {
        ICarService carManager = new CarManager(new InMemoryCarDal());
        Car car = new Car
        {
            Id = 5,
            BrandId = 2,
            ColorId = 3,
            DailyPrice = 455.60,
            ModelYear = 2022,
            Description = "Good"
        };

        carManager.Add(car);

        Console.WriteLine("The model year of the selected car is: " +
            carManager.GetById(3).ModelYear);

        Console.WriteLine("ID numbers of cars we own ");
        foreach (var cars in carManager.GetAll())
        {
            Console.WriteLine(cars.Id);
        }

    }
}