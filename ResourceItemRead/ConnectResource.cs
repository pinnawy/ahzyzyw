using System;
using System.Xml.Linq;
using Ahzyzyw.BLL;

namespace ResourceItemRead
{
    class ConnectResource
    {
        public static void Connect()
        {
            try
            {
                ResourceBLL bll = new ResourceBLL();
                XDocument doc = XDocument.Load(@"C:\Users\Taly\Desktop\res.xml");
                var spans = doc.Descendants("span");
                foreach (var xElement in spans)
                {
                    var resList = bll.GetResourceByName(xElement.Value.Trim());
                    if (resList.Count > 1)
                    {
                        Console.WriteLine(xElement.Value);
                    }
                    else if(resList.Count == 1)
                    {
                        var cnName = xElement.Value;
                        xElement.Value = string.Empty;
                        var a = new XElement("a", cnName);
                        a.SetAttributeValue("resId", resList[0].ResID);
                        xElement.Add(a);
                    }
                   
                }
                doc.Save(@"C:\Users\Taly\Desktop\res2.xml");
            }
            catch (Exception ex)
            {
                
            }

        }
    }
}
