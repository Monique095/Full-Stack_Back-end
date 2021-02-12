using FullStack.Data;
using FullStack.Data.Entities;
using FullStack.ViewModels;
using System.Collections.Generic;
using WebApi.Entities;

namespace FullStack.API.Services
{
    public interface IAdverts_Service
    {
        IEnumerable<Advert> GetAllAdverts();
        IEnumerable<Advert> GetMyAdverts(int userId);
        Advert GetAdvertById(int id);
        Advert CreateAdvert(Advert advert);
        void UpdateAdvert(Advert model);
        void DeleteAdvert(int id);

    }
    public class AdvertService : IAdverts_Service
    {
        private IFullStackRepository _repo;

        public AdvertService(IFullStackRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Advert> GetAllAdverts()
        {

            return _repo.GetAdverts();
        }

        public Advert GetAdvertById( int id )
        {
           var advert =  _repo.GetAdvert(id);
            return advert;
        }

        public Advert CreateAdvert(Advert advert)
        {
            _repo.CreateAdvert(advert);
            return advert;
        }
        public void UpdateAdvert( Advert advert)
        {
            _repo.UpdateAdvert(advert);  
        }

        public void DeleteAdvert ( int id )
        {
            _repo.DeleteAdvert(id);
        }

        public IEnumerable<Advert> GetMyAdverts( int userId)
        {
            var adverts = _repo.GetAdvertsByUserId(userId);
            return adverts;
        }

        private AdvertModel Map (Advert advert)
        {

            Province province = _repo.GetProvinceById(advert.ProvinceId);

            return new AdvertModel
            {
                Id = advert.Id,
                AdvertHeadlineText = advert.AdvertHeadlineText,
                AdvertDetail = advert.AdvertDetail,
                Province = province.ProvinceName,
                ProvinceId = province.Id

            };
        }

        private Advert Map(AdvertModel model)
        {
            return new Advert
            {
                Id = model.Id,
                AdvertHeadlineText = model.AdvertHeadlineText,
                AdvertDetail = model.AdvertDetail,
                ProvinceId = model.ProvinceId,
                CityId = model.CityId,

            };
        }

       

    }
}
