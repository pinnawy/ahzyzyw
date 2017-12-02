using Ahzyzyw.BLL;
using Ahzyzyw.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ElpSimWan.Utils;

namespace ResourceItemRead
{
    class AddResource
    {
        public static void AddResourceItems()
        {
            Regex categoryRegex = new Regex(@"^(?<No>[一二三四五六七八九十]+)、\s*(?<CnName>[\u4e00-\u9fa5]+)\s*(?<EnName>\w+)");
            Regex resourceRegex = new Regex(@"^(?<No>\d+).\s*(?<CnName>[\u4e00-\u9fa5㼎]+)\s*(?<EnName>[\w.．\[\] \-（）\(\)]+)[（\(]\s*(?<shu>[\u4e00-\u9fa5㼎]+)\s*[）\)]\s*");
            Regex otherNameRegex = new Regex(@"【别    名】(?<OtherName>.*)");
            var lines = File.ReadAllLines(@"C:\Users\Taly\Desktop\items.txt");

            List<ResourceCategory> categoryList = new List<ResourceCategory>();
            List<Resource> resourceList = new List<Resource>();

            int itemCount = 0;

            StringBuilder resourceDetail = new StringBuilder();
            Resource resource = null;
            ResourceCategory resourceCategory= null;
            foreach (var line in lines)
            {
                if (categoryRegex.IsMatch(line))
                {
                    itemCount++;
                    var groups = categoryRegex.Match(line).Groups;
                    resourceCategory = new ResourceCategory
                    {
                        CnTitle = groups["CnName"].ToString().Trim(),
                        EnTitle = groups["EnName"].ToString().Trim()

                    };
                    categoryList.Add(resourceCategory);
                    Console.WriteLine("{0}\t{1}\t\t{2}", line, groups["CnName"], groups["EnName"]);
                }
                else if (resourceRegex.IsMatch(line))
                {
                    if (resource != null)
                    {
                        resource.Description = resourceDetail.ToString();
                        resourceList.Add(resource);
                    }
                    resource = new Resource();
                    var groups = resourceRegex.Match(line).Groups;
                    resource.CnName = groups["CnName"].ToString().Trim();
                    resource.EnName = groups["EnName"].ToString().Trim();
                    resource.Family = resourceCategory.CnTitle;
                    resource.Genus = groups["shu"].ToString().Trim();
                    resource.Image = "";
                    //Console.WriteLine("{0}.{1}\t{2}\t{3}", groups["No"], groups["CnName"], groups["EnName"], groups["shu"]);
                    resourceDetail.Clear();
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        if (otherNameRegex.IsMatch(line))
                        {
                            resource.OtherName = otherNameRegex.Match(line).Groups["OtherName"].ToString().Trim(' ', '。');
                        }
                        else
                        {
                            resourceDetail.AppendLine(line.Trim() + "</br>");
                        }
                    }
                }
            }

            resource.Description = resourceDetail.ToString();
            resourceList.Add(resource);

            Console.WriteLine("itemCount:{0}", itemCount);
            itemCount = 0;
            ResourceBLL bll = new ResourceBLL();
            foreach (var res in resourceList)
            {
                Console.WriteLine("Add resource：{0}， {1}", itemCount, res.CnName);
                var resList = bll.GetResourceByName(res.CnName);
                if (resList.Count > 0)
                {
                    LogUtil.Log.WarnFormat("{0} exist", res.CnName);
                }
                else
                {
                    bll.AddResource(res);
                }
               
            }
        }
    }
}
