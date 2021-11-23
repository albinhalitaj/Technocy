using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Application.admin;
using Application.Validators;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Models
{
    public class InsertProductModel
    {
        public InsertProductModel()
        {
            Categories = new List<Category>();
        }
        [Required(ErrorMessage = "Kjo fushë është e obligueshme")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Kjo fushë është e obligueshme")]
        public string Slug { get; set; }
        [Required(ErrorMessage = "Kjo fushë është e obligueshme")]
        public string Summary { get; set; }
        [Required(ErrorMessage = "Kjo fushë është e obligueshme")]
        public string Description { get; set; }
        public bool Visibility { get; set; }
        [Required(ErrorMessage = "Kjo fushë është e obligueshme")]
        public int Stock { get; set; }
        [Required(ErrorMessage = "Kjo fushë është e obligueshme")]
        [ProductSkuValidator(ErrorMessage = "test")]
        public string SKU { get; set; }
        [Required(ErrorMessage = "Kjo fushë është e obligueshme")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        [Required(ErrorMessage = "Ju lutem ngarkoni së paku një foto të produktit")]
        public IFormFileCollection ProductGallery { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        [Required(ErrorMessage = "Ju lutem caktoni së paku një kategori")]
        public IEnumerable<string> ProductCategories { get; set; }
        public IEnumerable<ProductGallery> ProductGalleries { get; set; }
    }
}