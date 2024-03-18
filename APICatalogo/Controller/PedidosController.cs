using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controller;

  
[Route("[Controller]")]
[ApiController]
public class PedidosController : ControllerBase
{
    private readonly AppDbContext _context;

    public PedidosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("produtos")]
    public ActionResult<IEnumerable<Pedido>> GetPedidosProdutos()
    {
        try
        {
            return _context.Pedidos.Include(p => p.Produtos).AsNoTracking().ToList();
        }

        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "" +
                "Ocorreu um erro no servidor.");
        }
    }

    [HttpGet]
    public ActionResult<IEnumerable<Pedido>> Get()
    {
        try
        {
            return _context.Pedidos.AsNoTracking().ToList();

        }

        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "" +
                "Ocorreu um erro no servidor.");
        }
    }
    

    [HttpGet("{id:int}", Name = "ObterPedido")]
    public ActionResult<Pedido> Get(int id)
    {
        try
        {
            var pedido = _context.Pedidos.FirstOrDefault(p => p.PedidoId == id);

            if (pedido == null)
            {
                return NotFound("Pedido não localizado");
            }
            return pedido;
        }

        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "" +
                "Ocorreu um erro no servidor.");
        }
    }

    [HttpPost]
    public ActionResult Post(Pedido pedido)
    {
        try
        {
            if (pedido == null)
            {
                return BadRequest("Dados invalidos");
            }
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterPedido",
                new { id = pedido.PedidoId }, pedido);
        }

        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "" +
                "Ocorreu um erro no servidor.");
        }

    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Pedido pedido)
    {
        try
        {
            if (id != pedido.PedidoId)
            {
                return BadRequest("Pedido não localizado");
            }

            _context.Entry(pedido).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(pedido);
        }

        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "" +
                "Ocorreu um erro no servidor.");
        }

    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        try
        {
            var pedido = _context.Pedidos.FirstOrDefault(p => p.PedidoId == id);
            if (pedido is null)
            {
                return NotFound("Pedido não localizado");
            }

            _context.Pedidos.Remove(pedido);
            _context.SaveChanges();

            return Ok(pedido);

        }


        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "" +
                "Ocorreu um erro no servidor.");

        }

    }
}




