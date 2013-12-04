using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Ahzyzyw.Model;

namespace Ahzyzyw.DAL.SQLiteImpl
{
    /// <summary>
    /// SqliteDataReader帮助类
    /// Author: yuwang 2011-3-9
    /// </summary>
    public static class SqliteDataReaderHelper
    {
        public static List<Resource> ToResourceList(this SQLiteDataReader reader)
        {
            List<Resource> reslist = new List<Resource>();
            while (reader.Read())
            {
                Resource resource = new Resource();
                resource.ResID = SafeRead<Guid>(reader, "ResID").ToString();
                resource.CnName = SafeRead<string>(reader, "CnName");
                resource.EnName = SafeRead<string>(reader, "EnName");
                resource.OtherName = SafeRead<string>(reader, "OtherName");
                resource.CategroyID = SafeRead<string>(reader, "CategroyID");
                resource.Description = SafeRead(reader, "Description", "暂无简介");
                resource.State = (ResourceState)SafeRead<long>(reader, "State");
                resource.CreateTime = SafeRead<DateTime>(reader, "CreateTime");
                resource.Creator = SafeRead(reader, "Creator", "admin");
                resource.Location = SafeRead<string>(reader, "Location");
                resource.Image = SafeRead<string>(reader, "Image");
                resource.Family = SafeRead(reader, "Family", string.Empty);
                resource.Genus = SafeRead(reader, "Genus", string.Empty);
                reslist.Add(resource);
            }

            return reslist;
        }

        public static List<ResourceCategroy> ResourceCategroyList(this SQLiteDataReader reader)
        {
            List<ResourceCategroy> cateList = new List<ResourceCategroy>();

            while (reader.Read())
            {
                ResourceCategroy cate = new ResourceCategroy();
                cate.CategroyID = SafeRead<string>(reader, "CategroyID");
                cate.CnTitle = SafeRead<string>(reader, "CnTitle");
                cate.EnTitle = SafeRead<string>(reader, "EnTitle");
                cate.CreateTime = SafeRead<DateTime>(reader, "CreateTime");
                cate.HasSubCategory = SafeRead<long>(reader, "SubCategroyCount") > 0;
                cateList.Add(cate);
            }

            return cateList;
        }

        /// <summary>
        /// 将Sqlite读取的数据转换成相应类型的数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="reader">SqliteDataReader</param>
        /// <param name="fieldName">数据库字段名称</param>
        /// <param name="defaultValue">转换失败的返回的默认值</param>
        public static T SafeRead<T>(SQLiteDataReader reader, string fieldName, T defaultValue)
        {
            try
            {
                var ordinal = reader.GetOrdinal(fieldName);
                if (reader.IsDBNull(ordinal))//if column "fieldName" doesn't exist, will throw an exception
                    return defaultValue;

                return (T)Convert.ChangeType(reader[ordinal], defaultValue.GetType());
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 将Sqlite读取的数据转换成相应类型的数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="reader">SqliteDataReader</param>
        /// <param name="fieldName">数据库字段名称</param>
        public static T SafeRead<T>(SQLiteDataReader reader, string fieldName)
        {
            var obj = reader[fieldName];
            if (obj == DBNull.Value)
                return default(T);
            return (T)obj;
        }
    }
}
