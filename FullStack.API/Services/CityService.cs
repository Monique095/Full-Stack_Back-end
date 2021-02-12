using FullStack.Data;
using FullStack.Data.Entities;
using System.Collections.Generic;

namespace FullStack.API.Services
{
    public interface ICityService
    {
        IEnumerable<City> GetCities();
        City GetCity(int id);
    }

    public class CityService : ICityService
    {
        private FullStackRepository _repo;

        public CityService(FullStackRepository repo)
        {
            _repo = repo;
        }

        public City GetCity (int id)
        {
            var city = _repo.GetCityById(id);
            return city;
        }

        public IEnumerable<City> GetCities()
        {
            return _repo.GetCities();
        }
    }
}
