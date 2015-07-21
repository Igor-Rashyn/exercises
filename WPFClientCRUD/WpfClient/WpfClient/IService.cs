using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace WpfClient
{
    [ServiceContract]
    interface IService
    {
        [OperationContract]
        string GetData(string value);
        [OperationContract]
        void DeletePerson(string value);
        [OperationContract]
        void InsertPerson(string value);
        [OperationContract]
        void UpdatePerson(int id, string value);
    }
}
