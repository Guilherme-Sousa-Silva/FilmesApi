using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models;
public class Filme
{
    [Required(ErrorMessage = "O campo Titulo é obrigatório.")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O campo Genero é obrigatório.")]
    [MaxLength(50, ErrorMessage = "O campo Genero não pode exceder 50 caracteres.")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "O campo Duracao é obrigatório.")]
    public int Duracao { get; set; } // duração em minutos
}