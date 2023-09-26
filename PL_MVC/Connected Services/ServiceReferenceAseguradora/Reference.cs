﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PL_MVC.ServiceReferenceAseguradora {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Result", Namespace="http://schemas.datacontract.org/2004/07/SLWCF")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Aseguradora))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Usuario))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Direccion))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Colonia))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Municipio))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Estado))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Pais))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Rol))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Exception))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(object[]))]
    public partial class Result : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool CorrectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Exception ExField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object ObjectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object[] ObjectsField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Correct {
            get {
                return this.CorrectField;
            }
            set {
                if ((this.CorrectField.Equals(value) != true)) {
                    this.CorrectField = value;
                    this.RaisePropertyChanged("Correct");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Exception Ex {
            get {
                return this.ExField;
            }
            set {
                if ((object.ReferenceEquals(this.ExField, value) != true)) {
                    this.ExField = value;
                    this.RaisePropertyChanged("Ex");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object Object {
            get {
                return this.ObjectField;
            }
            set {
                if ((object.ReferenceEquals(this.ObjectField, value) != true)) {
                    this.ObjectField = value;
                    this.RaisePropertyChanged("Object");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object[] Objects {
            get {
                return this.ObjectsField;
            }
            set {
                if ((object.ReferenceEquals(this.ObjectsField, value) != true)) {
                    this.ObjectsField = value;
                    this.RaisePropertyChanged("Objects");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceAseguradora.IAseguradoraService")]
    public interface IAseguradoraService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAseguradoraService/Add", ReplyAction="http://tempuri.org/IAseguradoraService/AddResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PL_MVC.ServiceReferenceAseguradora.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Usuario))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Direccion))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Colonia))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Municipio))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Estado))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Pais))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Rol))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        PL_MVC.ServiceReferenceAseguradora.Result Add(ML.Aseguradora aseguradora);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAseguradoraService/Add", ReplyAction="http://tempuri.org/IAseguradoraService/AddResponse")]
        System.Threading.Tasks.Task<PL_MVC.ServiceReferenceAseguradora.Result> AddAsync(ML.Aseguradora aseguradora);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAseguradoraService/Update", ReplyAction="http://tempuri.org/IAseguradoraService/UpdateResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PL_MVC.ServiceReferenceAseguradora.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Usuario))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Direccion))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Colonia))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Municipio))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Estado))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Pais))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Rol))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        PL_MVC.ServiceReferenceAseguradora.Result Update(ML.Aseguradora aseguradora);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAseguradoraService/Update", ReplyAction="http://tempuri.org/IAseguradoraService/UpdateResponse")]
        System.Threading.Tasks.Task<PL_MVC.ServiceReferenceAseguradora.Result> UpdateAsync(ML.Aseguradora aseguradora);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAseguradoraService/Delete", ReplyAction="http://tempuri.org/IAseguradoraService/DeleteResponse")]
        PL_MVC.ServiceReferenceAseguradora.Result Delete(int idAseguradora);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAseguradoraService/Delete", ReplyAction="http://tempuri.org/IAseguradoraService/DeleteResponse")]
        System.Threading.Tasks.Task<PL_MVC.ServiceReferenceAseguradora.Result> DeleteAsync(int idAseguradora);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAseguradoraService/GetAll", ReplyAction="http://tempuri.org/IAseguradoraService/GetAllResponse")]
        PL_MVC.ServiceReferenceAseguradora.Result GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAseguradoraService/GetAll", ReplyAction="http://tempuri.org/IAseguradoraService/GetAllResponse")]
        System.Threading.Tasks.Task<PL_MVC.ServiceReferenceAseguradora.Result> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAseguradoraService/GetById", ReplyAction="http://tempuri.org/IAseguradoraService/GetByIdResponse")]
        PL_MVC.ServiceReferenceAseguradora.Result GetById(int idAseguradora);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAseguradoraService/GetById", ReplyAction="http://tempuri.org/IAseguradoraService/GetByIdResponse")]
        System.Threading.Tasks.Task<PL_MVC.ServiceReferenceAseguradora.Result> GetByIdAsync(int idAseguradora);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAseguradoraServiceChannel : PL_MVC.ServiceReferenceAseguradora.IAseguradoraService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AseguradoraServiceClient : System.ServiceModel.ClientBase<PL_MVC.ServiceReferenceAseguradora.IAseguradoraService>, PL_MVC.ServiceReferenceAseguradora.IAseguradoraService {
        
        public AseguradoraServiceClient() {
        }
        
        public AseguradoraServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AseguradoraServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AseguradoraServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AseguradoraServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public PL_MVC.ServiceReferenceAseguradora.Result Add(ML.Aseguradora aseguradora) {
            return base.Channel.Add(aseguradora);
        }
        
        public System.Threading.Tasks.Task<PL_MVC.ServiceReferenceAseguradora.Result> AddAsync(ML.Aseguradora aseguradora) {
            return base.Channel.AddAsync(aseguradora);
        }
        
        public PL_MVC.ServiceReferenceAseguradora.Result Update(ML.Aseguradora aseguradora) {
            return base.Channel.Update(aseguradora);
        }
        
        public System.Threading.Tasks.Task<PL_MVC.ServiceReferenceAseguradora.Result> UpdateAsync(ML.Aseguradora aseguradora) {
            return base.Channel.UpdateAsync(aseguradora);
        }
        
        public PL_MVC.ServiceReferenceAseguradora.Result Delete(int idAseguradora) {
            return base.Channel.Delete(idAseguradora);
        }
        
        public System.Threading.Tasks.Task<PL_MVC.ServiceReferenceAseguradora.Result> DeleteAsync(int idAseguradora) {
            return base.Channel.DeleteAsync(idAseguradora);
        }
        
        public PL_MVC.ServiceReferenceAseguradora.Result GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<PL_MVC.ServiceReferenceAseguradora.Result> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public PL_MVC.ServiceReferenceAseguradora.Result GetById(int idAseguradora) {
            return base.Channel.GetById(idAseguradora);
        }
        
        public System.Threading.Tasks.Task<PL_MVC.ServiceReferenceAseguradora.Result> GetByIdAsync(int idAseguradora) {
            return base.Channel.GetByIdAsync(idAseguradora);
        }
    }
}