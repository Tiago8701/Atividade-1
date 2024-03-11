using Microsoft.AspNetCore.Mvc;

namespace Atividade_1.Models
{
    public class ConvidadoController : Controller
    {
        public static IList<Convidado> ListaConvidados = new List<Convidado>()
        {
            new Convidado()
            {
                ConvidadoId = 1,
                Nome = "Tiago",
                EMail = "tiago1@gmail.com",
                Telefone = "998050508",
                Comparecimento = true
            },
            new Convidado()
            {
                ConvidadoId = 2,
                Nome = "João",
                EMail = "João1@gmail.com",
                Telefone = "940028922",
                Comparecimento = true
            }
        };
        public IActionResult Index()
        {
            var convidadosCompareceram = ListaConvidados.Where(conv => conv.Comparecimento == true).OrderBy(conv => conv.ConvidadoId);
            return View(convidadosCompareceram);
        }
        public IActionResult IndexTodos()
        {
            return View("Index", ListaConvidados.OrderBy(conv => conv.ConvidadoId));
        }
        public IActionResult IndexComparecimento()
        {
            var convidadosCompareceram = ListaConvidados.Where(conv => conv.Comparecimento == true).OrderBy(conv => conv.ConvidadoId);
            return View("Index", convidadosCompareceram);
        }


        public IActionResult Create()
        {
            var novoConvidado = new Convidado(); 
            return View(novoConvidado);
        }

        [HttpPost]
        public IActionResult Create(Convidado convidado)
        {
            if (Request.Form["Comparecimento"] == "on")
                convidado.Comparecimento = true;
            else
                convidado.Comparecimento = false;


            ListaConvidados.Add(convidado);
            convidado.ConvidadoId = ListaConvidados.Select(conv => conv.ConvidadoId).Max() + 1;
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            return View(ListaConvidados.Where(conv => conv.ConvidadoId == id).First());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(ListaConvidados.Where(cat => cat.ConvidadoId == id).First());
        }

        [HttpPost]
        public IActionResult Edit(Convidado convidado)
        {
            if (Request.Form["Comparecimento"] == "on")
                convidado.Comparecimento = true;
            else
                convidado.Comparecimento = false;

            var convidadoExistente = ListaConvidados.FirstOrDefault(cat => cat.ConvidadoId == convidado.ConvidadoId);
            if (convidadoExistente != null)
            {
                ListaConvidados.Remove(convidadoExistente);
                ListaConvidados.Add(convidado);
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            return View(ListaConvidados.Where(cat => cat.ConvidadoId == id).First());
        }

        [HttpPost]
        public IActionResult Delete(Convidado convidado)
        {
            ListaConvidados.Remove(ListaConvidados.Where(cat => cat.ConvidadoId == convidado.ConvidadoId).First());

            return RedirectToAction("Index");

        }

        public IActionResult ConsultaPorNome(string nome)
        {
            return View();

        }

        public IActionResult RetornaDadosNome(string nome)
        {
            return View(ListaConvidados.Where(cat => cat.Nome == nome).First());
        }


    }
}
