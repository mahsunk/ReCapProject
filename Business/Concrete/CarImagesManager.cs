using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Business.Abstrack;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Result;
using DataAccess.Abstrack;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImagesManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }


        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }
      

        public IDataResult<CarImage> GetImageById(int Id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == Id));
        }
        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CarImage>>(result);
            }
            List<CarImage> images = new List<CarImage>();
            images.Add(new CarImage() { CarId = 0, Id = 0, Date = DateTime.Now, ImagePath = "/images/IMG_20200128_153629.png" });//Eğer ki bu Id de herhangi bir resim yoksa ona Default bir resim atıyor. 
            return new SuccessDataResult<List<CarImage>>(images);
        }


        [ValidationAspect(typeof(CarImagesValidator))]
        public IResult Add(IFormFile image, CarImage carImage)
        {
            IResult result = BusinessRule.Run(CarImageCarIdControl(carImage.CarId),CarImagesMaxLimit(carImage.CarId), CarImageFileControl(image, carImage));
            if (result != null)
            {
                return result;
            }
            
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRule.Run(CarImageDeleteControl(carImage));
            if (result != null)
            {
                return result;
            }
           
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IResult Update(IFormFile image, CarImage carImage)
        {
            var theImage = _carImageDal.Get(c => c.Id == carImage.Id);
            if (theImage == null)
            {
                return new ErrorResult(Messages.ImageNotFound);                          //Seçilen bir resim yoksa bunu ver.
            }

            var updatedFile = ImageUploadHelper.Update(image, theImage.ImagePath);
            theImage.ImagePath = updatedFile.Message;
            theImage.Date = DateTime.Now;
            _carImageDal.Update(theImage);
            return new SuccessResult(Messages.SuccessVoid);

        }




        private IResult CarImagesMaxLimit(int carId)
        {

            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >=5)
            {
                return new ErrorResult(Messages.CarImagesMaxLimitError);
            }
            return new SuccessResult();
        }



        private IResult CarImageDeleteControl(CarImage carImage)
        {
            var image = _carImageDal.Get(c => c.Id == carImage.Id);
            if (image == null)
            {
                return new ErrorResult(Messages.ImageNotFound);
            }
            ImageUploadHelper.Delete(image.ImagePath);

             
            return new SuccessResult();
        }

        private IResult CarImageFileControl(IFormFile image, CarImage carImage)
        {
             
            if (image == null)
            {
                return new ErrorResult(Messages.ImageNotFound);
            }
             if (carImage.CarId==0)
            {
                return new ErrorResult(Messages.ImageIdNotFound);
            }

            var imageResult = ImageUploadHelper.Upload(image);
            carImage.ImagePath = imageResult.Message;//Upload dan gelen mesaj bir dosya yoludur.
            carImage.Date = DateTime.Now;

            return new SuccessResult();
        }

        private IResult CarImageCarIdControl(int carId)
        {
            var result = _carImageDal.Get(c => c.CarId == carId);
            if (result==null)
            {
                return  new ErrorResult(Messages.CarIdNoting);
            }
            return new SuccessResult();
        }
    }
}
