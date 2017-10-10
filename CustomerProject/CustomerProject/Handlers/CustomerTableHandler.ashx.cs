using CustomerProject.DAL;
using CustomerProject.Functions;
using CustomerProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
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
        private const string OPERATION_EDIT_CUSTOMER = "EditCustomer";

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
                    case OPERATION_EDIT_CUSTOMER:
                        EditCustomer(context);
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
            

            string jsonString = String.Empty;
            HttpContext.Current.Request.InputStream.Position = 0;
            using (StreamReader inputStream =
            new StreamReader(HttpContext.Current.Request.InputStream))
            {
                jsonString = inputStream.ReadToEnd();
                JavaScriptSerializer jSerialize =
                    new JavaScriptSerializer();
                var IdGet = jSerialize.Deserialize<CustomerDetail>(jsonString);

                if (IdGet != null)
                {
                    Guid id = IdGet.id;
                    DataLayer.DeleteCustomer(id);
                   
                }
            }

        }
    }
}