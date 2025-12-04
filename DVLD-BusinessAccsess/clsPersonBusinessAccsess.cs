 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DVLD_DataAccsess;
namespace DVLD_BusinessAccsess
{
    public class clsPersonBusinessAccsess
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gendor { get; set; }
        public string Address{  get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }
        public int PersonID { get; set; }

      public  clsPersonBusinessAccsess()
        {
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.MinValue;
            this.Gendor = -1;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.ImagePath = "";
            this.PersonID = -1;
            Mode = enMode.AddNew;


        }
        private clsPersonBusinessAccsess( int personID, string nationalNo, string firstName, string secondName, string thirdName, string lastName, DateTime dateOfBirth, int gendor, string address, string phone, string email, int nationalityCountryID, string imagePath)
        {
          
            this.NationalNo = nationalNo;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Gendor = gendor;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.NationalityCountryID = nationalityCountryID;
            this.ImagePath = imagePath;
            this.PersonID = personID;
            Mode = enMode.Update;
        }

        public static DataTable GetAllPerson()
        {
            return clsPersonDataAccsess.GetAllPersons();
        }
        public static clsPersonBusinessAccsess Find(int ID)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Phone = "", Email = "", ImagePath = "";
            int Gendor = 0, NationalityCountryID = 0;
            DateTime DateOfBirth = DateTime.MinValue;

            if(clsPersonDataAccsess.GetPersonInfoByID(ID,ref NationalNo,ref FirstName,ref SecondName,ref ThirdName,
                ref LastName,ref DateOfBirth,ref Gendor,ref Address,ref Phone,ref Email,ref NationalityCountryID,ref ImagePath))
            {
                return new clsPersonBusinessAccsess(ID, NationalNo, FirstName, SecondName, ThirdName,
                LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
                return null;

        }

        public  bool AddNewPerson()
        {
            this.PersonID = clsPersonDataAccsess.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName,
                this.LastName, this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);

                return (this.PersonID != -1);
        }
        public bool UpdatePerson()
        {
            return clsPersonDataAccsess.UpdataPerson(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName,
                this.LastName, this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
        }
        public static bool DeletePerson(int ID)
        {
            return clsPersonDataAccsess.DeletePerson(ID);
        }

        public bool IsPersonExist(int ID)
        {
            return clsPersonDataAccsess.IsPersonExist(ID);
        }
        public bool Save()
        {
            Console.WriteLine(Mode);

            switch (Mode)
            {
                case enMode.AddNew:
                    if (AddNewPerson())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return UpdatePerson();

            }




            return false;
        }

        public static DataTable Filter(string column,string value) 
            {
            return clsPersonDataAccsess.Filter(column,value);
            }

        public static DataTable FillAllCountriesInCb()
        {
            return clsPersonDataAccsess.GetAllCountries();
        }

    }
}
