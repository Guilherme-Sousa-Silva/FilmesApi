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
        var filmesDto = _mapper.Map<List<ReadFilmeDto>>(filmes);
        return Ok(filmesDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObterFilmePorId(int id)
    {
        var filme = await _context.Filmes.FirstOrDefaultAsync(x => x.Id == id);
        if (filme == null)
        {
            return NotFound();
        }

        ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return Ok(filmeDto);
    }

    [HttpPut]
    public async Task<IActionResult> AtualizarFilme([FromBody] UpdateFilmeDto updateFilmeDto)
    {
        var filme = await _context.Filmes.FirstOrDefaultAsync(x => x.Id == updateFilmeDto.Id);
        if (filme == null)
        {
            return NotFound();
        }

        _mapper.Map(updateFilmeDto, filme);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("id")]
    public async Task<IActionResult> Deletar(int id)
    {
        var filme = await _context.Filmes.FirstOrDefaultAsync(x => x.Id == id);
        if (filme == null)
        {
            return NotFound();
        }

        _context.Filmes.Remove(filme);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
