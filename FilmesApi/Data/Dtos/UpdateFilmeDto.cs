using System.ComponentModel.DataAnnotations;
namespace FilmesApi.Data.Dtos;

public class UpdateFilmeDto
{
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo Titulo é obrigatório.")]
    [StringLength(100, ErrorMessage = "O campo Título não pode exceder 100 caracteres.")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O campo Genero é obrigatório.")]
    [StringLength(50, ErrorMessage = "O campo Genero não pode exceder 50 caracteres.")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "O campo Duracao é obrigatório.")]
    public int Duracao { get; set; }
}
