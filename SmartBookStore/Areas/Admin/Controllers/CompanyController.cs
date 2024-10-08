﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartBookStore.DataAccess.Data;
using SmartBookStore.DataAccess.Repository.IRepository;
using SmartBookStore.Models;
using SmartBookStore.Models.ViewModels;
using SmartBookStore.Utility;

namespace SmartBookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CompanyController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
           // List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();

           // return View(objCompanyList);
           return View();
        }

        public IActionResult Upsert(int? id)
        {
            Company  company= new Company();
            if (id == null || id == 0)
            {
                return View(company);
            }
            else
            {
                company = _unitOfWork.Company.Get(u => u.Id == id);
                return View(company);
            }

        }
        [HttpPost]
        public IActionResult Upsert(Company company, IFormFile? file)
        {

            if (ModelState.IsValid)
            {              
                if (company.Id == 0)
                {
                    _unitOfWork.Company.Add(company);
                }
                else
                {
                    _unitOfWork.Company.Update(company);
                }

                _unitOfWork.Save();
                TempData["success"] = "Company Created successfully";
                return RedirectToAction("Index");

            }
            else
            {
                return View(company);
            }

        }






        #region API CALLS
       
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = objCompanyList });
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var companyToBeDeleted = _unitOfWork.Company.Get(u => u.Id == id);
            if (companyToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Company.Remove(companyToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = false, message = "Delete Successful" });
        }

        #endregion

    }
}