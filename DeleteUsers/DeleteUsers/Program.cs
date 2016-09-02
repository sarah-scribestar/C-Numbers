using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Neo4jClient;
using Neo4jClient.Cypher;

namespace DeleteUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            //read csv UPDATE FILE
            var reader = new StreamReader("test.csv");

            List<string> usremail = new List<string>();

            //loop through file adding each line to list
            while (!reader.EndOfStream)
            {
                var lineinFile = reader.ReadLine();
                usremail.Add(lineinFile);
            }
            //connect to neo4j
            var client = new GraphClient(new Uri("https://uat-neo4j.scribestar.com:7473/db/data"), "collaboration",
    "FH9eh2wLZHEZJhSVn77W");
            client.Connect();

            //cypher query
            var docs = client.Cypher
                    .Match("(u:User)")
                    .Where("u.EmailAddress IN {usremail}")
                    .WithParam("usremail", usremail)
                    .Remove("u:User")
                    .Set("u:DeletedUser")
                    .Return<DeletedUser>("u"); 

                //create or append to file file
                using (StreamWriter file =
                    new StreamWriter("DeleteUsersQuery.txt"))
                {
                    string output = docs.Query.DebugQueryText;
                    file.WriteLine(output);
                }
                
        }
    }
}
