using Ahzyzyw.BLL;
using Ahzyzyw.DAL.SQLiteImpl;
using Ahzyzyw.Model;
using ElpSimWan.Utils;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ResourceItemRead
{

    class Program
    {
        static void Main(string[] args)
        {
            LogUtil.Init(typeof(Program));
            // AddResource.AddResourceItems();
            // ConnectResource.Connect();
            // UpdateImage.Update();
            // ReplacePic.Start();

            UpdateResource.Start();
            Console.ReadLine();
        }
    }
}
