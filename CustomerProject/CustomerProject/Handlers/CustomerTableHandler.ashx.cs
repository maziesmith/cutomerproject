using CustomerProject.DAL;
using CustomerProject.Functions;
using CustomerProject.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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
        private const string OPERATION_DELETE_CUSTOMER = "DeleteCustomer";

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                switch (context.Request[OPERATION_PARAMETER])
                {
                    case OPERATION_GET_CUSTOMERS:
                        SerializeJSON(context, GetCustomers());
                        break;
                    case OPERATION_DELETE_CUSTOMER:
                        DeleteCustomer(context);
                        SerializeJSON(context, "");
                        break;
                    //other methods
                    default:
                        context.Response.StatusCode = 404; // Not Found
                        context.Response.StatusDescription = "Operation not found.";
                        break;
                }
            }
            catch
            {
                context.Response.StatusCode = 500; // Internal Server Error
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

        private DataTableCustomers GetCustomers()
        {
            List<CustomerDetail> entities = DataLayer.GetCustomers();
            List<Customer> customers = new List<Customer>();

            foreach (CustomerDetail customerEntity in entities)
            {
                Customer c = CustomerModelMapper.convertEntityToCustomer(customerEntity);
                customers.Add(c);
            }

            return new DataTableCustomers
            {
                data = customers
            };
        }

        private void DeleteCustomer(HttpContext context)
        {
            string bodyText = new StreamReader(context.Request.InputStream).ReadToEnd();
            String[] substrings = bodyText.Split('=');
            Guid id = new Guid(substrings[1]);
            DataLayer.DeleteCustomer(id);
        }
    }
}