using System;
using System.Collections.Generic;
using System.Text;

namespace AzureStorageTest
{
    class Book : BaseEntity
    {
        public Book()
        {
        }
        public Book(int bookid, string publisher)
        {
            this.RowKey = bookid.ToString();
            this.PartitionKey = publisher;
        }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
    }
}
