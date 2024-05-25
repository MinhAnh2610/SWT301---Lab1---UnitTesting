using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
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
        //public override bool Equals(object? obj)
        //{
        //    if (obj is null) return false;
        //    if (obj.GetType() != typeof(CountryResponse))
        //        return false;
        //    CountryResponse country = (CountryResponse)obj;
        //    return CountryId == country.CountryId
        //        && CountryName == country.CountryName;
        //}
        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}
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
