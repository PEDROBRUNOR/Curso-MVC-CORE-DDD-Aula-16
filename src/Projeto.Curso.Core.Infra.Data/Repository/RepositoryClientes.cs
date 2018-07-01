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
    public class RepositoryClientes : Repository<Clientes>, IRepositoryClientes
    {
        public RepositoryClientes(ContextEFPedidos context)
            : base(context)
        {

        }

        public override IEnumerable<Clientes> ObterTodos()
        {
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM clientes ORDER BY id DESC");
            return Db.Database.GetDbConnection().Query<Clientes>(query.ToString());
        }

        public override Clientes ObterPorId(int id)
        {
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM clientes WHERE id=@uID");
            var retorno = Db.Database.GetDbConnection().Query<Clientes>(query.ToString(), new { uID = id }).FirstOrDefault();
            return retorno;
        }

        public Clientes ObterPorApelido(string apelido)
        {
            // return Db.Clientes.AsNoTracking().FirstOrDefault(c => c.Apelido == apelido);
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM clientes WHERE apelido=@uAPELIDO");
            var retorno = Db.Database.GetDbConnection().Query<Clientes>(query.ToString(), new { uAPELIDO = apelido }).FirstOrDefault();
            return retorno;
        }

        public Clientes ObterPorCpfCnpj(string cpfcnpj)
        {
            // return Db.Clientes.AsNoTracking().FirstOrDefault(c => c.CPFCNPJ.Numero == cpfcnpj);
            StringBuilder query = new StringBuilder();
            query.Append(@"SELECT * FROM clientes WHERE CpfCnpj=@uCPFCNPJ");
            var retorno = Db.Database.GetDbConnection().Query<Clientes>(query.ToString(), new { uCPFCNPJ = cpfcnpj }).FirstOrDefault();
            return retorno;
        }
    }
}
