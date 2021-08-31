﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    [ServiceContract]
    public interface ISetItemIsFound
    {
        [OperationContract]
        void ItemFound(int key, string finderUsername);
        [OperationContract]
        void ItemNotFound(int key);
    }
}
