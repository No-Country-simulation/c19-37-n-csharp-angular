using System.Collections.Generic;
using bankito.DTOs;

namespace bankito.Services
{
    public interface ICountryService
    {
        IEnumerable<CountryDto> GetAll();
        CountryDto GetById(int id);
        void Add(CountryDto countryDto);
        void Update(CountryDto countryDto);
        void Delete(int id);
    }
}
