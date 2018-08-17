using System;
using System.IO;
using System.Xml;

namespace WorkData.WeiXin.Helper
{
    public static class XmlHelper
    {
        public static string FormatXml(this XmlDocument xmlDoc)
        {
            try
            {
                using (var strWriter = new StringWriter())
                {
                    using (var xmlTextWriter = new XmlTextWriter(strWriter))
                    {
                        xmlTextWriter.Indentation = 2;
                        xmlTextWriter.Formatting = Formatting.Indented;
                        xmlDoc.WriteContentTo(xmlTextWriter);
                        xmlTextWriter.Close();
                    }
                    return strWriter.ToString();
                }
            }
            catch
            {
                return xmlDoc.OuterXml;
            }
        }

        public static string FormatXml(this string xmlString)
        {
            try
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlString);
                using (var strWriter = new StringWriter())
                {
                    using (var xmlTextWriter = new XmlTextWriter(strWriter))
                    {
                        xmlTextWriter.Indentation = 2;
                        xmlTextWriter.Formatting = Formatting.Indented;
                        xmlDoc.WriteContentTo(xmlTextWriter);
                        xmlTextWriter.Close();
                    }
                    return strWriter.ToString();
                }
            }
            catch
            {
                return xmlString;
            }
        }

        public static string GetText(this XmlDocument xml, string xpath)
        {
            var node = xml.SelectSingleNode(xpath);
            return node?.InnerText;
        }

        public static int GetInt32(this XmlDocument xml, string xpath)
        {
            var node = xml.SelectSingleNode(xpath);
            return Convert.ToInt32(node?.InnerText);
        }

        public static long GetInt64(this XmlDocument xml, string xpath)
        {
            var node = xml.SelectSingleNode(xpath);
            return Convert.ToInt64(node?.InnerText);
        }

        public static Double GetDouble(this XmlDocument xml, string xpath)
        {
            var node = xml.SelectSingleNode(xpath);
            return Convert.ToDouble(node?.InnerText);
        }
    }
}