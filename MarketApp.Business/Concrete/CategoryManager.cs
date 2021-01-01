using MarketApp.Business.Abstract;
using MarketApp.DataAccess.Abstract;
using MarketApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApp.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void Create(Category entity)
        {
            _categoryRepository.Create(entity);
        }

        public void Delete(Category entity)
        {
             _categoryRepository.Delete(entity);
        }

        public void DeleteFromCategory(int categoryId, int productId)
        {
            _categoryRepository.DeleteFromCategory(categoryId, productId);
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public Category GetByIdWithProducts(int id)
        {
            return _categoryRepository.GetByIdWithProducts(id);
        }

        public void Update(Category entity)
        {
             _categoryRepository.Update(entity);
        }
    }
}
