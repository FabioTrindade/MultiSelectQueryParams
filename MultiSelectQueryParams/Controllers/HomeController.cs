using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MultiSelectQueryParams.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Situacao = ObterMultiSelectList();
            return View();
        }

        public MultiSelectList ObterMultiSelectList()
        {
            ArrayList array = new ArrayList
            {
                new { id = 0, name = "Ativo" },
                new { id = 1, name = "Inativo" },
                new { id = 2, name = "Pendente" }
            };

            var lista = new MultiSelectList(array, "id", "name");

            return lista;
        }

        public JsonResult ObterJsonResult(Models.Home.HomeFilters filtro)
        {
            List<Models.Home.HomeResult> model = new List<Models.Home.HomeResult>
            {
                new Models.Home.HomeResult { id = 0, descricao = "Ana Paula", situcaoId = 0 },
                new Models.Home.HomeResult { id = 1, descricao = "Bruna", situcaoId = 1 },
                new Models.Home.HomeResult { id = 2, descricao = "Carla", situcaoId = 2 },
                new Models.Home.HomeResult { id = 3, descricao = "Daniela", situcaoId = 0 },
                new Models.Home.HomeResult { id = 4, descricao = "Eva", situcaoId = 1 },
                new Models.Home.HomeResult { id = 5, descricao = "Fabiana", situcaoId = 2 },
                new Models.Home.HomeResult { id = 6, descricao = "Gisele", situcaoId = 0 },
                new Models.Home.HomeResult { id = 7, descricao = "Hilana", situcaoId = 1 },
                new Models.Home.HomeResult { id = 8, descricao = "Iara", situcaoId = 2 },
                new Models.Home.HomeResult { id = 9, descricao = "Joana", situcaoId = 0 },
                new Models.Home.HomeResult { id = 10, descricao = "Kenia", situcaoId = 1 },
                new Models.Home.HomeResult { id = 11, descricao = "Laura", situcaoId = 2 }

            };

            var result = (from t in model
                         where ((filtro.situacaoId == null) ? t.situcaoId.ToString().Any() : filtro.situacaoId.Contains(t.situcaoId))
                         orderby t.id
                         select t).Skip(filtro.offSet).Take(filtro.limit);

            return Json(new { rows = result, total = model.Count }, JsonRequestBehavior.AllowGet);
        }
    }
}