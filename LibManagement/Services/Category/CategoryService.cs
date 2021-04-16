using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibManagement.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore; 

namespace LibManagement.Services
{
    public class CategoryService : ICategoryService
    {
        private LibraryDBContext _context;
        public CategoryService(LibraryDBContext context)
        {
            _context = context;
        }
        public  bool Create(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return true;
            }
            catch 
            {   
                return false;
            }




        }

        public bool Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
            try
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return true;

            }
            catch 
            {
                return false;
            }

        }

        public List<Category> GetAll()
        {
            return _context.Categories.Include(x => x.Books).ToList();
        }

        public bool Update(Category category)
        {
            try
            {
                var item = _context.Categories.FirstOrDefault(x => x.CategoryId == category.CategoryId);
                item.CategoryId = category.CategoryId;
                item.CategoryName = category.CategoryName;
                _context.SaveChanges();
                return true;
           
            }
            catch 
            {
                return false;
            }

        }
    }
}