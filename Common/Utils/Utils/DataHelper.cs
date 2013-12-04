using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace ecl.Common.Comm
{
   public class DataHelper
    {
       /// <summary>
        /// IList<T> 转换成 DataTable
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="list"></param>
       /// <returns></returns>
       public static DataTable ConvertToDataTable<T>(IList<T> list)
       {
           return ConvertToDataSet<T>(list).Tables[0];
       }
       /// <summary>
       /// IList<T> 转换成 DataView
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="list"></param>
       /// <returns></returns>
       public static DataView ConvertToDataView<T>(IList<T> list)
       {
           return ConvertToDataSet<T>(list).Tables[0].DefaultView;
       }
        /// <summary>
        /// IList<T> 转换成 DataSet
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataSet ConvertToDataSet<T>(IList<T> list)
        {
            if (list == null || list.Count <= 0)
            {
                return null;
            }
            DataSet ds = new DataSet();
            DataTable dt = new DataTable(typeof(T).Name);
            DataColumn column;
            DataRow row;

            System.Reflection.PropertyInfo[] myPropertyInfo = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            foreach (T t in list)
            {
                if (t == null)
                {
                    continue;
                }

                row = dt.NewRow();

                for (int i = 0, j = myPropertyInfo.Length; i < j; i++)
                {
                    System.Reflection.PropertyInfo pi = myPropertyInfo[i];

                    string name = pi.Name;

                    if (dt.Columns[name] == null)
                    {
                        column = new DataColumn(name, pi.PropertyType);
                        dt.Columns.Add(column);
                    }

                    row[name] = pi.GetValue(t, null);
                }

                dt.Rows.Add(row);
            }

            ds.Tables.Add(dt);

            return ds;
        }
    }
}
