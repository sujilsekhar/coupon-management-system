using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Omu.Awesome.Mvc;
using Resources;

namespace Infra.Dto
{
    public class Input
    {
        public int Id { get; set; }
    }

    public class UserCreateInput : Input
    {
        [Req]
        [StrLen(15)]
        [LoginUnique]
        public string Login { get; set; }

        [Req]
        [StrLen(20)]
        [UIHint("password")]
        public string Password { get; set; }

        [Req]
        [UIHint("Lookup")]
        [Lookup(Multiselect = true)]
        public IEnumerable<int> Roles { get; set; }
    }

    public class UserEditInput : Input
    {
        [Req]
        [UIHint("Lookup")]
        [Lookup(Multiselect = true)]
        public IEnumerable<int> Roles { get; set; }
    }

    public class ChangePasswordInput : Input
    {
        [Req]
        [StrLen(20)]
        [UIHint("password")]
        public string Password { get; set; }
    }

    public class CountryInput : Input
    {
        [Req]
        [StrLen(20)]
        [Display(ResourceType = typeof(Mui), Name = "Name")]
        public string Name { get; set; }
    }

    public class SignInInput
    {
        [Req]
        // [Display(ResourceType = typeof(Mui), Name = "Login")]
        public string Login { get; set; }

        [Req]
        [UIHint("Password")]
        //   [Display(ResourceType = typeof(Mui), Name = "Password")]
        public string Password { get; set; }

        public bool Remember { get; set; }
    }

    public class ChefInput : Input
    {
        [Req]
        [StrLen(15)]
        [Display(ResourceType = typeof(Mui), Name = "First_Name")]
        public string FirstName { get; set; }

        [Req]
        [StrLen(15)]
        [Display(ResourceType = typeof(Mui), Name = "Last_Name")]
        public string LastName { get; set; }

        [Req]
        [UIHint("AjaxDropdown")]
        [Display(ResourceType = typeof(Mui), Name = "Country")]
        public int? CountryId { get; set; }
    }

    public class MealInput : Input
    {
        [Req]
        [StrLen(50)]
        [Display(ResourceType = typeof(Mui), Name = "Name")]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Mui), Name = "Comments")]
        public string Comments { get; set; }
    }

    public class DinnerInput : Input
    {
        [Req]
        [StrLen(50)]
        [Display(ResourceType = typeof(Mui), Name = "Name")]
        public string Name { get; set; }

        [Req]
        [UIHint("Lookup")]
        [Display(ResourceType = typeof(Mui), Name = "Country")]
        public int? CountryId { get; set; }

        [Req]
        [UIHint("AjaxDropdown")]
        [Display(ResourceType = typeof(Mui), Name = "Chef")]
        public int? ChefId { get; set; }

        [Req]
        [StrLen(20)]
        [Display(ResourceType = typeof(Mui), Name = "Address")]
        public string Address { get; set; }

        [Req]
        [Display(ResourceType = typeof(Mui), Name = "Date")]
        public DateTime? Date { get; set; }

        [Req]
        [UIHint("Lookup")]
        [Lookup(Multiselect = true, Fullscreen = true, Paging = true)]
        [Display(ResourceType = typeof(Mui), Name = "Meals")]
        public IEnumerable<int> Meals { get; set; }
    }

    public class CropInput
    {
        public int ImageHeight { get; set; }
        public int ImageWidth { get; set; }
        public int Id { get; set; }
    }

    public class VendorInput : Input
    {
        [Req]
        [StrLen(50)]
        [Display(ResourceType = typeof(Mui), Name = "Vendor")]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Mui), Name = "PinYin")]
        public string PinYin { get; set; }

        [Display(ResourceType = typeof(Mui), Name = "Comments")]
        public string Comments { get; set; }

        [UIHint("AjaxDropdown")]
        [Display(ResourceType = typeof(Mui), Name = "VendorCategory")]
        public int? CategoryId { get; set; }

    }

    public class CouponInput : Input
    {
        [Req]
        [StrLen(50)]
        [Display(ResourceType = typeof(Mui), Name = "Coupon")]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Mui), Name = "PinYin")]
        public string PinYin { get; set; }

        [Display(ResourceType = typeof(Mui), Name = "Comments")]
        public string Comments { get; set; }

        [Req]
        [UIHint("AjaxDropdown")]
        [Display(ResourceType = typeof(Mui), Name = "Vendor")]
        public int? VendorId { get; set; }

        [Display(ResourceType = typeof(Mui), Name = "Recommended")]
        public bool Recommended { get; set; }

    }

    public class CategoryInput : Input
    {
        [Req]
        [StrLen(50)]
        [Display(ResourceType = typeof(Mui), Name = "VendorCategory")]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Mui), Name = "PinYin")]
        public string PinYin { get; set; }

        [Display(ResourceType = typeof(Mui), Name = "Comments")]
        public string Comments { get; set; }
    }

}