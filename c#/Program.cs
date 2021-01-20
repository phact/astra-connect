using System;
using System.Linq;
using Cassandra;


namespace astraconnect
{
    class Program
    {
        static void Main(string[] args)
        {
            var session =
                Cluster.Builder()
                       .WithCloudSecureConnectionBundle(@"../secure-connect-test.zip")
                       .WithCredentials("datastax", "datastax")
                       .Build()
                       .Connect();

            var rowSet = session.Execute("select * from system.local");
            Console.WriteLine(rowSet.First().GetValue<string>("key"));

        }
    }
}
