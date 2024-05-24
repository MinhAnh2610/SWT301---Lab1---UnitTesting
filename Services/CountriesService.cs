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
        public List<Country> _countries { get; set; }
        public CountriesService()
        {
            _countries = new List<Country>()
            {
                new Country
                {
                    CountryID = Guid.Parse("0c2287a1-80ed-411f-8a97-90505fdf721d"),
                    CountryName = "USA"
                },
                new Country
                {
                    CountryID = Guid.Parse("03bc011f-3c2d-40ed-806f-53ebae4374ba"),
                    CountryName = "Vietnam"
                },
                new Country
                {
                    CountryID = Guid.Parse("32eb515e-1d8f-4c7b-ab5e-ff44adb0c6b5"),
                    CountryName = "Thailand"
                },
                new Country
                {
                    CountryID = Guid.Parse("c5ac763a-1a55-4769-85a3-f4e95064589d"),
                    CountryName = "England"
                }
            };
        }
        public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
        {

            ////Validation: countryAddRequest parameter can't be null
            //if (countryAddRequest == null)
            //{
            //    throw new ArgumentNullException(nameof(countryAddRequest));
            //}

            ////Validation: countryName can't be null
            //if (countryAddRequest.CountryName == null)
            //{
            //    throw new ArgumentException(nameof(countryAddRequest.CountryName));
            //}

            ////Validation: countryName can't be duplicated
            //if (_countries.Where(c => c.CountryName == 
            //countryAddRequest.CountryName).Count() > 0)
            //{
            //    throw new ArgumentException("Given country name already exists");
            //}

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
            if(countryID == null)
            { return null; }
            Country? country_response_from_list =
            _countries.FirstOrDefault(temp =>
            temp.CountryID == countryID);

            if(country_response_from_list == null)
            { return null; }

            return country_response_from_list.ToCountryResponse();
        }
    }
}
