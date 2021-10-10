using MonitorarPedidos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonitorarPedidos.Controllers
{
    public class CompraPaginacao
    {
        public int Pagina { get; set; } = 1;
        public int Tamanho { get; set; } = 20;
    }

    public class CompraPaginada
    {
        public int NumeroPagina { get; set; }
        public int TotalPaginas { get; set; }
        public IEnumerable<Compra> Compras { get; set; }
    }
}
