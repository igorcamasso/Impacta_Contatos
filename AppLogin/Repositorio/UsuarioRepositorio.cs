using AppLogin.Data;
using AppLogin.Models;
using AutoMapper;

namespace AppLogin.Repositorio
{
	public class UsuarioRepositorio : IUsuarioRepositorio
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;

		public UsuarioRepositorio(ApplicationDbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public Usuario Adicionar(Usuario contato)
		{
			contato.DataCadastro = DateTime.UtcNow;
			context.Usuarios.Add(contato);
			context.SaveChanges();
			return contato;
		}

		public bool Apagar(int id)
		{
            Usuario usuarioDb = BuscarPorId(id);
			if (usuarioDb == null) throw new System.Exception("Houve um erro de Exclusão");

			context.Usuarios.Remove(usuarioDb);
			context.SaveChanges();
			return true;
		}

		public void Atualizar(Usuario usuario)
		{
			var usuarioDb = BuscarPorId(usuario.UsuarioId);
			if(usuarioDb == null) { throw new Exception("Contato não encontrado."); }

            usuario.DataAtualização = DateTime.UtcNow;
			mapper.Map(usuario, usuarioDb);

			context.SaveChanges();
		}

		public Usuario BuscarPorId(int usuarioId)
		{
			return context.Usuarios.Find(usuarioId);
		}

		public List<Usuario> BuscarTodos()
        {
			return context.Usuarios.ToList();
        }
    }
}
