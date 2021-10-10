using Microsoft.AspNetCore.Mvc;
using MonitorarPedidos.Model;
using MonitorarPedidos.Servicos;
using System.Linq;

namespace MonitorarPedidos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompraControlador : ControllerBase
    {
        private readonly CompraServico _compraServico;

        public CompraControlador(CompraServico cs)
        {
            _compraServico = cs;
        }

        [HttpGet]
        public IActionResult GetTodasCompra([FromQuery] CompraPaginacao paginacao)
        {
            CompraPaginada compraPaginada = new CompraPaginada
            {
                NumeroPagina = paginacao.Pagina,
                TotalPaginas = paginacao.Tamanho,
                Compras = _compraServico.Get().Skip(paginacao.Pagina > 0 ? ((paginacao.Pagina - 1) * paginacao.Tamanho) : 0).Take(paginacao.Tamanho)
            };

            return Ok(compraPaginada);
        }

        [HttpGet("{id}")]
        public IActionResult GetUmaCompra(string id)
        {
            var compra = _compraServico.Get(id);
            if (compra == null)
            {
                return NotFound();
            }
            return Ok(compra);
        }

        [HttpPost]
        public IActionResult CriarCompra(Compra compra)
        {
            _compraServico.Create(compra);
            return CreatedAtAction(nameof(GetUmaCompra), new { id = compra.orderId}, compra);
        }
    }
}
