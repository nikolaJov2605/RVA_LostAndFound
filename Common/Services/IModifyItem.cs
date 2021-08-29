using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    [ServiceContract]
    public interface IModifyItem
    {
        [OperationContract]
        void ModifyItem(Item toModify, Item modified);
    }
}
