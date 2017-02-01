//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Net.Mail;
//using System.Diagnostics;

//namespace CriminalDB.WcfService.Helpers
//{
//    public class MailUtil
//    {
//        public void SendResultsAsEmails(string emailAddress, List<string> files)
//        {
//            int i = 0;
//            while (i < files.Count)
//            {
//                int count = (files.Count - i > 10 ? 10 : files.Count - i);
//                List<string> filesToSend = files.Skip(i).Take(count).ToList();
//                Send(emailAddress, filesToSend);
//                i += count;
//            }
//        }

//        private void Send(string emailAddress, List<string> files)
//        {
//            using (SmtpClient client = new SmtpClient())
//            {
//                using (MailMessage message = new MailMessage())
//                {
//                    message.To.Add(emailAddress);
//                    message.IsBodyHtml = true;
//                    message.Subject = "Star Screening - National Criminal Database Search Results";
//                    message.Body = "<p>Dear Customer,<br/><br/>Please find the national criminal database search results here with.<br/><br/> Thank You!<br/><br/> Best Regards,<br/>Star Screening Team</p>";
//                    foreach (var file in files)
//                    {
//                        Attachment attachment = new Attachment(file);
//                        message.Attachments.Add(attachment);
//                    }
//                    try
//                    {
//                        client.Send(message);
//                    }
//                    catch (SmtpException e)
//                    {
//                        Trace.TraceError($"[MailUtil][Send]: {e.Message}");
//                    }
//                }
//            }
//        }
//    }
//}