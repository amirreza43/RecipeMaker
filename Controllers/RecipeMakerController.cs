using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RecipeMaker
{
    
    [ApiController]
    [Route("api/recipe")]
    public class RecipeMakerController : ControllerBase{

        private Database _db;
        public RecipeMakerController(Database db){
            _db = db;
        }

        [HttpPost]
        public IActionResult CreateRecipe(Recipe recipe){
            

            _db.Add(recipe);
            _db.SaveChanges();

            return Ok(recipe);
        }

        [HttpGet("all")]
        public IActionResult GetAll(){

            var recipes = _db.Recipes.ToList();

            return Ok(recipes);
        }

        [HttpGet]
        public IActionResult Search(string ingredientName){

            var recipes = _db.Recipes.Where(r => r.Ingredients.Contains(ingredientName));

            return Ok(recipes);
        }


    }


}