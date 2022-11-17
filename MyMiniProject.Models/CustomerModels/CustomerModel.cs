using System.ComponentModel.DataAnnotations;
using EShop.Common.Constants;
using MyMiniProject.Common.Constants;
namespace MyMiniProject.Models.CustomerModels;

public class CustomerModel
{
    [Display(Name = TranslateEnglishToPersian.Firstname)]
    [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
    [MaxLength(50, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
    [RegularExpression(CustomRegularExpressions.RegPersianLan, ErrorMessage = CustomRegularExpressions.RegularExpressionCharToPersianhMessage)]
    public string Firstname { get; set; }
    [Display(Name = TranslateEnglishToPersian.Lastname)]
    [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
    [MaxLength(50, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
    [RegularExpression(CustomRegularExpressions.RegPersianLan, ErrorMessage = CustomRegularExpressions.RegularExpressionCharToPersianhMessage)]

    public string Lastname { get; set; }
    [Display(Name = TranslateEnglishToPersian.DateOfBirth)]
    public DateTime DateOfBirth { get; set; }
    [Display(Name = TranslateEnglishToPersian.PhoneNumber)]
    [MaxLength(10, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
    public string PhoneNumber { get; set; }
    [Display(Name = TranslateEnglishToPersian.Email)]
    [RegularExpression(CustomRegularExpressions.RegExpEmail, ErrorMessage = AttributesErrorMessages.RegularExpressionMessage)]
    public string Email { get; set; }
    [Display(Name = TranslateEnglishToPersian.BankAccountNumber)]
    [Required(ErrorMessage = AttributesErrorMessages.RequiredMessage)]
    [MaxLength(16, ErrorMessage = AttributesErrorMessages.MaxLengthMessage)]
    public string BankAccountNumber { get; set; }
}
