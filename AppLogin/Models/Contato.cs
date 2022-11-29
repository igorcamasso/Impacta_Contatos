using System.ComponentModel.DataAnnotations;

namespace AppLogin.Models
{
	public class Contato
	{
		public int Id { get; set; }

		[StringLength(250), Required(ErrorMessage = "Digite o nome do contato")]
		public string Nome { get; set; } = null!;

		[EmailAddress, Required(ErrorMessage = "Digite o e-mail do contato")]
		public string Email { get; set; } = null!;

		[StringLength(20), Required(ErrorMessage = "Digite o celular do contato")]
		[Phone(ErrorMessage = "O celular informado não é valido!")]
		public string Celular { get; set; } = null!;

	}
}
