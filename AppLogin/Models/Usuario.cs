using AppLogin.ENums;
using System.ComponentModel.DataAnnotations;

namespace AppLogin.Models
{
	public class Usuario
	{
		[Key]
		public int UsuarioId { get; set; }
		public string UsuarioNome { get; set; }
		public string Login { get; set; }

		public string Email { get; set; }
		public string Senha { get; set; }
		public EPerfil Perfil { get; set; }
		public DateTime DataCadastro { get; set; }
		public DateTime? DataAtualização { get; set; }

	}
}
