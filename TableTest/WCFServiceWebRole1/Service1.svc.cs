using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
//Azure Storage References
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
//using Microsoft.WindowsAzure.StorageClient;
using System.Threading.Tasks;


namespace WCFServiceWebRole1
{
    
    public class Service1 : IService1
    {
        //Add CD Method to add an entry
        public void addCD(string rowkey, string artist, string title, string year)
        {
            //Account credentials

            string accountName = "denesad";
            string accountKey = "skZE52aQ5LccETOj2f2GDphoUz8UN5pALZ+WyCXe533/e2fmnvxTbOfr/8Ugd2Izjs4YHvtZpEC9M2n84fiuQA==";

            //Table Name
            string tableName = "CDTable";

            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), false);
            CloudTableClient cloudTableClient = storageAccount.CreateCloudTableClient();

            //Create the table
            CloudTable CDTable = cloudTableClient.GetTableReference(tableName);
            CDTable.CreateIfNotExists();

            //The CD to be added
            CDS thisCD = new CDS() { PartitionKey = "", RowKey = rowkey, Artist = artist, Title = title, Year = year };
            CDTable.Execute(TableOperation.InsertOrReplace(thisCD));     
        }

        //Get CD method to retrieve an entry
        public CDS getCD(string rowkey)
        {
            //Account credentials

            string accountName = "denesad";
            string accountKey = "skZE52aQ5LccETOj2f2GDphoUz8UN5pALZ+WyCXe533/e2fmnvxTbOfr/8Ugd2Izjs4YHvtZpEC9M2n84fiuQA==";

            //Table Name
            string tableName = "CDTable";

            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), false);
            CloudTableClient cloudTableClient = storageAccount.CreateCloudTableClient();

            //Create the table
            CloudTable CDTable = cloudTableClient.GetTableReference(tableName);
            CDTable.CreateIfNotExists();            

            //Query the table
            TableOperation retrieveOperation = TableOperation.Retrieve<CDS>("", rowkey);
            TableResult retrievedResult = CDTable.Execute(retrieveOperation);
            CDS cd3 = (CDS)retrievedResult.Result;
            return cd3;
        }

        //delete CD method to delete an entry
        public CDS deleteCD(string rowkey)
        {
            //Account credentials

            string accountName = "denesad";
            string accountKey = "skZE52aQ5LccETOj2f2GDphoUz8UN5pALZ+WyCXe533/e2fmnvxTbOfr/8Ugd2Izjs4YHvtZpEC9M2n84fiuQA==";

            //Table Name
            string tableName = "CDTable";

            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), false);
            CloudTableClient cloudTableClient = storageAccount.CreateCloudTableClient();

            //Create the table
            CloudTable CDTable = cloudTableClient.GetTableReference(tableName);
            CDTable.CreateIfNotExists();

            //Query the table
            TableOperation retrieveOperation = TableOperation.Retrieve<CDS>("", rowkey);
            TableResult retrievedResult = CDTable.Execute(retrieveOperation);
            CDS deleteCD = (CDS)retrievedResult.Result;

            //Delete returned entry
            if (deleteCD != null)
            {
                TableOperation deleteEntry = TableOperation.Delete(deleteCD);

                CDTable.Execute(deleteEntry);

            }

            return null;
        }
       
    }

    public class CDS : TableEntity
    {
        public string Artist {get; set;}
        public string Title { get; set; }
        public string Year { get; set; }
    }
}
