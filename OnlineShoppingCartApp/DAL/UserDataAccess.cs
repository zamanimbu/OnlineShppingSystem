using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace OnlineShoppingCartApp.DAL
{
    public class UserDataAccess:Gateway
    {

        
        public int AddUser(SqlParameter[] aSqlParameter)
        {
            int rowEffected = 0;
            Command = new SqlCommand("InsertUser",Connection);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddRange(aSqlParameter);
            Connection.Open();
            rowEffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowEffected;
        }

        public bool IsUserExist(string userName, string password)
        {
            bool isUserExist = false;
            Command.CommandText = "select * from Users where UserName = '" + userName + "' and Password = '"+password+"'";
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                isUserExist = true;
            }
            Reader.Close();
            Connection.Close();

            return isUserExist;

        }

        public string CheackRole(string userName, string password)
        {
            string userType = null;
            Command.CommandText = "select UserType from Users where UserName = '" + userName + "' and Password = '" + password + "'";
            Connection.Open();
            userType = Command.ExecuteScalar().ToString();
           
            Connection.Close();

            return userType;
        }
    }
}