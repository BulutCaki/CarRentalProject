using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IDataResult<List<CarDetailsDto>> GetCarDetailByFilter(int brandId, int colorId);
        IDataResult<List<CarDetailsDto>> GetCarDetailsByColorId(int colorId);
        IDataResult<List<CarDetailsDto>> GetCarDetailsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<CarDetailsDto>> GetCarDetails();
        IDataResult<List<CarDetailsDto>> GetCarDetailsByCarId(int carId);

    }
}
