using NewtableApiDataconsumeproject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewtableApiDataconsumeproject.Controllers
{
    public class CrudApiController : ApiController
    {
        SchoolSysDBEntities1 db = new SchoolSysDBEntities1();
        [HttpGet]
        public IHttpActionResult getstudentdata()
        {
            List<User> list = db.Users.ToList();
            return Ok(list);

        }
        [HttpGet]
        public IHttpActionResult getstudentdataById(int id)
        {
            var emp = db.Users.Where(model => model.UserId == id).FirstOrDefault();


            return Ok(emp);

        }
        [HttpPost]
        public IHttpActionResult stuInsert(User u)
        {
            db.Users.Add(u);
            db.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult stuUpdate(User u)
        {
            db.Entry(u).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            //var emp = db.Users.Where(model =>model.UserId == u.UserId).FirstOrDefault();
            //if(emp != null)
            //{
            //    emp.UserId= u.UserId;
            //    emp.FirstName= u.FirstName;
            //    emp.LastName= u.LastName;
            //    emp.PassWord = u.PassWord;
            //    emp.Email= u.Email;
            //    emp.Mobile = u.Mobile;
            //    emp.Address = u.Address;
            //    emp.Gender = u.Gender;
            //    emp.Hobbies = u.Hobbies;
            //    emp.Date = u.Date;
            //    emp.Country = u.Country;
            //}
            //else
            //{
            //    return NotFound();
            //}
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult stuDelete(int id)
        {
            var emp = db.Users.Where(model => model.UserId == id).FirstOrDefault();
            db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }
    }
}
