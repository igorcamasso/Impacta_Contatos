using AppLogin.Models;
using AppLogin.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppLogin.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuariosController(IUsuarioRepositorio contatoRepositorio)
        {
            this._usuarioRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            List<Usuario> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioRepositorio.Adicionar(usuario);
                TempData["SuccessMessage"] = "Criado com sucesso";
                return RedirectToAction(nameof(Index));
            }
            TempData["ErrorMessage"] = "Verifique os campos e tente novamente";
            return View();
        }


        public IActionResult Editar(int id)
        {
            var contato = _usuarioRepositorio.BuscarPorId(id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Editar(Usuario model)
        {
            if (ModelState.IsValid)
            {
                _usuarioRepositorio.Atualizar(model);
                TempData["SuccessMessage"] = "Editado com sucesso";
                return RedirectToAction(nameof(Editar), new { id = model.UsuarioId });
            }
            TempData["ErrorMessage"] = "Verifique os campos e tente novamente";
            return View(model);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            var usuario = _usuarioRepositorio.BuscarPorId(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult ApagarConfirmacaoPost(int id)
        {
            _usuarioRepositorio.Apagar(id);
            TempData["SuccessMessage"] = "Apagado com sucesso";
            return RedirectToAction(nameof(Index));
        }

    }
}
