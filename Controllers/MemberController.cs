using FirstTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstTask.Models;
using System.Data.Entity;
using System.IO;

namespace FirstTask.Controllers
{
    public class MemberController : Controller
    {
        CompanyContext _context = new CompanyContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ShowMembers(string sortOrder)
        {
           
            var members = from s in _context.Members
                          select s;


            switch (sortOrder)
            {
                case "ASC":
                  members = members.OrderBy(s => s.FirstName);
                    break;
                case "DESC":
                members = members.OrderByDescending(s => s.FirstName);
                    break;
                case "desc":
                 members= members.OrderByDescending(s => s.MemberId);
                    break;
                default:
                    members = members.OrderBy(s => s.MemberId);
                    break;
            }
            return View(members.ToList());
        }


        [HttpGet]
        public ActionResult FindMembers(int id)
        {
            
            var member= _context.Members.Where(pp=>pp.MemberId.Equals(id)).ToList();
            return View(member);
        }
        [HttpGet]
        public ActionResult FindMembers2(string name)
        {
            var member = _context.Members.Where(pp => pp.FirstName.Contains(name)).ToList();
            return View(member);
        }

        [HttpGet]
        public ActionResult AddMember()
        {
            return View();
        }


        [HttpPost]

        public ActionResult AddMember(Member member, HttpPostedFileBase File)

        {
            string name = Path.GetFileNameWithoutExtension(File.FileName);
            string extention = Path.GetExtension(File.FileName);
            name = name + DateTime.Now.ToString("yymmssfff") + extention;

            File.SaveAs(Server.MapPath($"~/Resources/{name}"));
           
            member.File = name;
           

     

       

            if (ModelState.IsValid == false) { return View(); }

            _context.Members.Add(member);
            _context.SaveChanges();
            return RedirectToAction("ShowMembers");
        }
        [HttpGet]
        public ActionResult EditMember(int id)
        {
            var member = _context.Members.Find(id);
            return View(member);
        }
        [HttpPost]
        public ActionResult EditMember(Member member, HttpPostedFileBase File)
        {
            string name = Path.GetFileNameWithoutExtension(File.FileName);
            string extention = Path.GetExtension(File.FileName);
            name = name + DateTime.Now.ToString("yymmssfff") + extention;

            File.SaveAs(Server.MapPath($"~/Resources/{name}"));
          
            member.File = name;

            if (ModelState.IsValid == false)
            {

                return View();
            }
         
            _context.Entry(member).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("ShowMembers");
        }

        [HttpGet]
        public ActionResult DeleteMember(int id)
        {


            var delete = _context.Members.Find(id);
            _context.Members.Remove(delete);
            _context.SaveChanges();
            return RedirectToAction("ShowMembers");

        }
    }
}