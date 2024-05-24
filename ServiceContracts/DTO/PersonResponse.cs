using Entities;
using ServiceContracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// Represents DTO class that is used as return
    /// type of most methods of Persons Service
    /// </summary>
    public class PersonResponse
    {
        public Guid PersonID { get; set; }
        public string? PersonName { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public Guid? CountryID { get; set; }
        public string? Country { get; set; } 
        public string? Address { get; set; }
        public bool ReceiveNewsLetters { get; set; }
        public double? Age { get; set; }

        /// <summary>
        /// Compares the current object data with the 
        /// parameter object
        /// </summary>
        /// <param name="obj">
        /// The PersonResponse Object to compare</param>
        /// <returns>
        /// True or False, indicating whether
        /// all person details are mathced with the
        /// specified parameter object</returns>
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj.GetType() != typeof(PersonResponse))
                return false;
            PersonResponse person = (PersonResponse)obj;
            return PersonID == person.PersonID
                && PersonName == person.PersonName
                && DateOfBirth == person.DateOfBirth
                && Gender == person.Gender
                && CountryID == person.CountryID
                && Address == person.Address
                && ReceiveNewsLetters == person.ReceiveNewsLetters;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"Person ID: {PersonID}, Person Name: {PersonName}," +
                $"Email: {Email}, Date of Birth: {DateOfBirth?.ToString("dd MM yyyy")}," +
                $"Gender: {Gender}, Country ID: {CountryID}," +
                $"Country: {Country}, Address: {Address}, Receive News Letters: {ReceiveNewsLetters}";
        }

        public PersonUpdateRequest ToPersonUpdateRequest()
        {
            return new PersonUpdateRequest()
            {
                PersonID = PersonID,
                PersonName = PersonName,
                Gender = (GenderOptions)Enum.Parse(typeof(GenderOptions), Gender, true),
                Address = Address,
                CountryID = CountryID,
                ReceiveNewsLetters = ReceiveNewsLetters,
            };
        }
    }
    public static class PersonExtensions
    {
        /// <summary>
        /// An extension method to convert an object of
        /// Person class into PersonResponse class
        /// </summary>
        /// <param name="person">The Person object to
        /// convert</param>
        /// <returns>Returns the converted PersonResponse object</returns>
        public static PersonResponse ToPersonResponse(this Person person)
        {
            return new PersonResponse()
            {
                PersonID = person.PersonID,
                PersonName = person.PersonName,
                DateOfBirth = person.DateOfBirth,
                Email = person.Email,
                ReceiveNewsLetters = person.ReceiveNewsLetters,
                Address = person.Address,
                CountryID = person.CountryID,
                Gender = person.Gender,
                Age = (person.DateOfBirth != null) ?
                Math.Round((DateTime.Now - person.DateOfBirth.Value).TotalDays / 365.25) : null,

            };
        }
    }
}
