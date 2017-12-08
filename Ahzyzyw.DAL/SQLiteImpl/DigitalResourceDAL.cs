using System;
using System.Collections.Generic;
using System.Diagnostics;
using ElpSimWan.Utils;
using Everest.Library.ExtensionMethod;
using Ahzyzyw.DAL.Interface;
using Ahzyzyw.Model;

namespace Ahzyzyw.DAL.SQLiteImpl
{
    public class DigitalResourceDAL : DALBase, IDigitalResourceDAL
    {
        private const string TABLE_NAME = "DigitalResource";

        public List<DigitalResource> GetDigitalResourceList(DigitalResourceQueryOption option, out int recordCount)
        {
            var sql = String.Format(@"SELECT R.*
                        FROM {0} R WHERE 1=1", TABLE_NAME);

            if (!option.FuncID.IsIgnoreQueryCondition())
            {
                sql = string.Format("{0} AND FuncID LIKE '{1}%'", sql, option.FuncID);
            }

            if (!option.PartID.IsIgnoreQueryCondition())
            {
                sql = string.Format("{0} AND PartID LIKE '{1}%'", sql, option.PartID);
            }

            if (!option.QueryKeyWord.IsIgnoreQueryCondition())
            {
                sql = string.Format("{0} AND CnName LIKE '%{1}%' OR OtherName LIKE '%{1}%'", sql, option.QueryKeyWord.ToSqlLikeQueryString());
            }

            if (!option.SortName.IsIgnoreQueryCondition())
            {
                sql = string.Format("{0} ORDER BY {1} {2}", sql, option.SortName, option.SortDir);
            }

            Debug.WriteLine(sql);

            var reader = SQLiteHelper.ExecuteReaderPager(out recordCount, option.PageNumber, option.PageSize, sql);
            return reader.ToDigitalResourceList();
        }

        public DigitalResource GetDigitalResource(string resID)
        {
            var sql = string.Format("SELECT * FROM {0} WHERE ResID='{1}'", TABLE_NAME, resID);
            Debug.WriteLine(sql);
            var reader = SQLiteHelper.ExecuteReader(sql);
            return reader.ToDigitalResource();
        }

        public string AddDigitalResource(DigitalResource resource)
        {
            resource.CreateTime = DateTime.Now;


            var sql = string.Format(@"INSERT INTO DigitalResource (No, ResID, CnName, OtherName, Image, Description, FuncID, FuncName, PartID, PartName, FakeImage, Creator, CreateTime, PlantImage)
                                      VALUES({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}', '{13}')"
                                     , resource.No, resource.ResID, resource.CnName, resource.OtherName, resource.Image, resource.Description, resource.FuncID, resource.FunnCateName, resource.PartID, resource.PartName
                                     , resource.FakePicList.JoinString(","), resource.Creator
                                     , resource.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"), 
                                     resource.PlantImageList.JoinString(","));
            Debug.WriteLine(sql);

            int rows = SQLiteHelper.ExecuteNonQuery(sql);

            return rows == 1 ? resource.ResID : string.Empty;
        }

   
    }
}
