using CustomerProject.DAL;
using CustomerProject.Functions;
using CustomerProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CustomerProject.Handlers
{
    /// <summary>
    /// Summary description for CustomerTableHandler
    /// </summary>
    public class CustomerTableHandler : IHttpHandler
    {
        private const string OPERATION_PARAMETER = "operation";
        private const string OPERATION_GET_CUSTOMERS = "GetCustomers";

        public void ProcessRequest(HttpContext context)
        {
            switch (context.Request[OPERATION_PARAMETER])
            {
                case OPERATION_GET_CUSTOMERS:
                    SerializeJSON(context, GetCustomers());
                    break;
                //other methods
                default:
                    throw new ArgumentException("unknown operation");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private void SerializeJSON(HttpContext context, Object serializableObject)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            context.Response.ContentType = "application/json";
            context.Response.Write(serializer.Serialize(serializableObject));
        }

        private List<Customer> GetCustomers()
        {
            List<CustomerDetail> entities = DataLayer.GetCustomers();
            List<Customer> customers = new List<Customer>();

            foreach (CustomerDetail customerEntity in entities)
            {
                Customer c = CustomerModelMapper.convertEntityToCustomer(customerEntity);
                customers.Add(c);
            }

            return customers;
        }
    }
}