namespace _01_Framework.Application
{
    public class ValidationMessages
    {
       
        public const string RequiredMessage = "وارد نمودن {0} الزامی است";
        public const string EmailAddressMessage = "ایمیل وارد شده صحیح نمی باشد";
        public const string StringLengthMessage = "{0} باید دارای حداقل {2} کاراکتر و حداکثر دارای {1} کاراکتر باشد";
        public const string ComparePassword = "کلمه عبور وارد شده با تکرار کلمه عبور مطابقت ندارد.";
        public const string RegularExpressionMobile = "شماره موبایل را صحیح وارد کنید";
        public const string RegularExpressionEmail = "ایمیل وارد شده صحیح نمی باشد";
        public const string RequiredLaw = "قوانین سایت را باید بپذیرید";
        public const string MaxLengthMessage = "{0}نباید بیشتر از {1} باشد";
        public const string RequiredMessageIntType = "مقدار عددی وارد کنید";
        public const string MaxFileSize = "فایل حجیم تر از حد مجاز است";
        public const string InValidFileFormat = "فرمت فایل مجاز نیست";
        //---------category
        public const string DuplicateFaTitleMessage = " عنوان فارسی تکراری است";
        public const string DuplicateEnTitleMessage = " عنوان انگلیسی تکراری است";
        public const string EmpitySubCatMessage = "دسته والد را انتخاب کنید";
    }
}