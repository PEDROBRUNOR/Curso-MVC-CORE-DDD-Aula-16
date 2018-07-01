using Dapper;
using Microsoft.EntityFrameworkCore;
using Projeto.Curso.Core.Domain.Pedido.Entidades;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Repository;
using Projeto.Curso.Core.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Curso.Core.Infra.Data.Repository
{
    public class RepositoryProdutos : Repository<Produtos>, IRepositoryProdutos
    {
        public RepositoryProdutos(ContextEFPedidos context)
            : base(context)
        {

        }

        public override IEnumerable<Produtos> ObterTodos()
        {
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT * FROM produtos P
                            INNER JOIN fornecedores F ON p.IdFornecedor = F.Id
                            ORDER BY P.ID DESC
                          ");
            var produtos = Db.Database.GetDbConnection().Query<Produtos, Fornecedores, Produtos>(query.ToString(),
                (P, F) =>
                {
                    P.Fornecedor = F;
                    return P;
                });
            return produtos;
        }

        public override Produtos ObterPorId(int id)
        {
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT * FROM produtos P
                            INNER JOIN fornecedores F ON p.IdFornecedor = F.Id
                            WHERE P.id = @uID
                          ");
            var produtos = Db.Database.GetDbConnection().Query<Produtos, Fornecedores, Produtos>(query.ToString(),
                (P, F) =>
                {
                    P.Fornecedor = F;
                    return P;
                }, new { uID = id });
            return produtos.FirstOrDefault();
        }


        public Produtos ObterPorApelido(string apelido)
        {
            // return Db.Produtos.AsNoTracking().FirstOrDefault(p => p.Apelido == apelido);
            // inner join com fornecedor
            // return Db.Produtos.Include(f => f.Fornecedor).FirstOrDefault(p => p.Apelido == apelido);
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT * FROM produtos P
                            INNER JOIN fornecedores F ON p.IdFornecedor = F.Id
                            WHERE P.apelido = @uAPELIDO
                          ");
            var produtos = Db.Database.GetDbConnection().Query<Produtos, Fornecedores, Produtos>(query.ToString(),
                (P, F) =>
                {
                    P.Fornecedor = F;
                    return P;
                }, new { uAPELIDO = apelido });
            return produtos.FirstOrDefault();
        }

        public Produtos ObterPorNome(string nome)
        {
            // return Db.Produtos.AsNoTracking().FirstOrDefault(p => p.Nome == nome);
            StringBuilder query = new StringBuilder();
            query.Append(@" SELECT * FROM produtos P
                            INNER JOIN fornecedores F ON p.IdFornecedor = F.Id
                            WHERE P.nome = @uNOME
                          ");
            var produtos = Db.Database.GetDbConnection().Query<Produtos, Fornecedores, Produtos>(query.ToString(),
                (P, F) =>
                {
                    P.Fornecedor = F;
                    return P;
                }, new { uNOME = nome });
            return produtos.FirstOrDefault();
        }
    }
}
