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

namespace DeleteDocs
{
    class Program
    {
        static void Main(string[] args)
        {
            //read csv UPDATE FILE
            var reader = new StreamReader("DeleteDocs.csv");

            List<string> docIds = new List<string>();

            //loop through file adding each line to list
            while (!reader.EndOfStream)
            {
                var lineinFile = reader.ReadLine();
                docIds.Add(lineinFile);
            }
            //connect to neo4j
            var client = new GraphClient(new Uri("https://beta-neo4j.scribestar.com:7473/db/data"), "collaboration",
    "FH9eh2wLZHEZJhSVn77W");
            client.Connect();

            //cypher query
            var docs = client.Cypher
                    .Match("(d:Document)")
                    .Where("d.Id IN {docId}")
                    .WithParam("docId", docIds)
                    .Remove("d:Document")
                    .Set("d:DeletedDocument")
                    .Return<DeletedDocument>("d");

            //create or append to file file
            using (StreamWriter file =
                new StreamWriter("fileNames.txt"))
            {
                string output = docs.Query.DebugQueryText;
                file.WriteLine(output);
            }
        }
    }
}
