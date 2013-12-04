using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Utils
{
    /// <summary>
    /// 自定义序列化类
    /// 详见: ms-help://MS.MSDNQTR.v90.chs/fxref_mscorlib/html/8596f308-b593-d44a-4f16-420430e21302.htm
    ///  08/9/23 created by jhwang
    /// </summary>
    public static class BinarySerializeHelper
    {
        public static void Serialize(object obj, SerializationInfo info, StreamingContext context)
        {
            // 获取指定类的所有可序列化成员
            Type thisType = obj.GetType();
            MemberInfo[] mi = FormatterServices.GetSerializableMembers(thisType, context);

            // Serialize the base class's fields to the info object.
            for (Int32 i = 0; i < mi.Length; i++)
            {
                // Skip this field if it is marked NonSerialized.
                if (Attribute.IsDefined(mi[i], typeof(NonSerializedAttribute))) continue;

                // Get the value of this field and add it to the SerializationInfo object.
                info.AddValue(mi[i].Name, ((FieldInfo)mi[i]).GetValue(obj));
            }
        }
        public static void Deserialize(object obj, SerializationInfo info, StreamingContext context)
        {
            Type thisType = obj.GetType();
            MemberInfo[] mi = FormatterServices.GetSerializableMembers(thisType, context);

            // 反序列化对象
            for (Int32 i = 0; i < mi.Length; i++)
            {
                // For easier coding, treat the member as a FieldInfo object
                FieldInfo fi = (FieldInfo)mi[i];

                // Skip this field if it is marked NonSerialized.
                if (Attribute.IsDefined(mi[i], typeof(NonSerializedAttribute))) continue;

                // Get the value of this field from the SerializationInfo object.
                fi.SetValue(obj, info.GetValue(fi.Name, fi.FieldType));
            }
        }

        /// <summary>
        /// 序列化为byte[],可用FromByteArr反序列化
        /// </summary>
        public static byte[] ToByteArr(this object obj)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, obj);

            byte[] arr = ms.ToArray();
            return arr;
        }

        /// <summary>
        /// 反序列byte[]为对象(用ToByteArr方法序列化)
        /// </summary>
        public static T FromByteArr<T>(this byte[] byteArr)
        {
            try
            {
                MemoryStream br = new MemoryStream(byteArr);
                BinaryFormatter bf = new BinaryFormatter();
                object o = bf.Deserialize(br);
                return (T)o;
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// 深拷贝对象
        /// </summary>
        public static T Copy<T>(T obj)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, obj);
            ms.Seek(0, SeekOrigin.Begin);
            T memObj = (T)bf.Deserialize(ms);
            return memObj;
        }
    }
}
