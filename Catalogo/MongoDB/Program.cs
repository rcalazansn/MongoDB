using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MongoDB.Driver;

namespace MongoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoClient _client = new MongoClient("mongodb://localhost:27017");

            IMongoDatabase _db = _client.GetDatabase("DBCatalogo");

            Console.WriteLine("Incluindo produtos...");
            var _catalogoProduto = _db.GetCollection<Produto>("Catalogo");

            #region Insert
            Produto _produto1 = new Produto()
            {
                Codigo = "PR00001",
                Nome = "Detergente",
                Tipo = "Limpeza",
                Preco = 5.75,
                DadosFornecedor = new Fornecedor() { Codigo = "FOR0001", Nome = "Empresa XYZ" }
            };
           // _catalogoProduto.InsertOne(_produto1);

            Produto _produto2 = new Produto()
            {
                Codigo = "PR00002",
                Nome = "Martelo",
                Tipo = "Ferramenta",
                Preco = 50.70,
                DadosFornecedor = new Fornecedor() { Codigo = "FOR0002", Nome = "ABC Ferramnetas" }
            };
          //  _catalogoProduto.InsertOne(_produto2);

            Console.WriteLine("Incluindo serviço...");
            var _catalogoServico = _db.GetCollection<Servico>("Catalogo");

            Servico _servico1 = new Servico()
            {
                Codigo = "SER0001",
                Nome = "Limpza Geral",
                ValorHora = 150.00
            };
           // _catalogoServico.InsertOne(_servico1);

            Servico _servico2 = new Servico()
            {
                Codigo = "SER0002",
                Nome = "Segurança patrimonial",
                ValorHora = 250.00
            };
            // _catalogoServico.InsertOne(_servico2);
            #endregion

            #region Update
            Console.WriteLine("Alterando produto..");
            Produto _p = _catalogoProduto.Find(a => a.Nome.Equals("Detergente")).First();
            _p.Preco = 1.6;
            // _catalogoProduto.ReplaceOne(a => a._id == _p._id, _p);
            #endregion

            #region Delete
            Console.WriteLine("Deletar produto");
          //   _catalogoProduto.DeleteOne(a => a.Nome.Equals("Martelo"));
            #endregion

            Console.WriteLine("Processo finalziado!");
            Console.ReadKey();
        }
    }
}
