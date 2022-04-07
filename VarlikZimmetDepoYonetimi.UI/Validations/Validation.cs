using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.UI.Models.ApiDTO;

namespace VarlikZimmetDepoYonetimi.UI.Validations
{
    public class Validation : AbstractValidator<AssetAddDTO>
    {
        public Validation()
        {
            RuleFor(x => x.AssetBarcodeID).NotNull().WithMessage("Boş Geçilemez");
            RuleFor(x=>x.RegistrationNumber).NotNull().MaximumLength(30).WithMessage("Boş Geçilemez");
            RuleFor(x => x.SelectedAssetGroup).NotNull().NotEmpty().WithMessage("Boş Geçilemez");
            RuleFor(x => x.SelectedBrand).NotNull().NotEmpty().WithMessage("Boş Geçilemez");
            RuleFor(x => x.SelectedAssetType).NotNull().NotEmpty().WithMessage("Boş Geçilemez");
            RuleFor(x => x.Cost).NotNull().NotEmpty().WithMessage("Boş Geçilemez");
            RuleFor(x => x.PriceID).NotNull().NotEmpty().WithMessage("Boş Geçilmez");
        }
    }
}
