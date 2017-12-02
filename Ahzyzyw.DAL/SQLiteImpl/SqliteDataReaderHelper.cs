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
        public static News ToNews(this SQLiteDataReader reader)
        {
            if (reader.Read())
            {
                News news = new News();
                news.NewsId = SafeRead<Guid>(reader, "ID").ToString();
                news.PublishTime = SafeRead<DateTime>(reader, "PublishTime");
                news.CreateTime = SafeRead<DateTime>(reader, "PublishTime");
                news.Title = SafeRead<string>(reader, "Title");
                news.Content = SafeRead<string>(reader, "Content");
                return news;
            }

            return null;
        }

        public static List<News> ToNewsList(this SQLiteDataReader reader)
        {
            List<News> newsList = new List<News>();
            while (reader.Read())
            {
                News news = new News();
                news.NewsId = SafeRead<Guid>(reader, "ID").ToString();
                news.PublishTime = SafeRead<DateTime>(reader, "PublishTime");
                news.CreateTime = SafeRead<DateTime>(reader, "PublishTime");
                news.Title = SafeRead<string>(reader, "Title");
                newsList.Add(news);
            }

            return newsList;
        }

        public static Resource ToResource(this SQLiteDataReader reader)
        {
            if (reader.Read())
            {
                Resource resource = new Resource();
                resource.ResID = SafeRead<Guid>(reader, "ResID").ToString();
                resource.CnName = SafeRead<string>(reader, "CnName");
                resource.EnName = SafeRead<string>(reader, "EnName");
                resource.OtherName = SafeRead<string>(reader, "OtherName");
                resource.CategoryID = SafeRead<string>(reader, "CategoryID");
                resource.Description = SafeRead(reader, "Description", "暂无简介");
                resource.State = (ResourceState)SafeRead<long>(reader, "State");
                resource.CreateTime = SafeRead<DateTime>(reader, "CreateTime");
                resource.Creator = SafeRead(reader, "Creator", "admin");
                resource.Location = SafeRead<string>(reader, "Location");
                resource.Image = SafeRead<string>(reader, "Image");
                resource.Family = SafeRead(reader, "Family", SafeRead(reader, "GenFamily", string.Empty));
                resource.Genus = SafeRead(reader, "Genus", SafeRead(reader, "GenGenus", string.Empty));
                return resource;
            }

            return null;
        }

        public static DigitalResource ToDigitalResource(this SQLiteDataReader reader)
        {
            if (reader.Read())
            {
                DigitalResource resource = new DigitalResource();
                resource.ResID = SafeRead<Guid>(reader, "ResID").ToString();
                resource.CnName = SafeRead<string>(reader, "CnName");
                resource.OtherName = SafeRead<string>(reader, "OtherName");
                resource.Description = SafeRead(reader, "Description", "暂无简介");
                resource.CreateTime = SafeRead<DateTime>(reader, "CreateTime");
                resource.Creator = SafeRead(reader, "Creator", "admin");
                resource.Image = SafeRead<string>(reader, "Image");
                resource.PlantImage = SafeRead<string>(reader, "PlantImage");
                var fakeImage = SafeRead<string>(reader, "FakeImage");
                resource.FakePicList = fakeImage == null ? new List<string>() : new List<string>(fakeImage.Split(new char[] { '#' }));

                return resource;
            }

            return null;
        }

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
                resource.CategoryID = SafeRead<string>(reader, "CategoryID");
                resource.Description = SafeRead(reader, "Description", "暂无简介");
                resource.State = (ResourceState)SafeRead<long>(reader, "State");
                resource.CreateTime = SafeRead<DateTime>(reader, "CreateTime");
                resource.Creator = SafeRead(reader, "Creator", "admin");
                resource.Location = SafeRead<string>(reader, "Location");
                resource.Image = SafeRead<string>(reader, "Image");
                resource.Family = SafeRead(reader, "Family", SafeRead(reader, "GenFamily", string.Empty));
                resource.Genus = SafeRead(reader, "Genus", SafeRead(reader, "GenGenus", string.Empty));
                reslist.Add(resource);
            }

            return reslist;
        }

        public static List<DigitalResource> ToDigitalResourceList(this SQLiteDataReader reader)
        {
            List<DigitalResource> reslist = new List<DigitalResource>();
            while (reader.Read())
            {
                DigitalResource resource = new DigitalResource();
                resource.ResID = SafeRead<Guid>(reader, "ResID").ToString();
                resource.CnName = SafeRead<string>(reader, "CnName");
                resource.OtherName = SafeRead<string>(reader, "OtherName");
                resource.Description = SafeRead(reader, "Description", "暂无简介");
                resource.CreateTime = SafeRead<DateTime>(reader, "CreateTime");
                resource.Creator = SafeRead(reader, "Creator", "admin");
                resource.Image = SafeRead<string>(reader, "Image");
                resource.PlantImage = SafeRead<string>(reader, "PlantImage");
                var fakeImage = SafeRead<string>(reader, "FakeImage");
                resource.FakePicList = fakeImage == null ? new List<string>() : new List<string>(fakeImage.Split(new char[] { '#' }));
                reslist.Add(resource);
            }

            return reslist;
        }

        public static List<ResourceCategory> ResourceCategoryList(this SQLiteDataReader reader)
        {
            List<ResourceCategory> cateList = new List<ResourceCategory>();

            while (reader.Read())
            {
                ResourceCategory cate = new ResourceCategory();
                cate.CategoryID = SafeRead<string>(reader, "CategoryID");
                cate.CnTitle = SafeRead<string>(reader, "CnTitle");
                cate.EnTitle = SafeRead<string>(reader, "EnTitle");
                cate.CreateTime = SafeRead<DateTime>(reader, "CreateTime");
                cate.HasSubCategory = SafeRead<long>(reader, "SubCategoryCount") > 0;
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
