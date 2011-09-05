using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Survey.Models;

namespace Survey.Controllers
{
    public class AnswerController : Controller
    {
        //
        // GET: /Answer/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(int questionId)
        {
            var answers = AnswerModel.GetByQuestion(questionId);
            return View(answers);
        }

        //
        // GET: /Answer/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Answer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Answer/Create

        [HttpPost]
        public ActionResult Create(AnswerModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid && Request["question_id"] != null)
                {

                    collection.QuestionId = int.Parse(Request["question_id"]);
                    collection.Save();

                    return RedirectToAction("Index", "question");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Answer/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Answer/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Answer/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Answer/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
