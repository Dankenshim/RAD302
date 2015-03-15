using Rad302CA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;


namespace Rad302CA.Controllers
{
    [RoutePrefix("api/cntry")]
    public class CountryController : ApiController
    {
        private CountryDb db = new CountryDb();

        [Route("getall")]
        public IQueryable<Country> GetCountries()
        {
            return db.Countries;
        }

        [ResponseType(typeof(Country))]
        [Route("getcntry/{id:int}")]
        public IHttpActionResult GetCountry(int id)
        {
            Country country = db.Countries.Find(id);
            if (country == null) 
            {
                return NotFound();
            }
            return Ok(country);

        }
        [Route("getcitydetails/{id:int}")]
        public IHttpActionResult GetCountryCities(int id)
        {
           
            Country cntry = db.Countries.Find(id);
            if(cntry == null)
            {
                return NotFound();
            }
            return Ok(new {Continent= cntry.Continent,Population = cntry.Population,Capital = cntry.Capital, CapitalPopulation= cntry.CapitalPopulation });
        }      
        
    }
}
