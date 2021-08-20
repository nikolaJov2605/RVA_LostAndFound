﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    [ServiceContract]
    public interface IAddItem
    {
        [OperationContract]
        bool Add(Item item);

        [OperationContract]
        int GetAvailableKeyValue();

        [OperationContract]
        Person FindPerson(string username);
    }
}
