﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp_A6.NewsAndWord {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="NewsAndWord.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/NewsFocus", ReplyAction="http://tempuri.org/IService1/NewsFocusResponse")]
        string NewsFocus(string query);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/NewsFocus", ReplyAction="http://tempuri.org/IService1/NewsFocusResponse")]
        System.Threading.Tasks.Task<string> NewsFocusAsync(string query);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/WordCount", ReplyAction="http://tempuri.org/IService1/WordCountResponse")]
        string WordCount(string filepath);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/WordCount", ReplyAction="http://tempuri.org/IService1/WordCountResponse")]
        System.Threading.Tasks.Task<string> WordCountAsync(string filepath);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : WebApp_A6.NewsAndWord.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<WebApp_A6.NewsAndWord.IService1>, WebApp_A6.NewsAndWord.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string NewsFocus(string query) {
            return base.Channel.NewsFocus(query);
        }
        
        public System.Threading.Tasks.Task<string> NewsFocusAsync(string query) {
            return base.Channel.NewsFocusAsync(query);
        }
        
        public string WordCount(string filepath) {
            return base.Channel.WordCount(filepath);
        }
        
        public System.Threading.Tasks.Task<string> WordCountAsync(string filepath) {
            return base.Channel.WordCountAsync(filepath);
        }
    }
}