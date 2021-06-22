using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cassandra.Mapping;
using API_2.Models;
using API_2.Models._Cassandra;

namespace API_2.BLL
{
    public class TestDriver
    {
        public int ID { get; set; }
        public string name { get; set; }
        public int birthYear { get; set; }

        static TestDriver()
        {
            MappingConfiguration.Global.Define(
                new Map<Test>()
                    .TableName("test")
                    .PartitionKey(test => test.ID)
            );
        }

        private bool isValid()
        {
            return Record(ID) != null;
        }

        public static Test Record(int id)
        {
            return new Mapper(Cluster.Connect()).SingleOrDefault<Test>("SELECT * FROM test WHERE id = " + id);
        }

        public static List<Test> AllRecords()
        {
            List<Test> result = new Mapper(Cluster.Connect()).Fetch<Test>("SELECT * FROM test").OrderBy(x => x.ID).ToList();
            
            if (result.Count == 0)
                return null;

            return result;
        }

        public Test Insert()
        {
            if (isValid())
                return null;

            Test result = new Test(ID, name, birthYear);

            new Mapper(Cluster.Connect()).Insert(result);

            return result;
        }

        public Test Update()
        {
            if (!isValid())
                return null;

            Test result = new Test(ID, name, birthYear);

            new Mapper(Cluster.Connect()).Update(result);

            return result;
        }

        public Test Delete()
        {
            if (!isValid())
                return null;

            Test result = new Test(ID, name, birthYear);

            new Mapper(Cluster.Connect()).Delete(result);

            return result;
        }

    }
}
