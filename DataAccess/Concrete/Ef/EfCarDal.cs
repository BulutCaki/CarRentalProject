using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.Ef
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails(Expression < Func<CarDetailsDto, bool> > filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from ca in context.Cars
                             join co in context.Colors on ca.ColorId equals co.Id
                             join br in context.Brands on ca.BrandId equals br.Id
                             select new CarDetailsDto
                             {
                                 CarId = ca.Id,
                                 BrandId = br.Id,
                                 ColorId = co.Id,
                                 BrandName = br.Name,
                                 ColorName = co.Name,
                                 DailyPrice = ca.DailyPrice,
                                 ModelYear = ca.ModelYear,
                                 Description = ca.Description,
                                 Images = (from i in context.CarImages where i.CarId == ca.Id select i.ImagePath).ToList(),
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }
    }
}
