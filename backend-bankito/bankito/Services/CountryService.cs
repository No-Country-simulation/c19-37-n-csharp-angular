using System.Collections.Generic;
using System.Linq;
using bankito.DTOs;
using bankito.Models;
using bankito.Repositories;

namespace bankito.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _Repository;

        public CountryService(ICountryRepository countryRepository)
        {
            _Repository = countryRepository;
        }

        public IEnumerable<CountryDto> GetAll()
        {
            return _Repository.GetAll().Select(p => new CountryDto
            {
                Id = p.Id,
                // Add other properties here
            });
        }

        public CountryDto GetById(int id)
        {
            var country = _Repository.GetById(id);
            if (country == null) return null;

            return new CountryDto
            {
                Id = country.Id,
                // Add other properties here
            };
        }

        public void Add(CountryDto countryDto)
        {
            var country = new Country
            {
                Id = countryDto.Id,
                // Add other properties here
            };
            _Repository.Add(country);
        }

        public void Update(CountryDto countryDto)
        {
            var country = new Country
            {
                Id = countryDto.Id,
                // Add other properties here
            };
            _Repository.Update(country);
        }

        public void Delete(int id) => _Repository.Delete(id);
    }
}
