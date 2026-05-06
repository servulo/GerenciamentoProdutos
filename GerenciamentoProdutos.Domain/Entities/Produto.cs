using System.ComponentModel.DataAnnotations;

namespace GerenciamentoProdutos.Domain.Entities
{
    public class Produto
    {

        public virtual int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres")]
        [Display(Name = "Nome")]
        public virtual string Nome { get; set; }

        [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres")]
        [Display(Name = "Descrição")]
        public virtual string Descricao { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório")]
        [Range(0.01, 99999.99, ErrorMessage = "O preço deve ser entre R$ 0,01 e R$ 99.999,99")]
        [Display(Name = "Preço")]
        public virtual decimal Preco { get; set; }

        [Required(ErrorMessage = "A quantidade em estoque é obrigatória")]
        [Range(0, 9999, ErrorMessage = "A quantidade deve ser entre 0 e 9999")]
        [Display(Name = "Quantidade em Estoque")]
        public virtual int QuantidadeEstoque { get; set; }

    }
}
