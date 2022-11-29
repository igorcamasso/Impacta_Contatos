using AppLogin.Models;

namespace AppLogin.Repositorio
{
	public interface IContatoRepositorio
	{
		//um contrato que vai receber como parametro um objeto contrato
		//e que vai retornar ele mesmo deve ser usado na classe ContatoRepositorio
		//por injeção
		Contato Adicionar(Contato contato);

        List<Contato> BuscarTodos();

		Contato BuscarPorId(int id);

		void Atualizar(Contato contato);

		bool Apagar(int id);

	}
}
