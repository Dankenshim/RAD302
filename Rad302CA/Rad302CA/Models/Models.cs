using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Rad302CA.Models
{
    class CountryDbInitialiser : DropCreateDatabaseAlways<CountryDb>
    {
        protected override void Seed(CountryDb context)
        {
            var countries = new List<Country>()
            {
                new Country(){Name="Ireland", Continent= "Europe",Population=500000,Capital="Dublin",CapitalPopulation=10000000},
                new Country(){Name="United States", Continent= "North America",Population=100000000,Capital="Washington", CapitalPopulation=3500000},
             new Country(){Name="Australia", Continent= "Australia",Population=600000000, Capital="Perth",CapitalPopulation=4000000},
                 new Country(){Name="Bazil", Continent= "South America",Population =140000000, Capital="Brasilia", CapitalPopulation=5000000}
            };
            countries.ForEach(cntry => context.Countries.Add(cntry));
            context.SaveChanges();

            base.Seed(context);
        }
    }
    public class CountryDb : DbContext
    {
        public DbSet<Country> Countries { get; set; }
     

        public CountryDb()
            : base("CountryDbs")
        { }
    }
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public int Population { get; set; }
        public string Capital { get; set; }
        public int CapitalPopulation { get; set; }


    }
  
}