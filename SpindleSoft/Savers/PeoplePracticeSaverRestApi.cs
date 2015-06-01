using Newtonsoft.Json;
using SpindleSoft.Model;
using SpindleSoft.Savers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpindleSoft.Builders
{
    class PeoplePracticeSaverRestApi
    {
       private static Uri BaseUri = new Uri("http://192.168.0.104:14041");
        //private static Uri BaseUri = new Uri(System.Configuration.ConfigurationManager.AppSettings.Get("BaseUri"));

        #region Customer
        public static bool SaveCustomerInfoRestApi(Customer _customer)
        {
            var json = JsonConvert.SerializeObject(_customer);
            HttpWebRequest _request = HttpWebRequest.CreateHttp(new Uri(BaseUri, "customer/save"));
            _request.ContentType = "application/json";
            _request.Method = "POST";
            try
            {
                using (StreamWriter _swriter = new StreamWriter(_request.GetRequestStream()))
                {
                    //todo: add async/awit in order to catch errors.
                    _swriter.WriteAsync(json);
                }

                using (var _webResponse = (HttpWebResponse)_request.GetResponse())
                {
                    return (_webResponse.StatusCode == HttpStatusCode.Created) ? true : false;
                }
            }
            catch (WebException ex)
            {
                //todo: log in log4net
                Logger.Error(ex);
                return false;
            }
        }

        public static bool SaveCustomerImage(Image _image, string mobile_no)
        {
            byte[] _imageByte = (byte[])new ImageConverter().ConvertTo(_image, typeof(byte[]));

            //todo: Check if Server Or Client error and let customer know abt it.
            //todo: Akash : Use customer id instead of mobile no
            //todo: image updation failing
            try
            {
                //todo: try to implement using restSharp
                Uri _uri = new Uri(BaseUri, "customer/upload/image");

                //todo: make following codes inline
                Dictionary<string, object> _postParameters = new Dictionary<string, object>();
                _postParameters.Add("file", new FormUpload.FileParameter(_imageByte));
                _postParameters.Add("mobile", mobile_no);

                HttpWebResponse webResponse = FormUpload.MultipartFormDataPost(_uri.ToString(), "someone", _postParameters);

                // Process response
                StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
                string fullResponse = responseReader.ReadToEnd();
                webResponse.Close();

                //todo : Akash : Send response with ack for adding image
                //todo : Based on the ack we need to return success
                return true;
            }
            catch (WebException ex)
            {
                //todo: log in log4net
                return false;
            }
        }
        #endregion Customer

        #region Staff
        //todo : use async/await
        public static bool SaveStaffInfo(Staff _staff)
        {
            var json = JsonConvert.SerializeObject(_staff);
            HttpWebRequest _request = HttpWebRequest.CreateHttp(new Uri(BaseUri, "staff/save"));
            _request.ContentType = "application/json";
            _request.Method = "POST";
            try
            {
                using (StreamWriter _swriter = new StreamWriter(_request.GetRequestStream()))
                {
                    _swriter.WriteAsync(json);
                }

                using (var _webResponse = (HttpWebResponse)_request.GetResponse())
                {
                    return (_webResponse.StatusCode == HttpStatusCode.Created) ? true : false;
                }
            }
            catch (WebException ex)
            {
                //todo: log in log4net
                Logger.Error(ex);
                return false;
            }
        }

        public static bool SaveStaffImage(Image _image, string mobile_no)
        {
            byte[] _imageByte = (byte[])new ImageConverter().ConvertTo(_image, typeof(byte[]));

            //todo: Check its Server Or Client error and let customer know abt it.
            //todo: Akash : Use customer id instead of mobile no
            //todo: image updation failing
            //todo: use async and await
            try
            {
                //todo: try to implement using restSharp
                Uri _uri = new Uri(BaseUri, "staff/upload/image");

                //todo: make following codes inline
                //todo:Akash: use StaffID as primary Key
                Dictionary<string, object> _postParameters = new Dictionary<string, object>();
                _postParameters.Add("file", new FormUpload.FileParameter(_imageByte));
                _postParameters.Add("mobile", mobile_no);
                //_postParameters.Add("StaffID", ID);

                HttpWebResponse webResponse = FormUpload.MultipartFormDataPost(_uri.ToString(), "someone", _postParameters);

                // Process response
                StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
                string fullResponse = responseReader.ReadToEnd();
                webResponse.Close();

                //todo : Akash : Send response with ack for adding image
                //todo : Based on the ack we need to return success
                return true;
            }
            catch (WebException ex)
            {
                //todo: log in log4net
                return false;
            }
        }
        #endregion Staff
    }
}
