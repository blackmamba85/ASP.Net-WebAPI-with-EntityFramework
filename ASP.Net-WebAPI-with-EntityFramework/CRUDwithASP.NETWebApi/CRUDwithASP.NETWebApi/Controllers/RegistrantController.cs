using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRUDwithASP.NETWebApi.Models;
using Newtonsoft.Json;

namespace CRUDwithASP.NETWebApi.Controllers
{
    [RoutePrefix("api/registrant")]    
    public class RegistrantController : ApiController
    {
        private DemoEntities de = new DemoEntities();

        [AcceptVerbs("GET")]
        [HttpGet]
        public HttpResponseMessage findAll()
        {
            var serializedData = JsonConvert.SerializeObject(de.Registrants.ToList());
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(serializedData);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            return response;
        }

        [AcceptVerbs("GET")]
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage find(string id)
        {
            int _id = Convert.ToInt32(id);
            var serializedData = JsonConvert.SerializeObject(de.Registrants.Find(_id));
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(serializedData);
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            return response;
        }
        [AcceptVerbs("POST")]
        [HttpPost]
        public void create(Registrant registrant)
        {
            de.Registrants.Add(registrant);
            de.SaveChanges();
        }
        [AcceptVerbs("PUT")]
        [HttpPut]
        public void update(Registrant registrant)
        {
            de.Entry<Registrant>(registrant).State = System.Data.EntityState.Modified;
            de.SaveChanges();
            
        }

        [HttpDelete]
        [Route("{id}")]
        public void delete(string id)
        {
            de.Registrants.Remove(de.Registrants.Find(id));
            de.SaveChanges();
        }



    }
}
