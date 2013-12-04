using Ahzyzyw.BLL.Interface;
using ElpSimWan.Json;
using Library;
using Ahzyzyw.Model;
using System;

namespace Ahzyzyw.Test
{
    public class ResourceBLLTest
    {
        private readonly IResourceBLL _resourceBLL = UnityContext.LoadBllModel<IResourceBLL>();

        /// <summary>
        /// 获取资源列表
        /// </summary>
        public void GetResourceListTest()
        {
            int recordCount;
            var list = _resourceBLL.GetResourceList(new ResourceQueryOption(), out recordCount);
            Console.WriteLine(list.ToJSON());
        }
    }
}
