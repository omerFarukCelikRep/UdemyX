﻿using UdemyMS.Microservices.Catalog.Entities.Dtos.Categories;

namespace UdemyMS.Microservices.Catalog.Entities.DbSets;
public class Category : BaseEntity<ObjectId>
{
    public string Name { get; set; } = string.Empty;

    public static implicit operator CategoryListDto(Category category) => new()
    {
        Id = category.Id.ToString(),
        Name = category.Name
    };

   