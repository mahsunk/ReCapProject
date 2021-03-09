
using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Microsoft.AspNetCore.Http;

namespace Business.Abstrack
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetAllByCarId(int carId);
        IDataResult<CarImage> GetImageById(int Id);
        IResult Add(IFormFile image, CarImage carImage);
        IResult Update(IFormFile image, CarImage carImage);
        IResult Delete(CarImage carImage);
    }
}
