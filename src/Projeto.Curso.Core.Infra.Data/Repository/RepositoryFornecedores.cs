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
    public class RepositoryFornecedores : Repository<Fornecedores>, IRepositoryFornecedores
    {
        public RepositoryFornecedores(ContextEFPedidos context)
            : base(context)
        {

        }
        public override IEnumerable<Fornecedores> ObterTodos()
        {
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM fornecedores ORDER BY id DESC");
            return Db.Database.GetDbConnection().Query<Fornecedores>(query.ToString());
        }

        public override Fornecedores ObterPorId(int id)
        {
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM fornecedores WHERE id=@uID");
            var retorno = Db.Database.GetDbConnection().Query<Fornecedores>(query.ToString(), new { uID = id }).FirstOrDefault();
            return retorno;
        }

        public Fornecedores ObterPorApelido(string apelido)
        {
            // return Db.Fornecedores.AsNoTracking().FirstOrDefault(f => f.Apelido == apelido);
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM fornecedores WHERE apelido=@uAPELIDO");
            var retorno = Db.Database.GetDbConnection().Query<Fornecedores>(query.ToString(), new { uAPELIDO = apelido }).FirstOrDefault();
            return retorno;
        }

        public Fornecedores ObterPorCpfCnpj(string cpfcnpj)
        {
            // return Db.Fornecedores.AsNoTracking().FirstOrDefault(f => f.CPFCNPJ.Numero == cpfcnpj);
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM fornecedores WHERE CpfCnpj=@uCPFCNPJ");
            var retorno = Db.Database.GetDbConnection().Query<Fornecedores>(query.ToString(), new { uCPFCNPJ = cpfcnpj }).FirstOrDefault();
            return retorno;
        }

    }
}
