using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Server
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
