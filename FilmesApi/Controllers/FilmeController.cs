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

    /// <summary>
    /// Adiciona um novo filme ao banco de dados.
    /// </summary>
    /// <param name="createFilmeDto">Objeto com os dados do filme a ser criado.</param>
    /// <returns>Retorna o filme criado e o status 201 em caso de sucesso.</returns>
    /// <response code="201">Filme criado com sucesso.</response>
    /// <response code="400">Dados inválidos enviados na requisição.</response>
    [HttpPost]
    public async Task<IActionResult> AdicionarFilme([FromBody] CreateFilmeDto createFilmeDto)
    {
        Filme filme = _mapper.Map<Filme>(createFilmeDto);
        await _context.Filmes.AddAsync(filme);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(AdicionarFilme), filme);
    }

    /// <summary>
    /// Retorna a lista de todos os filmes cadastrados.
    /// </summary>
    /// <returns>Lista de filmes.</returns>
    /// <response code="200">Retorna a lista de filmes.</response>
    [HttpGet]
    public async Task<IActionResult> ObterFilmes()
    {
        var filmes = await _context.Filmes.ToListAsync();
        var filmesDto = _mapper.Map<List<ReadFilmeDto>>(filmes);
        return Ok(filmesDto);
    }

    /// <summary>
    /// Retorna um filme específico pelo seu ID.
    /// </summary>
    /// <param name="id">ID do filme a ser consultado.</param>
    /// <returns>Dados do filme encontrado.</returns>
    /// <response code="200">Retorna o filme encontrado.</response>
    /// <response code="404">Filme não encontrado.</response>
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

    /// <summary>
    /// Atualiza os dados de um filme existente.
    /// </summary>
    /// <param name="updateFilmeDto">Objeto com os dados atualizados do filme.</param>
    /// <returns>Status da operação.</returns>
    /// <response code="204">Filme atualizado com sucesso.</response>
    /// <response code="404">Filme não encontrado.</response>
    /// <response code="400">Dados inválidos enviados na requisição.</response>
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

    /// <summary>
    /// Remove um filme do banco de dados pelo ID.
    /// </summary>
    /// <param name="id">ID do filme a ser removido.</param>
    /// <returns>Status da operação.</returns>
    /// <response code="204">Filme removido com sucesso.</response>
    /// <response code="404">Filme não encontrado.</response>
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
