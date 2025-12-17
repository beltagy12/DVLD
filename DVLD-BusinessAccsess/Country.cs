using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccsess;

namespace DVLD_BusinessAccsess
{
    public  class Country
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        private Country(int countryID, string countryName)
        {
            this.CountryID = countryID;
            this.CountryName = countryName;
        }
       public Country()
            {
            CountryID = -1;
            CountryName = "";
            }

        public static Country Find(int countryID)
        {
            string CountryName = "";
            if(CountryData.GetCountryInfoByID(countryID,ref CountryName))
            {
                return new Country(countryID, CountryName);
            }
            else
                return null;
        }
        public static Country Find(string CountryName)
        {
            int CountryID = -1;
            if (CountryData.GetCountryInfoByName(CountryName, ref CountryID))
            {
                return new Country(CountryID, CountryName);
            }
            else
                return null;
        }
        public static DataTable GetAllCountries()
        {
            return CountryData.GetAllCountries();
        }


    }
}
