using System;
using System.Collections.Generic;
using System.Diagnostics;
using ElpSimWan.Utils;
using Everest.Library.ExtensionMethod;
using Ahzyzyw.DAL.Interface;
using Ahzyzyw.Model;

namespace Ahzyzyw.DAL.SQLiteImpl
{
    public class ResourceDAL : IResourceDAL
    {
        public List<Resource> GetResourceList(ResourceQueryOption option, out int recordCount)
        {
            var sql = @"SELECT R.*,
                               (SELECT CnTitle FROM  ResourceCategroy WHERE CategroyID = substr(R.CategroyID,1,7)) AS 'Family',
                               (SELECT CnTitle FROM  ResourceCategroy WHERE CategroyID = substr(R.CategroyID,1,10)) AS 'Genus'
                        FROM Resource R WHERE 1=1";

            if (!option.CategroyID.IsIgnoreQueryCondition())
            {
                sql = string.Format("{0} AND CategroyID LIKE '{1}%'", sql, option.CategroyID);
            }

            if (!option.QueryKeyWord.IsIgnoreQueryCondition())
            {
                sql = string.Format("{0} AND CnName LIKE '%{1}%' OR EnName LIKE '%{1}%' OR OtherName LIKE '%{1}%'", sql, option.QueryKeyWord.ToSqlLikeQueryString());
            }

            if (option.State != ResourceState.None)
            {
                sql = string.Format("{0} AND State={1}", sql, (int)option.State);
            }

            if (!option.SortName.IsIgnoreQueryCondition())
            {
                sql = string.Format("{0} ORDER BY {1} {2}", sql, option.SortName, option.SortDir);
            }

            Debug.WriteLine(sql);

            var reader = SQLiteHelper.ExecuteReaderPager(out recordCount, option.PageNumber, option.PageSize, sql);
            return reader.ToResourceList();
        }

        public Resource GetResource(Guid resID)
        {
            throw new NotImplementedException();
        }

        public string AddResource(Resource resource)
        {
            resource.CreateTime = DateTime.Now;

            var sql = string.Format(@"INSERT INTO Resource (ResID, CnName, EnName, OtherName, CategroyID, Image, Description, State, Location, Creator, CreateTime)
                                      VALUES('{0}','{1}','{2}','{3}','{4}','{5}', '{6}',{7},'{8}','{9}','{10}')"
                                     , resource.ResID, resource.CnName, resource.EnName, resource.OtherName, resource.CategroyID
                                     , resource.Image, resource.Description, (int)resource.State, resource.Location, resource.Creator
                                     , resource.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"));
            Debug.WriteLine(sql);

            int rows = SQLiteHelper.ExecuteNonQuery(sql);

            return rows == 1 ? resource.ResID : string.Empty;
        }

        public bool DeleteResource(Guid resID)
        {
            var sql = string.Format(@"DELETE FROM Resource WHERE ResID='{0}'", resID);
            Debug.WriteLine(sql);
            int rows = SQLiteHelper.ExecuteNonQuery(sql);
            return rows == 1;
        }

        public bool EditResource(Resource resource)
        {
            throw new NotImplementedException();
        }

        public List<ResourceCategroy> GetSubCategorys(string cateID)
        {
            FixParentCateID(ref cateID);

            int len = cateID.Length;
            string searchPattern;
            switch (len)
            {
                case 0:
                    searchPattern = "__";
                    break;
                case 2:
                    searchPattern = cateID + "__";
                    break;
                default:
                    searchPattern = cateID + "___";
                    break;
            }
            var sql = string.Format(@"SELECT C1.*, 
                                     (SELECT COUNT(1) - 1 FROM ResourceCategroy C2 WHERE C2.CategroyID LIKE C1.CategroyID || '%') AS SubCategroyCount
                                     FROM ResourceCategroy C1 WHERE C1.CategroyID LIKE '{0}'", searchPattern);
            Debug.WriteLine(sql);
            var reader = SQLiteHelper.ExecuteReader(sql);
            return reader.ResourceCategroyList();
        }

        public string CreateCategory(ResourceCategroy cate, string parentCateID)
        {
            try
            {
                FixParentCateID(ref parentCateID);

                var subCateList = GetSubCategorys(parentCateID);
                int currentCate = 1;
                foreach (var categroy in subCateList)
                {
                    var subCateID = int.Parse(categroy.CategroyID.RightSubstring(3));
                    if (subCateID > currentCate)
                    {
                        break;
                    }

                    currentCate++;
                }

                var gategroyId = parentCateID + currentCate.ToString("d3");
                var sql = string.Format(@"INSERT INTO ResourceCategroy (CategroyID, CnTitle, EnTitle, CreateTime)
                            VALUES('{0}','{1}','{2}','{3}')", gategroyId, cate.CnTitle, cate.EnTitle, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                Debug.WriteLine(sql);
                int rows = SQLiteHelper.ExecuteNonQuery(sql);

                return rows == 1 ? gategroyId : string.Empty;
            }
            catch (Exception ex)
            {
                LogUtil.Log.Error("ResourceDAL::CreateCategory, Exception:", ex);
                return string.Empty;
            }
        }

        private static void FixParentCateID(ref string parentCateID)
        {
            if (parentCateID == "01" || parentCateID == "02")
            {
                parentCateID += "--";
            }
        }

        public bool DeleteCategory(string cateID)
        {
            var sql = string.Format(@"DELETE FROM ResourceCategroy WHERE CategroyID='{0}'", cateID);
            Debug.WriteLine(sql);
            int rows = SQLiteHelper.ExecuteNonQuery(sql);
            return rows == 1;
        }
    }
}
