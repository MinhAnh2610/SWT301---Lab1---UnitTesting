using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// DTO class that is used as return type for
    /// of CountriesService methods
    /// </summary>
    public class CountryResponse
    {
        public Guid CountryId { get; set; }
        public string? CountryName { get; set; }

        //It compares the current object to another object
        // of CountryResponse type and returns true,
        // if both values are same; otherwise returns false
    }

    //extension method to Country 
    public static class CountryExtensions
    { 
        //Converts from Country object to CountryResponse object
        public static CountryResponse ToCountryResponse
            (this Country country) 
        {
            return new CountryResponse()
            {
                CountryId = country.CountryID,
                CountryName = country.CountryName,
            };
        }
    }
}
