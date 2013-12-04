using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public class CRCer
    {
        private static System.Random _random = new Random(unchecked((int)DateTime.Now.Ticks));
        
        public static string GetCRCfromRichCRC(string RichCRC)
        {
            if (RichCRC.Length != 6)
                throw new Exception("错误的RichCRC码");

            //取标志位
            int flag = int.Parse(RichCRC.Substring(0, 1));

            //如果CRC码的长度正好是5位，则标志位为5-9之间的随机值
            if (flag >= 5 && flag <= 9)
            {
                //返回CRC码
                return RichCRC.Substring(1, 5);
            }

            //如果CRC码的长度小于5位，标志位为空缺长度（1-4）
            return RichCRC.Substring(flag + 1);

        }

        /// <summary>
        /// 完整的RichCRC码是6位的
        /// </summary>
        /// <param name="CRCCode"></param>
        /// <param name="richText"></param>
        /// <returns></returns>
        public static string Get16RichCRC(string inputText)
        {
            //获取CRC码
            string CRCCode = Get16CRC(inputText);                   


            //如果CRC码的长度正好是5位，则标志位为5-9之间的随机值
            if (CRCCode.Length == 5)
            {
                string flag = _random.Next(5, 9).ToString();
                return flag + CRCCode;
            }

            //如果CRC码的长度小于5位，则在空缺位置补上随机值，并置标志位为空缺长度（1-4）
            int blank = 5 - CRCCode.Length;

            string sblank = "";
            for (int i = 0; i < blank; i++)
            {
                sblank += _random.Next(9).ToString();
            }

            //返回完整的RichCRC码
            return blank.ToString() + sblank + CRCCode;
        }


        public static string GetRandomString(int length)
        {
            string sblank = "";
            for (int i = 0; i < length; i++)
            {
                sblank += _random.Next(9).ToString();
            }

            return sblank;
        }


        /// <summary>
        /// Get16CRC --- CRC16校验算法
        /// </summary>
        /// <param name="sbuffer"></param>
        /// <returns></returns>
        public static string Get16CRC(string sbuffer)
        {
            System.Text.UnicodeEncoding cvt = new System.Text.UnicodeEncoding();
            byte[] buffer = cvt.GetBytes(sbuffer);

            //CRC = 1111,1111,1111,1111  CRC初始值
            UInt16 CRC = 0xFFFF;

            //temp=1010,0000,0000,0001   CRC 多项式（权）
            UInt16 temp = 0xA001;

            for (int k = 0; k < buffer.Length; k++)
            {
                CRC ^= buffer[k];
                for (int i = 0; i < 8; i++)
                {
                    int j = CRC & 1;
                    CRC >>= 1;

                    //0x7FFF = 0111,1111,1111,1111
                    CRC &= 0x7FFF;
                    if (j == 1)
                        CRC ^= temp;
                }
            }
            return Convert.ToString(CRC);
        }

    }


}
