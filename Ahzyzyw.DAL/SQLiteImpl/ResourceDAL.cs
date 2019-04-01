using System;
using System.Collections.Generic;
using System.Diagnostics;
using ElpSimWan.Utils;
using Everest.Library.ExtensionMethod;
using Ahzyzyw.DAL.Interface;
using Ahzyzyw.Model;

namespace Ahzyzyw.DAL.SQLiteImpl
{
    public class ResourceDAL : DALBase, IResourceDAL
    {
        private const string TABLE_NAME = "Resource";

        public List<Resource> GetResourceList(ResourceQueryOption option, out int recordCount)
        {
            var sql = String.Format(@"SELECT R.*,
                               (SELECT CnTitle FROM  ResourceCategory WHERE CategoryID = substr(R.CategoryID,1,7)) AS 'GenFamily',
                               (SELECT CnTitle FROM  ResourceCategory WHERE CategoryID = substr(R.CategoryID,1,10)) AS 'GenGenus'
                        FROM {0} R WHERE 1=1", TABLE_NAME);

            if (!option.CategoryID.IsIgnoreQueryCondition())
            {
                sql = string.Format("{0} AND CategoryID LIKE '{1}%'", sql, option.CategoryID);
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



        public Resource GetResource(string resID)
        {
            var sql = string.Format(@"SELECT R.*, 
                                    (SELECT CnTitle FROM  ResourceCategory WHERE CategoryID = substr(R.CategoryID,1,7)) AS 'GenFamily',
                                    (SELECT CnTitle FROM  ResourceCategory WHERE CategoryID = substr(R.CategoryID, 1, 10)) AS 'GenGenus' 
                                    FROM {0} R WHERE ResID='{1}'", TABLE_NAME, resID);
            Debug.WriteLine(sql);
            var reader = SQLiteHelper.ExecuteReader(sql);
            return reader.ToResource();
        }

        public List<Resource> GetResourceByName(string resCnName)
        {
            var sql = string.Format("SELECT * FROM Resource WHERE CnName='{0}'", resCnName);
            Debug.WriteLine(sql);
            var reader = SQLiteHelper.ExecuteReader(sql);
            return reader.ToResourceList();
        }

        public string AddResource(Resource resource)
        {
            resource.CreateTime = DateTime.Now;

            var sql = string.Format(@"INSERT INTO Resource (ResID, CnName, EnName, OtherName, CategoryID, Image, Description, State, Location, Creator, CreateTime, Family, Genus)
                                      VALUES('{0}','{1}','{2}','{3}','{4}','{5}', '{6}',{7},'{8}','{9}','{10}','{11}','{12}')"
                                     , resource.ResID, resource.CnName, resource.EnName, resource.OtherName, resource.CategoryID
                                     , resource.Image, resource.Description, (int)resource.State, resource.Location, resource.Creator
                                     , resource.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"), resource.Family, resource.Genus);
            Debug.WriteLine(sql);

            int rows = SQLiteHelper.ExecuteNonQuery(sql);

            return rows == 1 ? resource.ResID : string.Empty;
        }


        public bool UpdateResource(Resource resource)
        {
            var sql = string.Format(@"UPDATE {0} 
                                      SET CnName='{1}', EnName='{2}', OtherName='{3}', Description='{4}'
                                      WHERE ResID='{5}'"
                                     , TABLE_NAME, resource.CnName, resource.EnName, resource.OtherName, resource.Description, resource.ResID);
            Debug.WriteLine(sql);

            int rows = SQLiteHelper.ExecuteNonQuery(sql);

            return rows == 1;
        }

        public bool DeleteResource(Guid resID)
        {
            var sql = string.Format(@"DELETE FROM Resource WHERE ResID='{0}'", resID);
            Debug.WriteLine(sql);
            int rows = SQLiteHelper.ExecuteNonQuery(sql);
            return rows == 1;
        }

        public bool EditResource(string resId, string imageName)
        {
            var sql = string.Format(@"UPDATE {0} SET [Image]='{1}' WHERE ResID='{2}'", TABLE_NAME, imageName, resId);
            Debug.WriteLine(sql);
            int rows = SQLiteHelper.ExecuteNonQuery(sql);
            return rows == 1;
        }

        public List<ResourceCategory> GetSubCategorys(string cateID)
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
                                     (SELECT COUNT(1) - 1 FROM ResourceCategory C2 WHERE C2.CategoryID LIKE C1.CategoryID || '%') AS SubCategoryCount
                                     FROM ResourceCategory C1 WHERE C1.CategoryID LIKE '{0}'", searchPattern);
            Debug.WriteLine(sql);
            var reader = SQLiteHelper.ExecuteReader(sql);
            return reader.ResourceCategoryList();
        }

        public string CreateCategory(ResourceCategory cate, string parentCateID)
        {
            try
            {
                FixParentCateID(ref parentCateID);

                var subCateList = GetSubCategorys(parentCateID);
                int currentCate = 1;
                foreach (var Category in subCateList)
                {
                    var subCateID = int.Parse(Category.CategoryID.RightSubstring(3));
                    if (subCateID > currentCate)
                    {
                        break;
                    }

                    currentCate++;
                }

                var gategroyId = parentCateID + currentCate.ToString("d3");
                var sql = string.Format(@"INSERT INTO ResourceCategory (CategoryID, CnTitle, EnTitle, CreateTime)
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
            var sql = string.Format(@"DELETE FROM ResourceCategory WHERE CategoryID='{0}'", cateID);
            Debug.WriteLine(sql);
            int rows = SQLiteHelper.ExecuteNonQuery(sql);
            return rows == 1;
        }

    }
}
