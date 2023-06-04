using eDominerUser.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace eDominerUser.Repository
{
    public class eDominerUserRepo
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["eDominerDB"].ToString();
            con = new SqlConnection(constr);
        }
        public bool AddUser(eDominerUserModel eDominerUser )
        {
            connection();
            SqlCommand com = new SqlCommand("AddUser", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name",     eDominerUser.Name);
            com.Parameters.AddWithValue("@EmailId",  eDominerUser.EmailId);
            com.Parameters.AddWithValue("@MobileNumber", eDominerUser.MobileNumber);
            com.Parameters.AddWithValue("@Address", eDominerUser.Address);
            com.Parameters.AddWithValue("@Gender", eDominerUser.Gender);
            com.Parameters.AddWithValue("@StateName", eDominerUser.StateName);
            com.Parameters.AddWithValue("@Hobbies", eDominerUser.Hobbies);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public List<eDominerUserModel> GetAllRecod()
        {
            connection();
            List<eDominerUserModel> eDominerUserModels = new List<eDominerUserModel>();
            SqlCommand com = new SqlCommand("GetAllRecod", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                eDominerUserModels.Add(

                    new eDominerUserModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        EmailId = Convert.ToString(dr["EmailId"]),
                        MobileNumber = Convert.ToString(dr["MobileNumber"]),
                        Address = Convert.ToString(dr["Address"]),
                        Gender = Convert.ToString(dr["Gender"]),
                        StateName = Convert.ToString(dr["StateName"]),
                        Hobbies = Convert.ToString(dr["Hobbies"])
                    }
                    );
            }

            return eDominerUserModels;
        }


        public bool UpdateUser(eDominerUserModel dominerUserModel)
        {
            
            connection();
            SqlCommand com = new SqlCommand("UpdateEmpDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", dominerUserModel.Id);
            com.Parameters.AddWithValue("@Name", dominerUserModel.Name);
            com.Parameters.AddWithValue("@EmailId", dominerUserModel.EmailId);
            com.Parameters.AddWithValue("@MobileNumber", dominerUserModel.MobileNumber);
            com.Parameters.AddWithValue("@Address", dominerUserModel.Address);
            com.Parameters.AddWithValue("@Gender", dominerUserModel.Gender);
            com.Parameters.AddWithValue("@StateName", dominerUserModel.StateName);
            com.Parameters.AddWithValue("@Hobbies", dominerUserModel.Hobbies);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }
        public List<eDominerUserModel> GetUserById(int Id)
        {
            connection();
            List<eDominerUserModel> eDominerUserModels = new List<eDominerUserModel>();
            SqlCommand com = new SqlCommand("Sp_GetById", con);
            com.Parameters.AddWithValue("@Id",Id);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                eDominerUserModels.Add(

                    new eDominerUserModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        EmailId = Convert.ToString(dr["EmailId"]),
                        MobileNumber = Convert.ToString(dr["MobileNumber"]),
                        Address = Convert.ToString(dr["Address"]),
                        Gender = Convert.ToString(dr["Gender"]),
                        StateName = Convert.ToString(dr["StateName"]),
                        Hobbies = Convert.ToString(dr["Hobbies"])
                    }
                    );
            }

            return eDominerUserModels;
        }


        public bool DeleteEmployee(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("DeleteEmpById", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", Id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }

        public bool GetState(int StateId)
        {

            connection();
            SqlCommand com = new SqlCommand("GetStateById", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@StateId", StateId);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }
    }
}