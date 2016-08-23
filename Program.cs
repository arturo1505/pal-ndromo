using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Configuration;
using ConsoleApplication1;
using System.Xml;


namespace ConsoleApplication1
{
    class Program
    {


        static void Main(string[] args)
        {

            try
            {
                string[] arrPalabras= new string [5];

                for (int nindice = 0; nindice < arrPalabras.Length; nindice++)
                {

                    Console.WriteLine("	Favor de Capturar una palabra: ");
                    string vpalabra = Console.ReadLine();
                    arrPalabras[nindice] = vpalabra;
                }

                string strURL = "http://localhost/RestWebService/palindromo";
             

                byte[] dataByte = GenerarXML(arrPalabras);

                HttpWebRequest POSTRequest = (HttpWebRequest)WebRequest.Create(strURL);
                //Method type
                POSTRequest.Method = "POST";
                // Data type - message body coming in xml
                POSTRequest.ContentType = "text/xml";
                POSTRequest.KeepAlive = false;
                POSTRequest.Timeout = 5000;
                //Content length of message body
                POSTRequest.ContentLength = dataByte.Length;

                // Get the request stream
                Stream POSTstream = POSTRequest.GetRequestStream();
                // Write the data bytes in the request stream
                POSTstream.Write(dataByte, 0, dataByte.Length);

                //Get response from server
                HttpWebResponse POSTResponse = (HttpWebResponse)POSTRequest.GetResponse();
                StreamReader reader = new StreamReader(POSTResponse.GetResponseStream(), Encoding.UTF8);
                Console.WriteLine("Response");
                Console.WriteLine(reader.ReadToEnd().ToString());           


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Read();
            }

 
        }


        private static byte[] GenerarXML(string[] arrPalabras)
        {
            // Create the xml document in a memory stream - Recommended
            MemoryStream mStream = new MemoryStream();
            
            XmlTextWriter xmlWriter = new XmlTextWriter(mStream, Encoding.UTF8);
            xmlWriter.Formatting = Formatting.Indented;
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Palindromos");
            for (int nindice = 0; nindice < arrPalabras.Length; nindice++)
            {
                xmlWriter.WriteStartElement("Palabra");
                xmlWriter.WriteString(arrPalabras[nindice]);
                xmlWriter.WriteEndElement();
            }
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Flush();
            xmlWriter.Close();
            return mStream.ToArray();
        }
 
    }
}
