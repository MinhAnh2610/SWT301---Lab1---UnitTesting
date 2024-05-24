using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;

namespace CRUDExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountriesService _countriesService;

        public CountryController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        [HttpPost]
        public ActionResult<CountryResponse> AddCountry(CountryAddRequest? request)
        {
            CountryResponse countryResponse = _countriesService.AddCountry(request);

            return countryResponse;
        }

        [HttpGet("{id}")]
        public ActionResult<CountryResponse> GetCountryById(Guid id)
        {
            return _countriesService.GetCountryByCountryID(id);
        }

        [HttpGet]
        public ActionResult<IEnumerable<CountryResponse>> GetAll()
        {
            return _countriesService.GetAllCountries();
        }
    }
}
