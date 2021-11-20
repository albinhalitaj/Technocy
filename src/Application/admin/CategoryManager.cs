using System;
using System.Collections.Generic;
using Application.Models;
using AutoMapper;
using Data.admin;
using Domain.Entities;

namespace Application.admin
{
    public class CategoryManager
    {
        private readonly CategoryDal _categoryManager;
        private readonly IMapper _mapper;

        public CategoryManager(CategoryDal categoryManager,IMapper mapper)
        {
            _categoryManager = categoryManager;
            _mapper = mapper;
        }

        public IEnumerable<Category> GetCategories() => _categoryManager.GetCategories();

        public InsertCategoryModel GetCategory(int id)
        {
            var category = _mapper.Map<InsertCategoryModel>(_categoryManager.GetCategory(id));
            return category;
        }

        public CategoryResult Add(InsertCategoryModel model)
        {
            var categoryResult = new CategoryResult();
            
            var category = _mapper.Map<Category>(model);
            category.Status = true;
            category.CreatedAt = DateTime.Now;
            
            var result = _categoryManager.Insert(category);
            categoryResult.Succeeded = result;
            return categoryResult;

        }

        public CategoryResult Update(int id, InsertCategoryModel model)
        {
            var categoryResult = new CategoryResult();
            var category = _mapper.Map<Category>(model);
            category.LastUpdatedAt = DateTime.Now;
            var status = false;
            try
            {
                status = _categoryManager.Update(id, category);
            }
            catch (Exception e)
            {
                categoryResult.Errors.Add(e.Message);
            }
            categoryResult.Succeeded = status;

            return categoryResult;
        }

        public bool Delete(int id) => _categoryManager.Delete(id);
    }
}