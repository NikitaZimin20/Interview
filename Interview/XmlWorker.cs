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
        public void LoadFromXml(List<UserModel> user)
        {
           
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Configuraton.FilePath);
            XmlElement? xRoot = xDoc.DocumentElement;

            foreach (XmlElement xnode in xRoot)
            {
                user.Add(new UserModel { ID = xnode.Attributes.GetNamedItem("ID").Value, Name = xnode.ChildNodes.Item(0).InnerText.Trim(), Surname = xnode.ChildNodes.Item(1).InnerText.Trim(), Phone = xnode.ChildNodes.Item(2).InnerText.Trim() });
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
            xd.Load(Configuraton.FilePath);
            XmlNode nl = xd.SelectSingleNode("users");
            XmlDocument xd2 = new XmlDocument();
            xd2.LoadXml("<user ID='" + GetLastID() + "'><name>" + username + "</name><surname>" + surname + "</surname><phone>" + phone + "</phone></user>");
            XmlNode n = xd.ImportNode(xd2.FirstChild, true);
            nl.AppendChild(n);
            xd.Save(Configuraton.FilePath);
        }
        public void ChangeXML(string InputId,string name,string surname,string phone )
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Configuraton.FilePath);

          
            XmlNodeList aNodes = doc.SelectNodes("users/user");

          
            foreach (XmlNode aNode in aNodes)
            {            
                XmlAttribute idAttribute = aNode.Attributes["ID"];
                if (idAttribute != null)
                {
                    string currentValue = idAttribute.Value;

                    
                    if (currentValue==InputId)
                    {
                        aNode.ChildNodes.Item(0).InnerText = name;
                        aNode.ChildNodes.Item(1).InnerText = surname;
                        aNode.ChildNodes.Item(2).InnerText = phone;
                    }
                }
            }
            doc.Save(Configuraton.FilePath);
        }
        private string GetLastID()
        {
            var xdoc = XDocument.Load(Configuraton.FilePath);
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
