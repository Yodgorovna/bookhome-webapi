﻿using BookHome.Domain.Entities.Categories;

namespace Bookhome.DataAcces.ViewModels.Books;

public class BookViewModel
{
    public long CategoryId { get; set; }

    public List<Category> Category { get; set; } = new List<Category>();    

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public double Price { get; set; }

    public List<float> Discount { get; set; } = new List<float>();

    public bool IsHardCover { get; set; }
}
