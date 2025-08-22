using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AdicionarFilme([FromBody] Filme filme)
    {
        if (filme == null)
        {
            return BadRequest("Filme não pode ser nulo.");
        }
        // Aqui você poderia adicionar lógica para salvar o filme no banco de dados
        return CreatedAtAction(nameof(AdicionarFilme), new { id = 1 }, filme); // Exemplo de retorno
    }
}
