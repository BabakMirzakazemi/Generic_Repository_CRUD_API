namespace EShop.Common.Constants;
public static class CustomRegularExpressions
{
    public const string RegExpEmail = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$";
    public const string RegEnglishLan = @"^\w+$";
    public const string RegPersianLan = @"^[\u0600-\u06FF,\u0590-\u05FF\s]*$";
    public const string RegularExpressionCharToEnglishMessage = "نام کاربری باید از حروف انگلیسی تشکیل شده باشد";
    public const string RegularExpressionCharToPersianhMessage = "لطفا تنها از حروف فارسی استفاده نمائید";
}
