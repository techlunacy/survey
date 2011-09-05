using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Survey.Models;

namespace Survey.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                UserModel user = new UserModel() { Name = collection["name"], Phone = collection["phone"] };
                user.Save();
                foreach (var answer in collection.Keys)
                {
                    if (answer.ToString().ToLower() != "phone" && answer.ToString().ToLower() != "name".ToString())
                    {
                        UserAnswersModel userAnswersModel = new UserAnswersModel() { AnswerId = int.Parse(answer.ToString()), QuestionId = int.Parse(collection[answer.ToString()]), UserId = user.Id };
                        userAnswersModel.Save();
                    }

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
