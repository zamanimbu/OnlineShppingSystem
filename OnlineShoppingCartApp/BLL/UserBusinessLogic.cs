using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using OnlineShoppingCartApp.Model;
using OnlineShoppingCartApp.DAL;

namespace OnlineShoppingCartApp.BLL
{
    public class UserBusinessLogic
    {
        UserDataAccess aUserDataAccess = new UserDataAccess();
        public string addUser(User aUser)
        {
            SqlParameter[] aSqlParameter = new SqlParameter[5];

            aSqlParameter[0] = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
            aSqlParameter[0].Value = aUser.UserName;

            aSqlParameter[1] = new SqlParameter("@Password", SqlDbType.VarChar, 50);
            aSqlParameter[1].Value = aUser.Password;

            aSqlParameter[2] = new SqlParameter("@Name", SqlDbType.VarChar, 50);
            aSqlParameter[2].Value = aUser.Name;

            aSqlParameter[3] = new SqlParameter("@Email", SqlDbType.VarChar, 50);
            aSqlParameter[3].Value = aUser.Email;

            aSqlParameter[4] = new SqlParameter("@UserType", SqlDbType.VarChar, 50);
            aSqlParameter[4].Value = "U";


            int rowEffected = aUserDataAccess.AddUser(aSqlParameter);
            if (rowEffected > 0)
            {
                return "Save Successfuly";
            }
            else
            {
                return "Register Failed ";
            }
        }

        public bool IsUserExist(string userName, string password)
        {
            bool isUserNameExist = aUserDataAccess.IsUserExist(userName, password);

            return isUserNameExist;
        }

        public string CheackRole(string userName, string password)
        {
            string userType = aUserDataAccess.CheackRole(userName,password);
            return userType;
        }
    }
}