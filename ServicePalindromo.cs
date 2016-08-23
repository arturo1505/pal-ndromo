using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WbAppApiRest
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicePalindromo" en el código y en el archivo de configuración a la vez.
    public class ServicePalindromo : System.Web.IHttpHandler
    {
        void System.Web.IHttpHandler.ProcessRequest(System.Web.HttpContext context)
        {
            try
            {

                byte[] PostData = context.Request.BinaryRead(context.Request.ContentLength);
                //Convert the bytes to string using Encoding class
                string str = Encoding.UTF8.GetString(PostData);
                //// deserialize xml into employee class
                //Company.Employee emp = Deserialize(PostData);
                //// Insert data in database
                //dal.AddEmployee(emp);               
            }
            catch (Exception ex)
            {
                    
            }
        }

        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }
    }
}
