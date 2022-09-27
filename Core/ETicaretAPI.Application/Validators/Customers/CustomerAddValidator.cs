using ETicaretAPI.Application.ViewModels.CustomerVM;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Customers
{
    public class CustomerAddValidator:AbstractValidator<CustomerAddVM>
    {
        public CustomerAddValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Lütfen isim alanını boş geçmeyiniz").MinimumLength(5).MaximumLength(15).WithMessage("Lütfen en az 5 en çok 15 karakter giriniz");
        }
    }
}
