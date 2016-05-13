using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AuScGen
{
    public class BaseSetings
    {
        protected static string GetValue(string XMLPath, string key)
        {
            XmlDocument xmlDoc = GetXmlDoc(XMLPath);
            XmlNodeList settingList = xmlDoc.SelectNodes("/TestSettings/TestSetting");
            foreach (XmlNode valueNode in settingList)
            {
                if (valueNode.FirstChild.Name.Equals(key))
                {
                    return valueNode.FirstChild.InnerText;
                }
            }
            //return xmlDoc.SelectNodes("/TestSettings/TestSetting");
            return null;
        }

        public static string GetParam(string XMLPath, string testName, string paramName)
        {
            XmlDocument xmlDoc = GetXmlDoc(XMLPath);
            XmlNodeList settingList = xmlDoc.SelectNodes("/TestParams/TestParam");
            
            foreach (XmlNode valueNode in settingList)
            {
                if (((XmlElement)valueNode).GetAttribute("Name").Equals(testName))
                {
                    return ((XmlElement)valueNode).ChildNodes.Cast<XmlElement>().Where(element => element.Name.Equals(paramName)).FirstOrDefault().InnerText;
                }
            }
            //return xmlDoc.SelectNodes("/TestSettings/TestSetting");
            return null;
        }     

        protected static XmlDocument GetXmlDoc(string XMLPath)
        {
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(XMLPath);
            return XmlDoc;
        }    
    }
}
