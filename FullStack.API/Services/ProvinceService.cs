using FullStack.Data;
using FullStack.Data.Entities;
using System.Collections.Generic;

namespace FullStack.API.Services
{
    public interface IProvinceService
    {
        IEnumerable<Province> GetProvinces();
        IEnumerable<Province> GetProvinceByCity(int cityId);
        Province GetProvince(int id);
    }

    public class ProvinceService : IProvinceService
    {
        private FullStackRepository _repo;

        public ProvinceService(FullStackRepository repo)
        {
            _repo = repo;
        }

        public Province GetProvince(int id)
        {
            var province = _repo.GetProvinceById(id);
            return province;
        }

        public IEnumerable<Province> GetProvinceByCity(int cityId)
        {
            var province = _repo.GetByProvinceCity(cityId);
            return province;
        }

        public IEnumerable<Province> GetProvinces()
        {
            return _repo.GetProvinces();
        }
    }
}