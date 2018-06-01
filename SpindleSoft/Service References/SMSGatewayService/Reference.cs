﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SpindleSoft.SMSGatewayService {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SMSGatewayService.Service1Soap")]
    public interface Service1Soap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FnGetStatus", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string FnGetStatus(string tokenno, string ResUUID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FnGetStatus", ReplyAction="*")]
        System.Threading.Tasks.Task<string> FnGetStatusAsync(string tokenno, string ResUUID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FnSendSMS", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string FnSendSMS(string userid, string sender, string password, string message, string mobilenos);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FnSendSMS", ReplyAction="*")]
        System.Threading.Tasks.Task<string> FnSendSMSAsync(string userid, string sender, string password, string message, string mobilenos);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FnSendScheduledSMS", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string FnSendScheduledSMS(string userid, string sender, string password, string message, string mobilenos, string scheduledOn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FnSendScheduledSMS", ReplyAction="*")]
        System.Threading.Tasks.Task<string> FnSendScheduledSMSAsync(string userid, string sender, string password, string message, string mobilenos, string scheduledOn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FnGetSMSBalance", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string FnGetSMSBalance(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FnGetSMSBalance", ReplyAction="*")]
        System.Threading.Tasks.Task<string> FnGetSMSBalanceAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FnGetSMSSentCount", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string FnGetSMSSentCount(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FnGetSMSSentCount", ReplyAction="*")]
        System.Threading.Tasks.Task<string> FnGetSMSSentCountAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetMainAccountBalance", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetMainAccountBalance(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetMainAccountBalance", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetMainAccountBalanceAsync(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FnGetSMSHistory", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet FnGetSMSHistory(int maxrecords, string username, string password, string mobile, string message, string sentfrom, string sentto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FnGetSMSHistory", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> FnGetSMSHistoryAsync(int maxrecords, string username, string password, string mobile, string message, string sentfrom, string sentto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FnGetSMSHistoryNew", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet FnGetSMSHistoryNew(int maxrecords, string username, string password, string mobile, string message, string sentfrom, string sentto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FnGetSMSHistoryNew", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> FnGetSMSHistoryNewAsync(int maxrecords, string username, string password, string mobile, string message, string sentfrom, string sentto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MyFnGetReport", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable MyFnGetReport(string SMSJobId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MyFnGetReport", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> MyFnGetReportAsync(string SMSJobId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface Service1SoapChannel : SpindleSoft.SMSGatewayService.Service1Soap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1SoapClient : System.ServiceModel.ClientBase<SpindleSoft.SMSGatewayService.Service1Soap>, SpindleSoft.SMSGatewayService.Service1Soap {
        
        public Service1SoapClient() {
        }
        
        public Service1SoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1SoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1SoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1SoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string FnGetStatus(string tokenno, string ResUUID) {
            return base.Channel.FnGetStatus(tokenno, ResUUID);
        }
        
        public System.Threading.Tasks.Task<string> FnGetStatusAsync(string tokenno, string ResUUID) {
            return base.Channel.FnGetStatusAsync(tokenno, ResUUID);
        }
        
        public string FnSendSMS(string userid, string sender, string password, string message, string mobilenos) {
            return base.Channel.FnSendSMS(userid, sender, password, message, mobilenos);
        }
        
        public System.Threading.Tasks.Task<string> FnSendSMSAsync(string userid, string sender, string password, string message, string mobilenos) {
            return base.Channel.FnSendSMSAsync(userid, sender, password, message, mobilenos);
        }
        
        public string FnSendScheduledSMS(string userid, string sender, string password, string message, string mobilenos, string scheduledOn) {
            return base.Channel.FnSendScheduledSMS(userid, sender, password, message, mobilenos, scheduledOn);
        }
        
        public System.Threading.Tasks.Task<string> FnSendScheduledSMSAsync(string userid, string sender, string password, string message, string mobilenos, string scheduledOn) {
            return base.Channel.FnSendScheduledSMSAsync(userid, sender, password, message, mobilenos, scheduledOn);
        }
        
        public string FnGetSMSBalance(string username, string password) {
            return base.Channel.FnGetSMSBalance(username, password);
        }
        
        public System.Threading.Tasks.Task<string> FnGetSMSBalanceAsync(string username, string password) {
            return base.Channel.FnGetSMSBalanceAsync(username, password);
        }
        
        public string FnGetSMSSentCount(string username, string password) {
            return base.Channel.FnGetSMSSentCount(username, password);
        }
        
        public System.Threading.Tasks.Task<string> FnGetSMSSentCountAsync(string username, string password) {
            return base.Channel.FnGetSMSSentCountAsync(username, password);
        }
        
        public string GetMainAccountBalance(string token) {
            return base.Channel.GetMainAccountBalance(token);
        }
        
        public System.Threading.Tasks.Task<string> GetMainAccountBalanceAsync(string token) {
            return base.Channel.GetMainAccountBalanceAsync(token);
        }
        
        public System.Data.DataSet FnGetSMSHistory(int maxrecords, string username, string password, string mobile, string message, string sentfrom, string sentto) {
            return base.Channel.FnGetSMSHistory(maxrecords, username, password, mobile, message, sentfrom, sentto);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> FnGetSMSHistoryAsync(int maxrecords, string username, string password, string mobile, string message, string sentfrom, string sentto) {
            return base.Channel.FnGetSMSHistoryAsync(maxrecords, username, password, mobile, message, sentfrom, sentto);
        }
        
        public System.Data.DataSet FnGetSMSHistoryNew(int maxrecords, string username, string password, string mobile, string message, string sentfrom, string sentto) {
            return base.Channel.FnGetSMSHistoryNew(maxrecords, username, password, mobile, message, sentfrom, sentto);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> FnGetSMSHistoryNewAsync(int maxrecords, string username, string password, string mobile, string message, string sentfrom, string sentto) {
            return base.Channel.FnGetSMSHistoryNewAsync(maxrecords, username, password, mobile, message, sentfrom, sentto);
        }
        
        public System.Data.DataTable MyFnGetReport(string SMSJobId) {
            return base.Channel.MyFnGetReport(SMSJobId);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> MyFnGetReportAsync(string SMSJobId) {
            return base.Channel.MyFnGetReportAsync(SMSJobId);
        }
    }
}