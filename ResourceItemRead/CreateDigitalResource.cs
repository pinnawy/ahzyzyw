using Ahzyzyw.BLL;
using Ahzyzyw.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using ElpSimWan.Utils;
using Ahzyzyw.DAL.SQLiteImpl;

namespace ResourceItemRead
{
    class CreateDigitalResource
    {

        class Category
        {
            public int No { get; set; }
            int FuncID { get; set; }
            int PartID { get; set; }
        }

        public static void Start()
        {
            Regex name = new Regex(@"^(?<No>\d+)\s*(?<CnName>[\u4e00-\u9fa5]+)");
            Regex otherNameRegex = new Regex(@"\s*【常用别名】\s*(?<OtherName>.*)");


            var lines = File.ReadAllLines(@"E:\数字中药标本馆程序处理\文字内容.txt");

            List<DigitalResource> resourceList = new List<DigitalResource>();


            StringBuilder resourceDetail = new StringBuilder();
            DigitalResource resource = null;
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                if (name.IsMatch(line))
                {
                    if (resource != null)
                    {
                        resource.Description = resourceDetail.ToString();
                        resourceList.Add(resource);
                        resourceDetail.Clear();
                    }

                    var groups = name.Match(line).Groups;
                    resource = new DigitalResource
                    {
                        ResID = Guid.NewGuid().ToString(),
                        CnName = groups["CnName"].ToString(),
                        No = int.Parse(groups["No"].ToString())
                    };
                    Console.WriteLine("{0}\t{1}\t\t{2}", line, resource.No, resource.CnName);
                }
                else if (otherNameRegex.IsMatch(line))
                {
                    resource.OtherName = otherNameRegex.Match(line).Groups["OtherName"].ToString();
                }
                else
                {

                    resourceDetail.AppendLine(line.Trim() + "</br>");

                }
            }

            resource.Description = resourceDetail.ToString();
            resourceList.Add(resource);


            // 加载药材分类
            Regex cateRegex = new Regex(@"^(?<ID>\d+)\s*(?<Name>[\u4e00-\u9fa5]+)");

            Dictionary<string, string> funcCategory = new Dictionary<string, string>();
            lines = File.ReadAllLines(@"E:\数字中药标本馆程序处理\FuncCategory.txt");
            foreach (var line in lines)
            {
                if (cateRegex.IsMatch(line))
                {
                    var groups = cateRegex.Match(line).Groups;
                    funcCategory.Add(groups["Name"].ToString(), groups["ID"].ToString());
                }
            }

            Dictionary<string, string> partCategory = new Dictionary<string, string>();
            lines = File.ReadAllLines(@"E:\数字中药标本馆程序处理\PartCategory.txt");
            foreach (var line in lines)
            {
                if (cateRegex.IsMatch(line))
                {
                    var groups = cateRegex.Match(line).Groups;
                    partCategory.Add(groups["Name"].ToString(), groups["ID"].ToString());
                }
            }


            var funcLines = File.ReadAllLines(@"E:\数字中药标本馆程序处理\Func.txt");
            var partLines = File.ReadAllLines(@"E:\数字中药标本馆程序处理\Part.txt");
            for (int i = resourceList.Count - 1; i > -1; i--)
            {

                resource = resourceList[i];

                var pair = GetCateID(resource.No, funcLines, funcCategory);
                resource.FuncID = pair.Value;
                resource.FunnCateName = pair.Key;

                pair = GetCateID(resource.No, partLines, partCategory);
                resource.PartID = pair.Value;
                resource.PartName = pair.Key;
            }


            // 补充伪品图
            DirectoryInfo imageDir = new DirectoryInfo(@"E:\数字中药标本馆程序处理\中草药识别应用图鉴（伪品）");
            var images = imageDir.GetFiles("*.jpg");
            Regex noRegex = new Regex(@"^\s*(?<ID>\d+).+");

            for (int i = 0; i < resourceList.Count; i++)
            {
                resource = resourceList[i];

                foreach (var fakeImage in images)
                {
                    var id = noRegex.Match(fakeImage.Name).Groups["ID"].ToString();

                    if (id.Equals(resource.No.ToString()))
                    {
                        resource.FakePicList.Add(fakeImage.Name);
                    }
                }
            }

            // 补充药材图
            imageDir = new DirectoryInfo(@"E:\数字中药标本馆程序处理\中草药识别应用图鉴（药材图）");
            images = imageDir.GetFiles("*.jpg");

            for (int i = 0; i < resourceList.Count; i++)
            {
                resource = resourceList[i];

                foreach (var image in images)
                {
                    var id = noRegex.Match(image.Name).Groups["ID"].ToString();

                    if (id.Equals(resource.No.ToString()))
                    {
                        resource.Image = image.Name;
                    }
                }
            }

            // 补充植物图
            imageDir = new DirectoryInfo(@"E:\数字中药标本馆程序处理\中草药识别应用图鉴（原植物图）");
            images = imageDir.GetFiles("*.jpg");

            for (int i = 0; i < resourceList.Count; i++)
            {
                resource = resourceList[i];

                foreach (var image in images)
                {
                    var id = noRegex.Match(image.Name).Groups["ID"].ToString();

                    if (id.Equals(resource.No.ToString()))
                    {
                        resource.PlantImage = image.Name;
                    }
                }
            }

            Console.WriteLine("itemCount:{0}", resourceList.Count);

            //DigitalResourceDAL dal = new DigitalResourceDAL();
            //foreach (var res in resourceList)
            //{
            //    dal.AddDigitalResource(res);
            //}

            //Console.WriteLine("itemCount:{0}", resourceList.Count);
        }

        static KeyValuePair<string, string> GetCateID(int no, string[] linesArr, Dictionary<string, string> dic)
        {
            List<string> lines = new List<string>(linesArr);
            Regex cateRegex = new Regex(@"^(.*F)\s*(?<Cate>[\u4e00-\u9fa5]+)");
            Regex noRegex = new Regex(@"^\s*(?<NO>\d+).+");
            bool findResource = false;
            for (int index = lines.Count - 1; index > -1; index--)
            {
                var line = lines[index].Trim();

                if (noRegex.IsMatch(line) && noRegex.Match(line).Groups["NO"].ToString().Equals(no.ToString()) && !cateRegex.IsMatch(line))
                {
                    findResource = true;
                    continue;
                }

                if (findResource && cateRegex.IsMatch(line))
                {
                    var groups = cateRegex.Match(line).Groups;
                    var cateName = groups["Cate"].ToString();
                    var cateID = dic[cateName];
                    Console.WriteLine("{0}\t{1}\t\t{2}", cateID, cateName, line);
                    return new KeyValuePair<string, string>(cateName, cateID);
                }

            }

            Console.WriteLine("ERROR: can not found cate for no: {0}", no);
            return new KeyValuePair<string, string>();
        }
    }
}
