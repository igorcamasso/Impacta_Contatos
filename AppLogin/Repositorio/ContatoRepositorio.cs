using AppLogin.Data;
using AppLogin.Models;
using AutoMapper;

namespace AppLogin.Repositorio
{
	public class ContatoRepositorio : IContatoRepositorio
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;

		public ContatoRepositorio(ApplicationDbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public Contato Adicionar(Contato contato)
		{
			context.Contatos.Add(contato);
			context.SaveChanges();
			return contato;
		}

		public bool Apagar(int id)
		{
			Contato contatoDb = BuscarPorId(id);
			if (contatoDb == null) throw new System.Exception("Houve um erro de Exclusão");

			context.Contatos.Remove(contatoDb);
			context.SaveChanges();
			return true;
		}

		public void Atualizar(Contato contato)
		{
			var contatoDb = BuscarPorId(contato.Id);
			if(contatoDb == null) { throw new Exception("Contato não encontrado."); }

			mapper.Map(contato, contatoDb);

			context.SaveChanges();
		}

		public Contato BuscarPorId(int id)
		{
			return context.Contatos.Find(id);
		}

		public List<Contato> BuscarTodos()
        {
			return context.Contatos.ToList();
        }
    }
}
