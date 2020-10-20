using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FoodsPapa.Models;
using FoodsPapa.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace FoodsPapa.Controllers
{
    public class MembersController : Controller
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public MembersController(IMemberRepository mRepository, IHostingEnvironment hostingEnvironment)
        {

            _memberRepository = mRepository;
            this._hostingEnvironment = hostingEnvironment;
        }
       
        public IActionResult Index()
        {

            List<Member> m = _memberRepository.GetMembers().ToList();
            return View(m);
        }
       
        public ViewResult Details(int id)
        {

            //throw new Exception(); 
            Member emp = _memberRepository.GetMemberDeatils(id);
            if (emp == null)
            {
                Response.StatusCode = 404;
                return View("MemberNotFound", id);
            }
            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel()
            {
                Member = _memberRepository.GetMemberDeatils(id),
                PageTitle = "Employee Details"
            };
            return View(homeIndexViewModel);
        }
        [HttpGet]

        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(MemberVM model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessFileUpload(model);
                Member newMember = new Member
                {
                    MemberName = model.MemberName,
                    Email = model.Email,
                    Address = model.Address,
                    Phone = model.Phone,
                    Image= uniqueFileName
                };
                _memberRepository.AddMember(newMember);
                return RedirectToAction("Details", new { id = newMember.MemberId });
            }
            return View();
        }
        [HttpGet]

        public ViewResult Update(int id)
        {
            Member member = _memberRepository.GetMemberDeatils(id);
            EditMemberVM model = new EditMemberVM()
            {
                MemberId = member.MemberId,
                MemberName = member.MemberName,
                Email = member.Email,
                Address = member.Address,
                Phone = member.Phone,
                ExistingPhotoPath = member.Image,
                PageTitle = "Member Details"
            };
            return View(model);
        }
        [HttpPost]

        public IActionResult Update(EditMemberVM obj)
        {
            if (ModelState.IsValid)
            {
                Member member = _memberRepository.GetMemberDeatils(obj.MemberId);
                member.MemberName = obj.MemberName;
                member.Email = obj.Email;
                member.Address = obj.Address;
                member.Phone = obj.Phone;
                if (obj.ImageFile != null)
                {
                    if (obj.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "MbrImage", obj.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    member.Image = ProcessFileUpload(obj);
                }

                Member emp = _memberRepository.UpdateMember(member);
                return RedirectToAction("Index");
            }
            return View();
        }
        private string ProcessFileUpload(MemberVM obj)
        {
            string uniqueFileName = null;
            if (obj.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "MbrImage");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + obj.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    obj.ImageFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        [HttpPost]

        public IActionResult Delete(int id)
        {
            Member member = _memberRepository.GetMemberDeatils(id);
            if (member != null)
            {
                Member deleteMember = _memberRepository.DeleteMember(member.MemberId);
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}