﻿using AutoMapper;
using demo.Core.Domain.Books;
using demo.Core;
using demo.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace demo.Admin.Controllers
{
    [Authorize]
    public class SubjectsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubjectsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index(string searchTerm)
        {
            ViewData["currentFilter"] = searchTerm;

            var subjects = _unitOfWork.Subjects.GetAllWithBooks();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                subjects = subjects.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            var subjectsViewModel = _mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectViewModel>>(subjects);
            return View(subjectsViewModel);
        }

        public IActionResult Details(int id)
        {
            var subject = _unitOfWork.Subjects.GetSingleWithBooks(id);
            if (subject == null)
                return NotFound();

            var subjectViewModel = _mapper.Map<Subject, SubjectViewModel>(subject);
            return View(subjectViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SubjectViewModel subjectViewModel)
        {
            if (ModelState.IsValid)
            {
                var subject = _mapper.Map<SubjectViewModel, Subject>(subjectViewModel);
                _unitOfWork.Subjects.Add(subject);
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

            return View(subjectViewModel);
        }

        public IActionResult Edit(int id)
        {
            var subject = _unitOfWork.Subjects.Get(id);
            if (subject == null)
                return NotFound();

            var subjectViewModel = _mapper.Map<Subject, SubjectViewModel>(subject);
            return View(subjectViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SubjectViewModel subjectViewModel)
        {
            if (ModelState.IsValid)
            {
                var subject = _mapper.Map<SubjectViewModel, Subject>(subjectViewModel);
                _unitOfWork.Subjects.Update(subject);
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }

            return View(subjectViewModel);
        }

        public IActionResult Delete(int id)
        {
            var subject = _unitOfWork.Subjects.Get(id);
            if (subject == null)
                return NotFound();

            return View(subject);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var subject = _unitOfWork.Subjects.Get(id);
            if (subject == null)
                return NotFound();

            _unitOfWork.Subjects.Remove(subject);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}