using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MULEWcfServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        String checkLogin(String username);

        [OperationContract]
        List<String> getGroups(String username);

        [OperationContract]
        bool uploadPosts(DataPost dp);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "MULEWcfServiceLibrary.ContractType".

    [DataContract]
    public class DataPost
    {
        [DataMember]
        public int sensor { get; set; }
        [DataMember]
        public String description { get; set; }

        [DataMember]
        public String group_name { get; set; }
        [DataMember]
        public String user_name { get; set; }

        [DataMember]
        public String serial { get; set; }
        [DataMember]
        public String dataType { get; set; }
        [DataMember]
        public String metaData { get; set; }
        [DataMember]
        public float sem { get; set; }
        [DataMember]
        public float sd { get; set; }
        [DataMember]
        public float avg { get; set; }
        [DataMember]
        public int[] detailsValues { get; set; }
        [DataMember]
        public float northings { get; set; }
        [DataMember]
        public float eastings { get; set; }
        [DataMember]
        public float depth { get; set; }
        [DataMember]
        public String datetime { get; set; }
    }


    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
