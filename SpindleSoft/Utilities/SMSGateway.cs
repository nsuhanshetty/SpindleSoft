using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpindleSoft.SMSGatewayService;
using System.Windows.Forms;
using log4net;
using SpindleSoft.Model;

namespace SpindleSoft.Utilities
{
    public class SMSGateway
    {
        private static string _userName = Secrets.SMSGatewayUserName;
        private static string _password = Secrets.SMSGatewayPassword;

        static ILog log = LogManager.GetLogger(typeof(SMSGateway));

        public static string GetSMSCount()
        {
            try
            {
                return new Service1SoapClient().FnGetSMSBalance(_userName, _password);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return "";
            }
        }

        public static string SendSMS(string message, SpindleSoft.Model.Customer customer, SMSLog.SectionType sectType, bool isScheduled = false, DateTime schedTime = new DateTime())
        {
            try
            {
                string response;
                int smsCount = 0;

                //Check if SMS Count
                if (int.TryParse(GetSMSCount(), out smsCount) && smsCount < 1)
                {
                    MessageBox.Show("Insufficient SMS in the Wallet, Contact Technical Assistance to Recharge", "Insufficient SMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return "Insufficient SMS in the Wallet";
                }

                //Send SMS
                if (isScheduled)
                    response = new Service1SoapClient().FnSendScheduledSMS(_userName, "SMSMSG", _password, message, customer.Mobile_No, schedTime.ToString("yyyy/MM/dd HH:mm:ss"));
                else
                    response = new Service1SoapClient().FnSendSMS(_userName, "SMSMSG", _password, message, customer.Mobile_No);

                //todo: get status enum replace "SMS not sent".
                Savers.SMSSaver.SaveSMSLog(new Model.SMSLog(customer, message, sectType, response.Contains("402") ? "SMS Sent" : "Error Ocurred while sending SMS."));

                //Warn if sms count less than reserve
                if (int.TryParse(GetSMSCount(), out smsCount) && smsCount < 50)
                {
                    MessageBox.Show("SMS in the Wallet below Reserve (" + smsCount + "), Contact Technical Assitance to Recharge", "Recharge SMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return response.Contains("402") ? "SMS Sent" : response;
            }
            catch (System.ServiceModel.EndpointNotFoundException endPointEx)
            {
                log.Error(endPointEx);
                System.Windows.Forms.MessageBox.Show("Oops, Error occured in SMS Gateway. Check if Internet is Connected.");
                return "";
            }
            catch (Exception ex)
            {
                log.Error(ex);
                System.Windows.Forms.MessageBox.Show("Oops, Error occured in SMS Gateway. Contact Technical Assistance if error persists.");
                return "";
            }
        }

        public static List<SMSLog> SendBulkSMS(string message, List<SpindleSoft.Model.Customer> customerList)
        {
            List<SMSLog> smsLogList = new List<SMSLog>();
            try
            {
                string response;
                int smsCount = 0;

                //Check if SMS Count
                if (int.TryParse(GetSMSCount(), out smsCount) && smsCount < customerList.Count)
                {
                    MessageBox.Show("Insufficient SMS in the Wallet, Contact Technical Assistance to Recharge", "Insufficient SMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                //Send SMS
                foreach (var cust in customerList)
                {
                    response = new Service1SoapClient().FnSendSMS(_userName, "SMSMSG", _password, message, cust.Mobile_No);
                    //todo: get status enum replace "SMS not sent".
                    var smsLog = new Model.SMSLog(cust, message, SMSLog.SectionType.Customer, response.Contains("402") ? "SMS Sent" : "Error Ocurred while sending SMS.");
                    Savers.SMSSaver.SaveSMSLog(smsLog);
                    smsLogList.Add(smsLog);
                }

                //Warn if sms count less than reserve
                if (int.TryParse(GetSMSCount(), out smsCount) && smsCount < 50)
                {
                    MessageBox.Show("SMS in the Wallet below Reserve (" + smsCount + "), Contact Technical Assitance to Recharge", "Recharge SMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                return smsLogList;
            }
            catch (System.ServiceModel.EndpointNotFoundException endPointEx)
            {
                log.Error(endPointEx);
                System.Windows.Forms.MessageBox.Show("Oops, Error occured in SMS Gateway. Check if Internet is Connected.");
                return null;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                System.Windows.Forms.MessageBox.Show("Oops, Error occured in SMS Gateway. Contact Technical Assistance if error persists.");
                return null;
            }
        }
    }
}
