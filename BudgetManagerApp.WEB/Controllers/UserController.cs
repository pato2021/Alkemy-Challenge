using AutoMapper;
using BudgetManagerApp.BLL.DTO;
using BudgetManagerApp.BLL.Interfaces;
using BudgetManagerApp.BLL.Services;
using BudgetManagerApp.WEB.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BudgetManagerApp.WEB.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserProfileLogic _userProfileLogic;
        private readonly IOperationLogic _operationLogic;
        private readonly ICategoryLogic _categoryLogic;
        public UserController(IUserProfileLogic userProfileLogic, IOperationLogic operationLogic, ICategoryLogic categoryLogic)
        {
            _userProfileLogic = userProfileLogic;
            _operationLogic = operationLogic;
            _categoryLogic = categoryLogic;
        }

        public ActionResult Index()
        {
            var operationsDTO = _userProfileLogic.ListTopTenOperations(User.Identity.GetUserId());


            var operationsView = Mapper.Map<IEnumerable<OperationModel>>(operationsDTO);

            this.Balance();


            return View(operationsView);
        }

        public void Balance()
        {
            var operationsIncome = _userProfileLogic.ListIncomeOperations(User.Identity.GetUserId());

            var operationsExpense = _userProfileLogic.ListExpenseOperations(User.Identity.GetUserId());

            decimal income = 0;

            decimal expense = 0;

            foreach (OperationDTO o in operationsIncome)
            {
                income += o.Amount;
            }

            foreach (OperationDTO o in operationsExpense)
            {
                expense += o.Amount;
            }

            ViewBag.Income = income;

            ViewBag.Expense = expense;

            ViewBag.Balance = income - expense;
        }

        public ActionResult AddOperation()
        {
            

            List<string> lst = new List<string>();

            lst.Add("Income");
            lst.Add("Expense");

            SelectList ListType = new SelectList(lst);


            ViewBag.TypeOperations = ListType;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOperation(OperationModel model)
        {
            if (ModelState.IsValid)
            {
                var operationDto = new OperationDTO(Request.Form["SelectedType"].ToString());


                operationDto.Concept = model.Concept;
                operationDto.Amount = model.Amount;
                operationDto.Date = model.Date;
                operationDto.UserId = User.Identity.GetUserId();

                
                _operationLogic.Add(operationDto);


            }
            ModelState.Clear();
            return RedirectToAction("Index", "User");
        }

        public ActionResult Income()
        {
            var operationsDTO = _userProfileLogic.ListIncomeOperations(User.Identity.GetUserId());


            var operationsViewIncomes = Mapper.Map<IEnumerable<OperationModel>>(operationsDTO);

            return View(operationsViewIncomes);
        }

        public ActionResult Expense()
        {
            var operationsDTO = _userProfileLogic.ListExpenseOperations(User.Identity.GetUserId());


            var operationsViewEgresses = Mapper.Map<IEnumerable<OperationModel>>(operationsDTO);

            return View(operationsViewEgresses);
        }


        public ActionResult AddCategory()
        {
            List<string> lst = new List<string>();

            lst.Add("Income");
            lst.Add("Expense");

            SelectList ListType = new SelectList(lst);


            ViewBag.TypeOperations = ListType;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(CategoryModel categoryModel) 
        {
            if (ModelState.IsValid)
            {
                var categoryDTO = Mapper.Map<CategoryDTO>(categoryModel);
                _categoryLogic.Add(categoryDTO);
            };

            ModelState.Clear();
            return RedirectToAction("Index", "User");
        }

        public ActionResult EditOperation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var operationDTO = _operationLogic.Get(id);
            var operationModel = Mapper.Map<OperationModel>(operationDTO);
            return View(operationModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOperation(OperationModel operationModel)
        {
            if (ModelState.IsValid)
            {
                var operationDTO = Mapper.Map<OperationDTO>(operationModel);
                _operationLogic.Edit(operationDTO);
            };
            return RedirectToAction("Index", "User");
        }

        public ActionResult DeleteOperation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var operationDTO = _operationLogic.Get(id);
            var operationModel = Mapper.Map<OperationModel>(operationDTO);
            return View(operationModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOperation(OperationModel operationModel)
        {

            if (operationModel == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _operationLogic.Delete(operationModel.Id);
            return RedirectToAction("Index", "User");
        }

        public ActionResult CategorizeOperation(int? id) 
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<SelectListItem> lst = new List<SelectListItem>();

            var aux = _operationLogic.Get(id).Type;

            var categoriesForOperation = _categoryLogic.GetCategoriesByType(_operationLogic.Get(id).Type);

            foreach (CategoryDTO c in categoriesForOperation)
            {
                lst.Add(new SelectListItem() { Text = c.Name , Value = (c.Id).ToString() });
            }

            
           


            ViewBag.CategoryName = lst;

            var operationDTO = _operationLogic.Get(id);
            var operationModel = Mapper.Map<OperationModel>(operationDTO);
            return View(operationModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CategorizeOperation(OperationModel operationModel)
        {

            if (operationModel == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //var nameCategory = Request.Form["SelectedType"].ToString(); 

            //var idCategory = _categoryLogic.Find(c => c.Name == nameCategory);
            _operationLogic.Categorize(operationModel.Id, operationModel.Id);
            return RedirectToAction("Index", "User");
        }

    }
}