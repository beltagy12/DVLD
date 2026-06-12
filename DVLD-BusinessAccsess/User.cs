using DVLD_DataAccsess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessAccsess
{
    public  class clsUser
    {
      
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int UserID { get; set; }
        public int PersonID { get; set; }
        public clsPersonBusinessAccsess personinfo;
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

       public clsUser() {
            this.UserID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = true;
            Mode=enMode.AddNew;
        }

        clsUser(int UserID,int PersonID,string UserName,string Password,bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.personinfo = clsPersonBusinessAccsess.Find(PersonID); //Get Person Info
                                                                       //user class Compostion person class
            this.Password = Password;
            this.IsActive = IsActive;
            Mode=enMode.Update;
           
        }

        private bool _AddNewUser()
        {
            this.UserID = UsersData.AddNewUser(this.PersonID, this.UserName, Password, IsActive);
            return (this.UserID != -1);
        }

        private bool _UpdateUser()

        {
            return UsersData.UpdateUser(this.UserID,this.PersonID,
                this.UserName,this.Password,this.IsActive);
        }

        public static clsUser FindUserByID(int UserID)

        {
            int PersonID = -1;
            string UserName = "";
            string Password = "";
            bool IsActive= false;

            bool IsFound = UsersData.GetUserInfoByUserID(UserID, ref PersonID
                , ref UserName, ref Password, ref IsActive);

            if (IsFound)
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            }
            else
                return null;

        }

        public static clsUser FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = "", Password = "";
            bool IsActive=false;

            bool IsFound=UsersData.GetUserInfoByPersonID(PersonID, ref UserID,ref UserName, ref Password,ref IsActive);

            if (IsFound)
                return new clsUser( UserID,PersonID, UserName, Password, IsActive);

            else return null;

        }

        public static clsUser FindByUserNameAndPassword(string UserName,string Password)
        {
            int UserID = -1;
            int PersonID = -1;
            bool IsActive = false;

            bool IsFound=UsersData.GetUserInfoByUsernameAndPassword(UserName, Password
                , ref UserID,ref PersonID,ref IsActive);

            if(IsFound)
                    return new clsUser(UserID ,PersonID, UserName, Password, IsActive);
            else return null;

        }

        public static DataTable GetAllYUsers()
        {
            return UsersData.GetAllUsers();
        }
        public static bool DeleteUser(int UserID)
        {
            return UsersData.DeleteUser(UserID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateUser();

            }

            return false;
        }
        public static bool IsUserExist(int UserID)
        {
            return UsersData.IsUserExist(UserID);
        }

        public static bool isUserExist(string UserName)
        {
            return UsersData.IsUserExist(UserName);
        }

        public static bool isUserExistForPersonID(int PersonID)
        {
            return UsersData.IsUserExistForPersonID(PersonID);
        }
    }
}
