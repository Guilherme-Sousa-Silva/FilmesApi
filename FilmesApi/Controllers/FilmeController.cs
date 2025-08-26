using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private readonly FilmeContext _context;
    private readonly IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarFilme([FromBody] CreateFilmeDto createFilmeDto)
    {
        Filme filme = _mapper.Map<Filme>(createFilmeDto);
        await _context.Filmes.AddAsync(filme);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(AdicionarFilme), filme);
    }

    [HttpGet]
    public async Task<IActionResult> ObterFilmes()
    {
        var filmes = await _context.Filmes.ToListAsync();
        return Ok(filmes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterFilmePorId([FromQuery] int id)
    {
        var filme = await _context.Filmes.FirstAsync(x => x.Id == id);
        return Ok(filme);
    }
}
