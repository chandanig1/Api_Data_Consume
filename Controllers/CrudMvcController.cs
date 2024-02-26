using NewtableApiDataconsumeproject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;

namespace NewtableApiDataconsumeproject.Controllers
{
    public class CrudMvcController : Controller
    {
        private readonly User context;
        public CrudMvcController(User context)
        { 
            this.context= context;
        }
        // GET: CrudMvc
        HttpClient client = new HttpClient();

        public ActionResult Index()
        {
            List<User> stu = new List<User>();
            client.BaseAddress = new Uri("https://localhost:44358/api/CrudApi");
            var response = client.GetAsync("CrudApi");
            response.Wait();
            var test = response.Result;
            if(test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<User>>();
                display.Wait();
                stu = display.Result;
            }
            return View(stu);           
        }
       public ActionResult create()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult create(User u)
        {
            client.BaseAddress = new Uri("https://localhost:44358/api/CrudApi");
            var response = client.PostAsJsonAsync<User>("CrudApi", u);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
                
            }
            return View("create");
        }
        public ActionResult Details(int id)
        {
            User u = null;
            client.BaseAddress = new Uri("https://localhost:44358/api/CrudApi");
            var response = client.GetAsync("CrudApi?id="+ id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<User>();
                display.Wait();
                u = display.Result;
            }
            return View(u);

        }
        public ActionResult Edit(int id)
        {
            User u = null;
            client.BaseAddress = new Uri("https://localhost:44358/api/CrudApi");
            var response = client.GetAsync("CrudApi?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<User>();
                display.Wait();
                u = display.Result;
            }
            return View(u);
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(User e)
        {
            client.BaseAddress = new Uri("https://localhost:44358/api/CrudApi");
            var response = client.PutAsJsonAsync<User>("CrudApi", e);
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View("Edit");
        }
        public ActionResult Delete(int id)
        {
            User u = null;
            client.BaseAddress = new Uri("https://localhost:44358/api/CrudApi");
            var response = client.GetAsync("CrudApi?id=" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<User>();
                display.Wait();
                u = display.Result;
            }
            return View(u);
        }
        [HttpPost, System.Web.Mvc.ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            User u = null;
            client.BaseAddress = new Uri("https://localhost:44358/api/CrudApi");
            var response = client.DeleteAsync("CrudApi/" + id.ToString());
            response.Wait();
            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Delete");
            
        }
        [System.Web.Http.HttpPost]
        public ActionResult Login(User obj)
        {
           //var result=Model.User()
           // if(test.IsSuccessStatusCode)
           // {
           //     return RedirectToAction("Index");
           // }
            return View("Login");

        }
        public ActionResult Registration()
        {
            return View();
        }
    }
}