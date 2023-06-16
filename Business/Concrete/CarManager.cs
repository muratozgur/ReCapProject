using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public void Add(Car car)
        {
            if (car.Description.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("The car with " + car.Id + " ID added successfully");
            }
            else
            {
                throw new Exception("The length of the car name must be bigger than 2 letters\n" +
                    "and daily price of car must be bigger than 0");
            }
        }
        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("The car with " + car.Id + " ID deleted successfully");
        }
        public void Update(Car car)
        {
            _carDal.Update(car);
        }
        public List<Car> GetAll()
        {
            //business codes will be implemented
           return _carDal.GetAll();
        }
        public List<Car> GetCarsWithBrandId(int brandId)
        {
            return _carDal.GetAll(c=> c.BrandId == brandId);
        }

        public Car GetById(int Id)
        {
            return _carDal.Get(c => c.Id == Id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails(); //extra method in ICarDal
        }
    }
}
