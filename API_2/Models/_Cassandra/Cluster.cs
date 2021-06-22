using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cassandra;

namespace API_2.Models._Cassandra
{
    public class Cluster
    {
        private static readonly string contactPoint = "localhost";
        private static readonly string keyspacesname = "test";

        public static ISession Connect() => Cassandra.Cluster.Builder()
            .AddContactPoint(contactPoint).WithPort(9042)
            .Build().Connect(keyspacesname);

        public static void Dispose() => Cassandra.Cluster.Builder()
            .AddContactPoint(contactPoint).WithPort(9042)
            .Build().Dispose();

        public static bool Commands(string command)
        {
            try
            {
                Connect().Execute(command);
                Dispose();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
