using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;

namespace DecryptNeo4j
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var engine = new FileHelperEngine<DocInfo>();
                string checkDup = null;

                // To Read Use:
                var records = engine.ReadFile("EncryptedDocInfoDV.csv");
                // result is now an array of Customer
                //var distinctValues = records.DistinctBy(c => records.ID);
                //csv file
                var csv = new StringBuilder();
                csv.AppendLine("DocID,Name,Version,DocOWnerEmail");

                // To Write Use:
                foreach (var record in records)
                {
                    string unencrptName = StringEncryption.Decrypt(record.EncName, record.EncKey);
                    string decrypted = String.Format("{0},{1},{2},{3}", record.ID, unencrptName, record.DocVer, record.Email);
                    
                    
                    if (checkDup != record.ID)
                    {
                        csv.AppendLine(decrypted);
                        Console.WriteLine(unencrptName);
                        checkDup = record.ID;
                    }
                }
                File.WriteAllText("Output.csv", csv.ToString());
                Console.WriteLine("DONE! :D");
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e); 
            }
        }
    }
}
