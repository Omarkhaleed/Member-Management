using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using FirstTask.Models;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web;
using System.Data.Entity;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace FirstTask.Controllers
{
    public class ValuesController : ApiController
    {
        CompanyContext _context = new CompanyContext();

      

     // Get Member with name or all members

        public  IEnumerable<Member> Get(string name)
        {
            if (name == null)
            {
                var s = _context.Members.ToList();
                return s;
            }
            else
            {
               var ss = _context.Members.Where(pp => pp.FirstName.Contains(name));

                return ss.ToList();
            }


        }

        // Get Member With Id
        [System.Web.Mvc.HttpGet]
        public IEnumerable<string> mem(int id)
        {
            yield return "your dats is";
        }
        
        // For Add Member
        [System.Web.Mvc.HttpPost]
       
        public HttpResponseMessage Post( Member data)
        {

            //string name = Path.GetFileNameWithoutExtension(File.FileName);
            //string extention = Path.GetExtension(File.FileName);
            //name = name + DateTime.Now.ToString("yymmssfff") + extention;

            //File.SaveAs($"D:/WebDevelpment/ITI(.NET)/code/FirstTask/Resources/{name}");

            //data.File = name;
            _context.Members.Add(data);
            _context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Member added");

        }

       // For Edit Member

       [System.Web.Mvc.HttpPut]
        public HttpResponseMessage Put([System.Web.Http.FromBody] Member data)
        {
            var edit = _context.Members.Find(data.MemberId);

            edit.FirstName = data.FirstName;
            edit.SocilID = data.SocilID;
            edit.File = data.File;
             _context.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Member edited");
        }

      
        // For delete Member

        [System.Web.Mvc.HttpPost]

        public HttpResponseMessage post( int MemberId)
        {
          
            try
               {

                    var delete = _context.Members.Find(MemberId);

                     if (delete == null)
                       {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Member with id = " + MemberId.ToString() + " not found");
                       }
                else 
                {
                    _context.Members.Remove(delete);
                    _context.SaveChanges();


                    return Request.CreateResponse(HttpStatusCode.OK, "Member deleted");
                }

            }
            catch (Exception Ex)
              {

                       return Request.CreateErrorResponse(HttpStatusCode.BadRequest, Ex);
                   }
            }
        
        }
}