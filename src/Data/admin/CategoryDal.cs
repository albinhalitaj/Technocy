using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Data.DataAccess;
using Domain.Entities;

namespace Data.admin
{
    public class CategoryDal
    {
        private readonly DataAccessLayer _dataAccessLayer;

        public CategoryDal(DataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        public Category GetCategory(int id)
        {
            using var con = _dataAccessLayer.AppConn(); 
            const string sql = "usp_GetCategory";
            var category = con
                .QueryFirstOrDefaultAsync<Category>(sql, new {id}, commandType: CommandType.StoredProcedure)
                .Result;
            return category ?? null;
        }

        public IEnumerable<Category> GetCategories()
        {
            using var con = _dataAccessLayer.AppConn();
            const string sql = "usp_GetCategories";
            var categories = con.QueryAsync<Category>(sql,commandType: CommandType.StoredProcedure)
                .Result
                .ToList();
            foreach (var category in categories)
            {
                category.ProductsCount = GetCategoryProductsCount(category.CategoryId);
            }
            return categories ?? null;
        }

        public bool Insert(Category category)
        {
            using var con = _dataAccessLayer.AppConn();
            const string sql = "usp_InsertCategory";
            var values = new
            {
                name = category.Name,
                slug = category.Slug,
                description = category.Description,
                visibility = category.Visibility,
                status = category.Status,
                metaTitle = category.MetaTitle,
                metaDescription = category.MetaTitle,
                insertDate = category.CreatedAt
                
            };
            var result = con.ExecuteAsync(sql,values,commandType: CommandType.StoredProcedure).Result;
            return result == 1;
        }

        public bool Delete(int id)
        {
            using var con = _dataAccessLayer.AppConn();
            const string sql = "usp_DeleteCategory";
            int result;
            try
            {
                result = con.ExecuteAsync(sql, new {id}, commandType: CommandType.StoredProcedure).Result;
            }
            catch (Exception)
            {
                return false;
            }
            return result == 1;
        }

        public bool Update(int id, Category category)
        {
            using var con = _dataAccessLayer.AppConn();
            const string sql = "usp_EditCategory";
            var values = new
            {
                id,
                name = category.Name,
                slug = category.Slug,
                description = category.Description,
                visibility = category.Visibility,
                status = category.Status,
                metaTitle = category.MetaTitle,
                metaDescription = category.MetaTitle,
                lastUpdatedDate = category.LastUpdatedAt
            };
            var result = con.ExecuteAsync(sql, values, commandType: CommandType.StoredProcedure).Result;
            return result == 1;
        }

        private int GetCategoryProductsCount(int id)
        {
            using var con = _dataAccessLayer.AppConn();
            const string sql = "usp_GetCategoryProductsCount";
            var result = con.QuerySingle<int>(sql, new {id}, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}