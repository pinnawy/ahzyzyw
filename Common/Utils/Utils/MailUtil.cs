using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace ElpMaster.Common.Utils
{
    public class MailUtil
    {   
        /// <summary>
        /// 发送普通文本电子邮件
        /// </summary>
        /// <param name="fromAddress">发信人邮箱</param>
        /// <param name="fromName">发信人名称</param>
        /// <param name="password">发信人邮箱密码</param>
        /// <param name="fromHost">发信人邮箱服务器</param>
        /// <param name="toAddress">收件人邮箱</param>
        /// <param name="subject">主题</param>
        /// <param name="content">邮件正文</param>
        static public void SendMail(string fromAddress, string fromName, string password, string fromHost, string toAddress,string subject, string content)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(fromAddress, fromName, Encoding.UTF8);
            mail.To.Add(toAddress);
            mail.Subject = subject;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = content;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = false;
            mail.Priority = MailPriority.Normal;

            SmtpClient client = new SmtpClient();
            client.Host = fromHost;
            client.Port = 25;
            client.Credentials = new System.Net.NetworkCredential(fromAddress, password);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = false;
            client.Send(mail);
        }
    }
}
