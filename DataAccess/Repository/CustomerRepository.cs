using DataAccess.DataModel;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataAccess.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public SqlConnection con;
        public void connection()
        {
            string lstrConString = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(lstrConString);
        }
        public bool AddCustomer(CustomerMaster cm)
        {
            string constr = ConfigurationManager.ConnectionStrings["FMSARABICEntities"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            SqlCommand sCommand = new SqlCommand("stpMAS_SaveCustomer", con);
            sCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sCommand.Parameters.AddWithValue("@CUSTOMERCODE", cm.CustomerCode);
            sCommand.Parameters.AddWithValue("@COMPANYCODE", cm.CompanyCode);
            sCommand.Parameters.AddWithValue("@COMPANYNAME", cm.CompanyName);
            sCommand.Parameters.AddWithValue("@ADDRESS1", cm.Address1);
            sCommand.Parameters.AddWithValue("@ADDRESS2", cm.Address2);
            sCommand.Parameters.AddWithValue("@CITY", cm.City);
            sCommand.Parameters.AddWithValue("@STATECODE", cm.StateCode);
            sCommand.Parameters.AddWithValue("@COUNTRYCODE", cm.CountryCode);
            sCommand.Parameters.AddWithValue("@ZIPCODE", cm.ZipCode);
            sCommand.Parameters.AddWithValue("@PHONE", cm.Phone);
            sCommand.Parameters.AddWithValue("@FAX", cm.Fax);
            sCommand.Parameters.AddWithValue("@EMAIL", cm.Email);
            sCommand.Parameters.AddWithValue("@INACTIVE", cm.InActive);
            sCommand.Parameters.AddWithValue("@CREATEDDATE", cm.CreatedDate);

            con.Open();
            int i = sCommand.ExecuteNonQuery();
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

        public List<Customer> GetCustomers()
        {
            return new List<Customer>(){
                new Customer { CustomerCode = "JF0001", CompanyName = "Jeyaprakash", CompanyCode = "001" ,Address1 = "Address1",Address2 = "Address2",City = "City",StateCode = "StateCode",CountryCode = "CountryCode",ZipCode = "ZipCode",Phone = "Phone",Fax = "Fax",Email = "Email",InActive = "InActive"}
                //CreatedDate = ""
            };
        }

        public List<Customer> GetCustomerEntities()
        {
            List<Customer> Customers = new List<Customer>();
            using (FMSARABICEntities context = new FMSARABICEntities())
            {
                var custList = context.CustomerMasters.ToList();
                foreach (var item in custList)
                {
                    Customers.Add(new Customer { CustomerCode = item.CustomerCode, CompanyName = item.CompanyName, CompanyCode = item.CompanyCode,
                        Address1 = item.Address1,
                        Address2 = item.Address2,
                        City = item.City,
                        StateCode = item.StateCode,
                        CountryCode = item.CountryCode,
                        ZipCode = item.ZipCode,
                        Phone = item.Phone,
                        Fax = item.Fax,
                        Email = item.Email,
                        InActive = item.InActive,
                        CreatedDate = item.CreatedDate
                    });
                }
            }
            return Customers;
        }

        public bool AddCustomer()
        {
            throw new NotImplementedException();
        }
    }
}
