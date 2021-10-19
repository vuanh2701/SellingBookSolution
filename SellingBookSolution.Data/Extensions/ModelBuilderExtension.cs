using SellingBookSolution.Data.Entities;
using SellingBookSolution.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingBookSolution.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
               new AppConfig() { Key = "HomeTitle", Value = "This is home page of BookStoreSolution" },
               new AppConfig() { Key = "HomeKeyword", Value = "This is keyword of BookStoreSolution" },
               new AppConfig() { Key = "HomeDescription", Value = "This is description of BookStoreSolution" }
               );

            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en", Name = "English", IsDefault = false });

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 1,
                    Status = Status.Active,
                },
                 new Category()
                 {
                     Id = 2,
                     IsShowOnHome = true,
                     ParentId = null,
                     SortOrder = 2,
                     Status = Status.Active
                 });

            modelBuilder.Entity<CategoryTranslation>().HasData(
                  new CategoryTranslation() { Id = 1, CategoryId = 1, Name = "Sách thiếu nhi", LanguageId = "vi", SeoAlias = "sach-thieu-nhi", SeoDescription = "Sản phẩm sách thiếu nhi", SeoTitle = "Sản phẩm sách thiếu nhi" },
                  new CategoryTranslation() { Id = 2, CategoryId = 1, Name = "Children's books", LanguageId = "en", SeoAlias = "children's-books", SeoDescription = "The books for children", SeoTitle = "The books for children" },
                  new CategoryTranslation() { Id = 3, CategoryId = 2, Name = "Sách văn học", LanguageId = "vi", SeoAlias = "sach-van-hoc", SeoDescription = "Sản phẩm sách văn học", SeoTitle = "Sản phẩm sách văn học" },
                  new CategoryTranslation() { Id = 4, CategoryId = 2, Name = "Literature", LanguageId = "en", SeoAlias = "literature", SeoDescription = "Literature field book", SeoTitle = "Literature field book" }
                    );

            modelBuilder.Entity<Product>().HasData(
           new Product()
           {
               Id = 1,
               DateCreated = DateTime.Now,
               OriginalPrice = 100000,
               Price = 200000,
               Stock = 0,
               ViewCount = 0,
           });
            modelBuilder.Entity<ProductTranslation>().HasData(
                 new ProductTranslation()
                 {
                     Id = 1,
                     ProductId = 1,
                     Name = "Dế Mèn phiêu lưu ký",
                     LanguageId = "vi",
                     SeoAlias = "de-men-phieu-luu-ky",
                     SeoDescription = "Dế Mèn phiêu lưu ký",
                     SeoTitle = "Dế Mèn phiêu lưu ký",
                     Details = "Dế Mèn phiêu lưu ký",
                     Description = "Dế Mèn phiêu lưu ký"
                 },
                    new ProductTranslation()
                    {
                        Id = 2,
                        ProductId = 1,
                        Name = "De-men-phieu-luu-ky",
                        LanguageId = "en",
                        SeoAlias = "de-men-phieu-luu-ky",
                        SeoDescription = "de-men-phieu-luu-ky",
                        SeoTitle = "de-men-phieu-luu-ky",
                        Details = "de-men-phieu-luu-ky",
                        Description = "de-men-phieu-luu-ky"
                    });


            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { ProductId = 1, CategoryId = 1 }
                );

            //any guid
            var roleId = new Guid("2E8EED33-489E-4F4A-80FB-9B04532690A5");
            var adminId = new Guid("8CE4B19B-15FC-4F01-A831-97319F99622C");


            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "vuanh2701@gmail.com",
                NormalizedEmail = "vuanh2701@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                SecurityStamp = string.Empty,
                FirstName = "Vu",
                LastName = "Nguyen",
                Dob = new DateTime(2020, 01, 31)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });

            modelBuilder.Entity<Slide>().HasData(
              new Slide()
              {
                  Id = 1,
                  Name = "Second Thumbnail label"
                  ,
                  Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.",
                  SortOrder = 1,
                  Url = "#",
                  Image = "/themes/images/carousel/1.png",
                  Status = Status.Active
              },
              new Slide() 
              { 
                  Id = 2,
                  Name = "Second Thumbnail label",
                  Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.",
                  SortOrder = 2,
                  Url = "#",
                  Image = "/themes/images/carousel/2.png",
                  Status = Status.Active
              },
              new Slide()
              { 
                  Id = 3,
                  Name = "Second Thumbnail label", 
                  Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.",
                  SortOrder = 3, 
                  Url = "#",
                  Image = "/themes/images/carousel/3.png", 
                  Status = Status.Active 
              },
              new Slide() { Id = 4, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 4, Url = "#", Image = "/themes/images/carousel/4.png", Status = Status.Active },
              new Slide() { Id = 5, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 5, Url = "#", Image = "/themes/images/carousel/5.png", Status = Status.Active },
              new Slide() { Id = 6, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 6, Url = "#", Image = "/themes/images/carousel/6.png", Status = Status.Active }
              );
        }
    }
}
