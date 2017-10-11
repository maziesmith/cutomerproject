﻿using CustomerProject.DAL;
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
        private const string OPERATION_DELETE_CUSTOMER = "DeleteCustomer";
        private const string OPERATION_EDIT_CUSTOMER = "EditCustomer";
        private const string OPERATION_ADD_CUSTOMER = "AddCustomer";

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
                    case OPERATION_ADD_CUSTOMER:
                        AddCustomer(context);
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
            return new DataTableCustomers
            {
                data = DataLayer.GetCustomers()
            };
        }

        private void DeleteCustomer(HttpContext context)
        {
            Customer c = getCustomerFromJSON(context);
            if (c != null)
            {
                Guid id = c.ID;
                DataLayer.DeleteCustomer(id);
            }
        }

        private void AddCustomer(HttpContext context)
        {
            Customer c = getCustomerFromJSON(context);
            DataLayer.AddCustomer(c);
        }

        private Customer getCustomerFromJSON(HttpContext context)
        {
            string jsonString = String.Empty;
            context.Request.InputStream.Position = 0;
            using (StreamReader inputStream = new StreamReader(context.Request.InputStream))
            {
                jsonString = inputStream.ReadToEnd();
                JavaScriptSerializer jSerialize = new JavaScriptSerializer();
                return jSerialize.Deserialize<Customer>(jsonString);
            }
        }
    }
}