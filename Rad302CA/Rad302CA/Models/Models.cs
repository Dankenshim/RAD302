﻿using System;
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
                new Country(){Name="Ireland", Continent= Continent.Europe, Cities = new List<Cities>()
                {
                    new Cities()
                    {Name = "Dublin", 
                        Population = 1273069 
                    },
                    new Cities()
                    { Name = "Sligo",
                        Population = 20000
                    }
                }},
                new Country(){Name="United States", Continent= Continent.North_America, Cities= new List<Cities>()
                {
                    new Cities()
                    {Name ="New York",
                        Population = 8406000
                    }, new Cities()
                    {Name="Washington",
                    Population=7062000}

            }},
             new Country(){Name="Australia", Continent= Continent.Australia, Cities= new List<Cities>()
                {
                    new Cities()
                    {Name ="Perth",
                        Population = 8406000
                    }, new Cities()
                    {Name="Brisbane",
                    Population=7062000}
                }},
                 new Country(){Name="Bazil", Continent= Continent.South_America, Cities= new List<Cities>()
                {
                    new Cities()
                    {Name ="Rio de Janero",
                        Population = 8406000
                    }, new Cities()
                    {Name="Brasilia",
                    Population=7062000}
                }}
            };
            countries.ForEach(cntry => context.Countries.Add(cntry));
            context.SaveChanges();

            base.Seed(context);
        }
    }
    public class CountryDb : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Cities> Cities { get; set; }

        public CountryDb()
            : base("CountryDbs")
        { }
    }
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string Name { get; set; }
        public Continent Continent { get; set; }
        public virtual List<Cities> Cities { get; set; }

    }
    public class Cities
    {
        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
    public enum Continent
    {
        Europe, Africa, Asia, North_America, South_America, Antarctica, Australia
    }
}