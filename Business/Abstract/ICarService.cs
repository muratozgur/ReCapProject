using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car> >GetCarsWithBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IResult AddTransactionalTest(Car car);
    }
}
