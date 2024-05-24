using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CountriesService : ICountriesService
    {
        //private field
        private readonly List<Country> _countries;
        public CountriesService()
        {
            _countries = new List<Country>();
        }
        public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
        {

            //Validation: countryAddRequest parameter can't be null
            if (countryAddRequest is null)
            {
                throw new ArgumentNullException(nameof(countryAddRequest));
            }

            //Validation: countryName can't be null
            if (countryAddRequest.CountryName is null)
            {
                throw new ArgumentException(nameof(countryAddRequest.CountryName));
            }

            //Validation: countryName can't be duplicated
            if (_countries.Where(temp => temp.CountryName == 
            countryAddRequest.CountryName).Count() > 0)
            {
                throw new ArgumentException("Given country name already exists");
            }

            //Convert object from CountryAddRequest to Country type
            Country country = countryAddRequest.ToCountry();
            
            //generate CountryID
            country.CountryID = Guid.NewGuid();

            //Add country object into _countries
            _countries.Add(country);
            
            return country.ToCountryResponse();
        }

        public List<CountryResponse> GetAllCountries()
        {
            return _countries.Select(country 
                => country.ToCountryResponse()).ToList();
        }

        public CountryResponse? GetCountryByCountryID(Guid? countryID)
        {
            if (countryID is null)
            { return null; }
            Country? country_response_from_list = 
            _countries.FirstOrDefault(temp => 
            temp.CountryID == countryID);

            if (country_response_from_list is null)
            { return null; }

            return country_response_from_list.ToCountryResponse();
        }
    }
}
