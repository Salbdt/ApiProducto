using ApiProducto.Data;
using ApiProducto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProducto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly DataContext _context;
        public ProductoController (DataContext context)
        {
            _context = context;
        }
        // HttpPost, HttpGet, HttpPut, HttpDelete

        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            var productoNew = new Producto
            {
                Nombre      = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio      = producto.Precio,
                FechaAlta   = DateTime.Now,
                Activo      = true
            };

            _context.Productos.Add(productoNew);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto is null)
            {
                return NotFound();
            }

            return producto;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }

            var productoEdit = await _context.Productos.FindAsync(id);

            if (productoEdit is null)
            {
                return NotFound();
            }

            productoEdit.Nombre         = producto.Nombre;
            productoEdit.Descripcion    = producto.Descripcion;
            productoEdit.Precio         = producto.Precio;
            productoEdit.Activo         = producto.Activo;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var productoDelete = await _context.Productos.FindAsync(id);

            if (productoDelete is null)
            {
                return NotFound();
            }

            _context.Productos.Remove(productoDelete);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}