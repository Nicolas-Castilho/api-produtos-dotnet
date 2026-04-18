namespace MInhaPrimeiraApi.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class ProdutoDto
    {
        [Required]
        public string Nome { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Preco { get; set; }
    }
}
