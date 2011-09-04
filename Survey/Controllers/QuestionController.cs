using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Survey.Models;

namespace Survey.Controllers
{
    public class QuestionController : Controller
    {
        //
        // GET: /QuestionModel/

        public ActionResult Index()
        {
            List<QuestionModel> questionist = QuestionModel.GetAll();

            return View(questionist);
        }

        //
        // GET: /QuestionModel/Details/5

        public ActionResult Details(int id)
        {
            QuestionModel question = QuestionModel.GetById(id);
            return View(question);
        }

        //
        // GET: /QuestionModel/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /QuestionModel/Create

        [HttpPost]
        public ActionResult Create(QuestionModel question)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    question.Save();
                    return RedirectToAction("Index");
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
        // GET: /QuestionModel/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /QuestionModel/Edit/5

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
        // GET: /QuestionModel/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /QuestionModel/Delete/5

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
