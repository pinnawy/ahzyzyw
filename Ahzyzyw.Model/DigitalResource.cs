using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ahzyzyw.Model
{

    /// <summary>
    /// 数字资源
    /// </summary>
    [Serializable]
    public class DigitalResource : Resource
    {
        public DigitalResource()
        {
            FakePicList = new List<string>();
            PlantImageList = new List<string>();
        }

        /// <summary>
        /// 药材编号
        /// </summary>
        public int No
        {
            get;
            set;
        }

        /// <summary>
        /// 按药用功能分类的ID
        /// </summary>
        public string FuncID
        {
            get;
            set;
        }

        /// <summary>
        /// 按药用功能分类的名称
        /// </summary>
        public String FunnCateName
        {
            get;
            set;
        }

        /// <summary>
        /// 入药部位ID
        /// </summary>
        public string PartID
        {
            get;
            set;
        }

        /// <summary>
        /// 入药部位名称
        /// </summary>
        public String PartName
        {
            get;
            set;
        }

        /// <summary>
        /// 伪品图片
        /// </summary>
        public List<String> FakePicList
        {
            get;
            set;
        }

        /// <summary>
        /// 植物图
        /// </summary>
        public List<String> PlantImageList
        {
            get;
            set;
        }

    }
}
