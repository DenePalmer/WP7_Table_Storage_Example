﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        //Operation contracts define the methods within the cloud service that are useable via external applications

        [OperationContract]
        void addCD(string rowkey, string artist, string title, string year);

        [OperationContract]
        CDS getCD(string rowkey);


        [OperationContract]
        CDS deleteCD(string rowkey);
    }
}
