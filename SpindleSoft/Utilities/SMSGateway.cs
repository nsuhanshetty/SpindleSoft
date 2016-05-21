using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpindleSoft.SMSGatewayService;
using System.Windows.Forms;
using log4net;

namespace SpindleSoft.Utilities
{
    public class SMSGateway
    {
        private static string _userName = Secrets.SMSGatewayUserName;
        private static string _password = Secrets.SMSGatewayPassword;

        static ILog log = LogManager.GetLogger(typeof(SMSGateway));

        public static async Task<string> GetSMSCount()
        {
            try
            {
                return await new Service1SoapClient().FnGetSMSBalanceAsync(_userName, _password);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return "";
            }
        }

        public static async Task<string> SendSMS(string message, SpindleSoft.Model.Customer customer, int sectionID, bool isScheduled = false, DateTime schedTime = new DateTime())
        {
            try
            {
                string response;
                int smsCount = 0;

                //Check if SMS Count
                if (int.TryParse(await GetSMSCount(), out smsCount) && smsCount < 1)
                {
                    MessageBox.Show("Insufficient SMS in the Wallet, Contact Technical Assistance to Recharge", "Insufficient SMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return "Insufficient SMS in the Wallet";
                }

                //Send SMS
                if (isScheduled)
                    response = await new Service1SoapClient().FnSendScheduledSMSAsync(_userName, "SMSMSG", _password, message, customer.Mobile_No, schedTime.ToString("yyyy/MM/dd HH:mm:ss"));
                else
                    response = await new Service1SoapClient().FnSendSMSAsync(_userName, "SMSMSG", _password, message, customer.Mobile_No);

                Savers.SMSSaver.SaveSMSLog(new Model.SMSLog(customer, message, sectionID, response));

                //Warn if sms count less than reserve
                if (int.TryParse(await GetSMSCount(), out smsCount) && smsCount < 50)
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
    }
}
