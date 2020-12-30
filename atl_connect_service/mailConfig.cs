using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace atl_connect_service
{
    public class mailconfig
    {
        public string smtphost = "10.206.100.111", fromaddress = "it-alert@islandroutes.com", smtppassword = "k33p1ts1mpl3@", smtpusername = "it-alert";
        public int smtpport, configid;


        public mailconfig()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void init()
        {
           
        }
        public int sendMail(string subject, string message, string toAddress)
        {
            int result = 0;

            System.Threading.Thread sendthread = new System.Threading.Thread(() => sendMailThread(subject, message, toAddress));
            sendthread.Start();

            return result;
        }
        public int sendMailCC(string subject, string message, string toAddress)
        {
            int result = 0;

            System.Threading.Thread sendthread = new System.Threading.Thread(() => sendMailThreadCC(subject, message, toAddress));
            sendthread.Start();

            return result;
        }

        protected void sendMailThreadCC(string subject, string message, string toAddress)
        {



            System.Net.Mail.MailMessage Message = new System.Net.Mail.MailMessage();
            SmtpClient smtpClient = new SmtpClient(smtphost, smtpport);
            System.Net.NetworkCredential creds = new NetworkCredential(smtpusername, smtppassword);

            if (toAddress != "")
            {
                Message.From = new MailAddress(fromaddress, "IRAT HR");
                Message.To.Add(new MailAddress(toAddress));

               
                Message.IsBodyHtml = true;
                smtpClient.EnableSsl = false;
                smtpClient.Port = smtpport;
                Message.Subject = subject;
                Message.Body = "<font style='font-family:arial;font-size:10pt'>";
                Message.Body += message;
                Message.Body += "</font>";

                smtpClient.Credentials = creds;

                smtpClient.Send(Message);
            }
        }

        protected void sendMailThread(string subject, string message, string toAddress)
        {
            fromaddress = "hr@atlautomotive.com";
            smtphost = "10.236.56.112";
            smtppassword = "Godz4ever";
            smtpusername = "rdeokoro";

            fromaddress = "no-reply@islandroutes.com";
            smtphost = "10.206.100.111";
            smtppassword = "Godz4ever";
            smtpusername = "roghe.deokoro";

            smtpport = 25;
            try
            {
                System.Net.Mail.MailMessage Message = new System.Net.Mail.MailMessage();
                SmtpClient smtpClient = new SmtpClient(smtphost, smtpport);
                System.Net.NetworkCredential creds = new NetworkCredential(smtpusername, smtppassword);

                if (toAddress != "")
                {
                    Message.From = new MailAddress(fromaddress, "IRAT HR");
                    Message.To.Add(new MailAddress(toAddress));

                    //  foreach (User emp in User.hrUsers())
                    // {
                    //     if (emp.associatedEmployee.emailwork != "")
                    //         Message.CC.Add(emp.associatedEmployee.emailwork);
                    // }

                    Message.IsBodyHtml = true;
                    smtpClient.EnableSsl = false;
                    smtpClient.Port = smtpport;
                    Message.Subject = subject;
                    Message.Body = "<font style='font-family:arial;font-size:10pt'>";
                    Message.Body += message;
                    Message.Body += "</font>";

                    smtpClient.Credentials = creds;

                    smtpClient.Send(Message);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public int saveMailconfig(mailconfig config)
        {
            int configID = 0;
            SqlCommand cmd = new SqlCommand();
            try
            {
               

            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred:" + ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }

            return configID;
        }



    }
}
