using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Empresa.Dados;
using Empresa.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Empresa.WebApp.Controllers
{
    public class FuncionariosController : Controller
    {
        public FuncionariosController()
        {
            Bd = new RepositorioDeFuncionariosDeArquivos();
        }

        private readonly RepositorioDeFuncionarios Bd;

        // GET: Funcionarios
        public ActionResult Index()
        {
            var funcionarios = Bd.BuscarTodosOsFuncionarios();

            return View(funcionarios);
        }

        // GET: Funcionarios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Funcionarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Funcionarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Funcionario funcionario)
        {
            try
            {
                // TODO: Add insert logic here

                Bd.Salvar(funcionario);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Funcionarios/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Funcionarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Funcionarios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Funcionarios/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}