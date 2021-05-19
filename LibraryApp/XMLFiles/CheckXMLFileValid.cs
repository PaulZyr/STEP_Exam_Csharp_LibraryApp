using System;
using System.Xml;

namespace LibraryApp.XMLFiles
{
    class CheckXMLFileValid
    {
        public bool Check(string path)
        {
            XmlTextReader reader = null;
            try
            {
                reader = new XmlTextReader(path);
                reader.WhitespaceHandling = WhitespaceHandling.None;

                if (reader.Read() && reader.Name == "xml"
                    && reader.Read() && reader.Name == "ArrayOfBook"
                    || reader.Name == "ArrayOfReader"
                    || reader.Name == "ArrayOfRoom")
                {
                    return true;
                }


            }
            catch
            {
                return false;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return false;
        }
        
    }
}
