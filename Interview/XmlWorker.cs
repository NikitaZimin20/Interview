using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Interview
{
    class XmlWorker
    {
        public void LoadFromXml(List<CustomArray> user)
        {
           
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Configuraton.FilePath);
            XmlElement? xRoot = xDoc.DocumentElement;

            foreach (XmlElement xnode in xRoot)
            {
                user.Add(new CustomArray { ID = xnode.Attributes.GetNamedItem("ID").Value, Name = xnode.ChildNodes.Item(0).InnerText.Trim(), Surname = xnode.ChildNodes.Item(1).InnerText.Trim(), Phone = xnode.ChildNodes.Item(2).InnerText.Trim() });
            }

        }
        public void DeleteFromXml(string id)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("XMLFile1.xml");
            XmlElement? xRoot = xDoc.DocumentElement;
            foreach (XmlElement item in xRoot)
            {
                if (item.Attributes.GetNamedItem("ID").Value == id)
                {
                    xRoot.RemoveChild(item);
                }
            }
            xDoc.Save(Configuraton.FilePath);

        }
        public void AddToXML(string username,string surname,string phone)
        {
            var xd = new XmlDocument();
            xd.Load("XMLFile1.xml");
            XmlNode nl = xd.SelectSingleNode("users");
            XmlDocument xd2 = new XmlDocument();
            xd2.LoadXml("<user ID='" + GetLastID() + "'><name>" + username + "</name><surname>" + surname + "</surname><phone>" + phone + "</phone></user>");
            XmlNode n = xd.ImportNode(xd2.FirstChild, true);
            nl.AppendChild(n);
            xd.Save("XMLFile1.xml");
        }
        private string GetLastID()
        {
            var xdoc = XDocument.Load("XMLFile1.xml");
            XElement lastelement = xdoc.Root.Elements("user").LastOrDefault();
            if (lastelement is null)
            {
                return "0";
            }
            var value = int.Parse(lastelement.Attribute("ID").Value) + 1;
            return value.ToString();

        }
    }
}
