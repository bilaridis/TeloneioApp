using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using TeloneioApp.Models;

namespace TeloneioApp.StaticResources
{
    /// <summary>XmlReader Class translate the XML Parameter and Screens. 
    /// <para>This Class create the Lists from Screens and Examples that program has.</para>
    /// </summary> 
    public static class XmlExtension
    {
        public static XmlLibrary.XmlModels.ID15A.ID15A XmlReaderForID15A(string path)
        {
            XmlLibrary.XmlModels.ID15A.ID15A result = null;
            StreamReader reader2 = null;
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(XmlLibrary.XmlModels.ID15A.ID15A));
                reader2 = new StreamReader(path);
                result = (XmlLibrary.XmlModels.ID15A.ID15A)xs.Deserialize(reader2);

            }
            catch (Exception ex)
            {
                throw ex;
                //ignored
            }
            finally
            {
                if (reader2 != null)
                {
                    reader2.Close();
                }
            }
            return result;

        }

        public static string Serialize<T>(this T value)
        {
            if (value == null)
            {
                return string.Empty;
            }
            try
            {
                var xmlserializer = new XmlSerializer(typeof(T));
                var stringWriter = new MyStringWriter();
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    xmlserializer.Serialize(writer, value, ns);
                    return stringWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }

        public static String PrintXML(String XML)
        {
            String Result = "";

            MemoryStream mStream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(mStream, Encoding.Unicode);
            XmlDocument document = new XmlDocument();

            try
            {
                // Load the XmlDocument with the XML.
                document.LoadXml(XML);

                writer.Formatting = Formatting.Indented;

                // Write the XML into a formatting XmlTextWriter
                document.WriteContentTo(writer);
                writer.Flush();
                mStream.Flush();

                // Have to rewind the MemoryStream in order to read
                // its contents.
                mStream.Position = 0;

                // Read MemoryStream contents into a StreamReader.
                StreamReader sReader = new StreamReader(mStream);

                // Extract the text from the StreamReader.
                String FormattedXML = sReader.ReadToEnd();

                Result = FormattedXML;
            }
            catch (XmlException)
            {
            }

            mStream.Close();
            writer.Close();

            return Result;
        }
    }
}