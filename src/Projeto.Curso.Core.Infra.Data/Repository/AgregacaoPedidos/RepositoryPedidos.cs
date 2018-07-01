using Microsoft.EntityFrameworkCore;
using Projeto.Curso.Core.Domain.Pedido.AgregacaoPedidos;
using Projeto.Curso.Core.Domain.Pedido.Interfaces.Repository.AgregacaoPedidos;
using Projeto.Curso.Core.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Projeto.Curso.Core.Infra.Data.Repository.AgregacaoPedidos
{
    public class RepositoryPedidos : Repository<Pedidos>, IRepositoryPedidos
    {
        public RepositoryPedidos(ContextEFPedidos context)
            : base(context)
        {

        }
        public void AdicionarItensPedidos(ItensPedidos item)
        {
            Db.ItensPedidos.Add(item);
        }

        public void AtulizarItensPedidos(ItensPedidos item)
        {
            Db.ItensPedidos.Update(item);
        }

        public void RemoverItensPedidos(ItensPedidos item)
        {
            Db.ItensPedidos.Remove(item);
        }


        public IEnumerable<ItensPedidos> ObterItensPedido(int idpedido)
        {
            return Db.ItensPedidos.Where(i => i.IdPedido == idpedido).OrderBy(i => i.Produto.Apelido);
        }

        public ItensPedidos ObterItensPedidosPorId(int id)
        {
            return Db.ItensPedidos.AsNoTracking().FirstOrDefault(i => i.Id == id);
        }

    }
}
