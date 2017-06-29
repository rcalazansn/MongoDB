using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB_01
{
    class Program
    {
        static void Main(string[] args)
        {
            //DocumentoBson();

            // Insert1().GetAwaiter().GetResult();

             Insert2().GetAwaiter().GetResult();

            Console.ReadKey();
        }
        private static BsonDocument DocumentoBson()
        {
            var doc = new BsonDocument();
            doc.Add("nome", "Joao");
            doc.Add("idade", 20);

            var array = new BsonArray();
            array.Add(new BsonDocument("treinamento", "C#"));
            array.Add(new BsonDocument("treinamento", "MongoDB"));

            doc.Add("treinamentos", array);

            return doc;
        }
        private static async Task Insert1()
        {
            var stringConexao = "mongodb://localhost:27017";
            var client = new MongoClient(stringConexao);

            var db = client.GetDatabase("treinamentoMongo");
            var col = db.GetCollection<BsonDocument>("Pessoa");

            var doc = DocumentoBson();

            await col.InsertOneAsync(doc);

            Console.WriteLine("Inserido!");
        }

        private static async Task Insert2()
        {
            var stringConexao = "mongodb://localhost:27017";
            var client = new MongoClient(stringConexao);

            var db = client.GetDatabase("treinamentoMongo");
            var col = db.GetCollection<Pessoa>("Pessoa");

            var pessoa = new Pessoa()
            {
                Id =1,
                Nome ="Maria",
                Idade = 24,
                Treinamentos= new List<string>(){"C#", "MongoDB" }
            };

            await col.InsertOneAsync(pessoa);

            Console.WriteLine("Inserido!");
        }
    }
}
