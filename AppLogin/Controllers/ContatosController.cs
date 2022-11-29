using AppLogin.Data.Migrations;
using AppLogin.Models;
using AppLogin.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace AppLogin.Controllers
{
    public class ContatosController : Controller
    {
		private readonly IContatoRepositorio _contatoRepositorio;

		public ContatosController(IContatoRepositorio contatoRepositorio)
        {
			this._contatoRepositorio = contatoRepositorio;
		}

        public IActionResult Index()
        {
            List<Contato> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

		[HttpPost]
		public IActionResult Criar(Contato contato)
		{
			if (ModelState.IsValid)
			{
				_contatoRepositorio.Adicionar(contato);
				TempData["SuccessMessage"] = "Criado com sucesso";
				return RedirectToAction(nameof(Index));
			}
			TempData["ErrorMessage"] = "Verifique os campos e tente novamente";
			return View();
		}


		public IActionResult Editar(int id)
        {
            var contato = _contatoRepositorio.BuscarPorId(id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Editar(Contato model)
        {
            if (ModelState.IsValid)
            {
				_contatoRepositorio.Atualizar(model);
				TempData["SuccessMessage"] = "Editado com sucesso";
				return RedirectToAction(nameof(Editar), new { id = model.Id });
			}
			TempData["ErrorMessage"] = "Verifique os campos e tente novamente";
			return View(model);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
			var contato = _contatoRepositorio.BuscarPorId(id);
			return View(contato);
        }

        [HttpPost]
		public IActionResult ApagarConfirmacaoPost(int id)
		{
            _contatoRepositorio.Apagar(id);
			TempData["SuccessMessage"] = "Apagado com sucesso";
			return RedirectToAction(nameof(Index));
		}

	}
}
