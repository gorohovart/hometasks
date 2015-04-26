using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System.Configuration;

namespace MvcApplication1.Models
{
     
    public class Picture : TableEntity
    {
        public int Number { get; set; }
        public Picture(string num1, string num2)
        {
            this.PartitionKey = num1;
            this.RowKey = num2;
        }
        public Picture() { }
        public Boolean isPorn { get; set; }
        public string Type { get; set; }
        public string url { get; set; }
        public string urlFull { get; set; }
    }
}