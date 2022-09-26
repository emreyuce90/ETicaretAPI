using ETicaretAPI.Application.ViewModels.ProductsVM;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Products
{
    public class ProductAddValidator:AbstractValidator<ProductAddVM>
    {
        public ProductAddValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Ürün isim alanı boş geçilemez")
                .MinimumLength(5)
                .MaximumLength(250)
                .WithMessage("Lütfen isim alanını en az 5 en fazla 250 karakter olarak giriniz");


            RuleFor(x => x.Stock)
                .NotNull()
                .NotEmpty()
                .WithMessage("Stok alanı boş geçilemez")
                .Must(x => x >= 0)
                .WithMessage("Stok verisi 0(sıfır) dan az olamaz");

            RuleFor(x => x.Price)
            .NotNull()
            .NotEmpty()
            .WithMessage("Fiyat alanı boş geçilemez")
            .Must(x => x >= 0)
            .WithMessage("Fiyat verisi 0(sıfır) dan az olamaz");

        }
    }
}
