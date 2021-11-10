using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureStorageTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CloudStorageAccount storageAccount;
            CloudTableClient tableClient;
            // Connnect to Storage Account
            storageAccount = CloudStorageAccount.Parse("UseDevelopmentStorage=true");
            // Create the Table 'Book', if it not exists
            tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("Book");
            table.CreateIfNotExistsAsync();
            // Create a Book instance
            Book book = new Book()
            {
                Author = "Rami",
                BookName = "ASP.NET Core With Azure",
                Publisher = "APress"
            };
            book.BookId = 1;
            book.RowKey = book.BookId.ToString();
            book.PartitionKey = book.Publisher;
            book.CreatedDate = DateTime.UtcNow;
            book.UpdatedDate = DateTime.UtcNow;
            // Insert and execute operations
            TableOperation insertOperation = TableOperation.Insert(book);
            table.ExecuteAsync(insertOperation);
            Console.ReadLine();
        }
    }
}
