using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car { Id = 1, BrandId = 2, ColorId = 2, ModelYear = 2012, DailyPrice = 360, Description = "In a good condition"},
                new Car { Id = 2, BrandId = 2, ColorId = 1, ModelYear = 2008, DailyPrice = 380, Description = "In a good condition"},
                new Car { Id = 3, BrandId = 1, ColorId = 4, ModelYear = 2023, DailyPrice = 460, Description = "Full of fuel"},
                new Car { Id = 4, BrandId = 4, ColorId = 12, ModelYear = 2022, DailyPrice = 415, Description = "In a good condition"}
            };
        }
        public Car GetById(int wantedId)
        {
            Car carToGet = _cars.SingleOrDefault(c => c.Id == wantedId);
            return carToGet;
        }
        public List<Car> GetAll()
        {
            return _cars;
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }
        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }
        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(car => car.Id == car.Id);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
