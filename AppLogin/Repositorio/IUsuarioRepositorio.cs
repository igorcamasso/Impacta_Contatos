using AppLogin.Models;

namespace AppLogin.Repositorio
{
	public interface IUsuarioRepositorio
	{
		//um contrato que vai receber como parametro um objeto contrato
		//e que vai retornar ele mesmo deve ser usado na classe ContatoRepositorio
		//por injeção
		Usuario Adicionar(Usuario contato);

        List<Usuario> BuscarTodos();

        Usuario BuscarPorId(int id);

		void Atualizar(Usuario contato);

		bool Apagar(int id);

	}
}
