﻿using MedicalStoreWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity.Migrations;

namespace MedicalStoreWebApi.Controllers
{
    [Authorize(Roles ="Admin")]
    public class CategoriesController : ApiController
    {
        private MedicalStoreDbContext db;
        public CategoriesController()
        {
            db = new MedicalStoreDbContext();
        }


        // GET: api/Categories
        [AllowAnonymous]
        public IHttpActionResult GetCategories()
        {
            var categories = db.Categories.ToList();

             if(categories.Count == 0)
             {
                return NotFound();
             }

             return Ok(categories);
        
        }

        // GET: api/Categories/5
        [AllowAnonymous]
        public async Task<IHttpActionResult> GetCategory(int id)
        {
            var category = await db.Categories.FindAsync(id);
            
            if(category is null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // POST: api/Categories
        public async Task<IHttpActionResult> PostAddCat([FromBody]Category category)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            db.Categories.Add(category);
            await db.SaveChangesAsync();
            return Created("created successfully", category);
        }

        // PUT: api/Categories/5
        public async Task<IHttpActionResult> PutEditCat(Category category)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var catChk = await db.Categories.FindAsync(category.ID);

            if(catChk is null)
            {
                return NotFound();
            }

            db.Categories.AddOrUpdate(category);
            await db.SaveChangesAsync();

            return Created("updated successfully", category);
        }

        // DELETE: api/Categories/5
        public async Task<IHttpActionResult> DeleteCat(int id)
        {
            var category = await db.Categories.FindAsync(id);
            
            if(category is null)
            {
                NotFound();
            }

            db.Categories.Remove(category);
            await db.SaveChangesAsync();

            return Ok("Deleted successfully");
        }
    }
}