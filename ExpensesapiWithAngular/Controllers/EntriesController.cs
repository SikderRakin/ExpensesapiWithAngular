using ExpensesapiWithAngular.Data;
using ExpensesapiWithAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ExpensesapiWithAngular.Controllers
{
    [EnableCors("http://localhost:4200","*","*")]
    public class EntriesController : ApiController
    {[HttpGet]
        public IHttpActionResult GetEntires()
        { 
            try
            {
                using (var context = new AppDbContext())
                {
                    var entries = context.Entries.ToList();
                    return Ok(entries);
                }

            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
                throw;
            }
          
        }
        [HttpPost]
        public IHttpActionResult PostEntrise([FromBody]Entry entry) {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                using (var context = new AppDbContext())
                {   //Entries is table name
                    context.Entries.Add(entry);
                    context.SaveChanges();
                    return Ok("Thank you");

                }
            }
            catch(Exception ex)
            {
                BadRequest(ex.Message);
                throw;
            }
           


        }
        [HttpPut]
        //The first parameter is going to be the id, and by using this id we are going to get the old entry from our database.And the new one is going to be the new entry, which are going to send us a part of our request body.So let us right in here that the object type is going to be Entry and let us name it entry
        public IHttpActionResult UpdateEntries(int id,[FromBody]Entry entry)
        {
            if (ModelState.IsValid) return BadRequest(ModelState);
            if (id != entry.Id) return BadRequest();
            try
            {
                using (var context = new AppDbContext())
                {
                    var oldEntry = context.Entries.FirstOrDefault(n => n.Id == id);
                    if (oldEntry == null) return NotFound();
                    oldEntry.Description = entry.Description;
                    oldEntry.IsExpense = entry.IsExpense;
                    oldEntry.Value = entry.Value;
                    context.SaveChanges();
                    return Ok("Entry Updated");


                }
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
                throw;
            }

           
        }
    }
}
