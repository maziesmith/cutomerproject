using CustomerProject.DAL;
using CustomerProject.Functions;
using CustomerProject.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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
        private const string OPERATION_GET_CUSTOMER = "GetCustomer";
        private const string OPERATION_DELETE_CUSTOMER = "DeleteCustomer";
        private const string OPERATION_EDIT_CUSTOMER = "EditCustomer";
        private const string OPERATION_ADD_CUSTOMER = "AddCustomer";
        private const string OPERATION_SEARCH_CUSTOMERS = "SearchCustomers";

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                switch (context.Request[OPERATION_PARAMETER])
                {
                    case OPERATION_GET_CUSTOMERS:
                        SerializeJSON(context, GetCustomers());
                        break;
                    case OPERATION_GET_CUSTOMER:
                        SerializeJSON(context, GetCustomer(context));
                        break;
                    case OPERATION_DELETE_CUSTOMER:
                        DeleteCustomer(context);
                        SerializeJSON(context, "");
                        break;
                    case OPERATION_ADD_CUSTOMER:
                        AddCustomer(context);
                        SerializeJSON(context, "");
                        break;
                    case OPERATION_EDIT_CUSTOMER:
                        EditCustomer(context);
                        SerializeJSON(context, "");
                        break;
                    case OPERATION_SEARCH_CUSTOMERS:
                        SearchCustomers(context);
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

        private DataTableCustomersModel GetCustomers()
        {
            return new DataTableCustomersModel
            {
                data = DataLayer.GetCustomers()
            };
        }

        private CustomerModel GetCustomer(HttpContext context)
        {
            IDModel id = GetObjectFromJSON<IDModel>(context);

            if (id != null)
            {
                return DataLayer.GetCustomer(id.ID);
            }

            return null;
        }

        private void DeleteCustomer(HttpContext context)
        {
            IDModel id = GetObjectFromJSON<IDModel>(context);

            if (id != null)
            {
                DataLayer.DeleteCustomer(id.ID);
            }
        }

        private void AddCustomer(HttpContext context)
        {
            CustomerModel c = GetObjectFromJSON<CustomerModel>(context);
            DataLayer.AddCustomer(c);
        }

        private void EditCustomer(HttpContext context)
        {
            CustomerModel c = GetObjectFromJSON<CustomerModel>(context);
            DataLayer.EditCustomer(c);
        }

        private T GetObjectFromJSON<T>(HttpContext context)
        {
            string jsonString = String.Empty;
            context.Request.InputStream.Position = 0;
            using (StreamReader inputStream = new StreamReader(context.Request.InputStream))
            {
                jsonString = inputStream.ReadToEnd();
                JavaScriptSerializer jSerialize = new JavaScriptSerializer();
                return jSerialize.Deserialize<T>(jsonString);
            }
        }
    }
}