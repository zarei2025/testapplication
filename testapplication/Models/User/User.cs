using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace testapplication.Models
{
    public class User
    {
        public long Id { get; set; }

        [Display(Name = "کدملی")]
        [Required(ErrorMessage = "این فیلد اجباری است.")]
        [MaxLength(10, ErrorMessage = "حئاکتر 10 کاراکتر مجاز است.")]
        [MinLength(10, ErrorMessage = "حداقل 10 کاراکتر وارد کنید.")]
        public string NationalCode { get; set; }

       [Required(ErrorMessage = "این فیلد اجباری است.")]
        [MaxLength(12, ErrorMessage = "حئاکتر 12 کاراکتر مجاز است.")]
        [MinLength(8, ErrorMessage = "حداقل 8 کاراکتر وارد کنید.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است.")]
        [MaxLength(12, ErrorMessage = "حئاکتر 12 کاراکتر مجاز است.")]
        [MinLength(8, ErrorMessage = "حداقل 8 کاراکتر وارد کنید.")]
        [Compare("Password",ErrorMessage = "تکرار رمز عبور مطابقت ندارد")]
        public string RepeatPassword { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است.")]
        [MaxLength(12, ErrorMessage = "حئاکتر 12 کاراکتر مجاز است.")]
        [MinLength(8, ErrorMessage = "حداقل 8 کاراکتر وارد کنید.")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است.")]
        public string LastName { get; set; }

        public bool Status { get; set; }

        
        public bool MainUser { get; set; }

        public string FatherName { get; set; }

        [MaxLength(11, ErrorMessage = "حئاکتر 11 کاراکتر مجاز است.")]
        [MinLength(11, ErrorMessage = "حداقل 11 کاراکتر وارد کنید.")]
        public string PhoneNumber { get; set; }

        [MaxLength(11, ErrorMessage = "حئاکتر 11 کاراکتر مجاز است.")]
        [MinLength(11, ErrorMessage = "حداقل 11 کاراکتر وارد کنید.")]
        public string HomePhone { get; set; }

        public char Gender { get; set; }

        public int Province { get; set; }

        public int City { get; set; }

        public string Address { get; set; }


        [MaxLength(10, ErrorMessage = "حئاکتر 10 کاراکتر مجاز است.")]
        [MinLength(10, ErrorMessage = "حداقل 10 کاراکتر وارد کنید.")]
        public string PostalCode { get; set; }

        [EmailAddress] public string Email { get; set; }

        [Required(ErrorMessage = "فیلد تاریخ تولد اجباری است.")]
        public DateTime BirthDate { get; set; }

        public string BirthPlace { get; set; }

        public int DegreeEducation { get; set; }

        public string Job { get; set; }

        public string WorkPlace { get; set; }


        [MaxLength(10, ErrorMessage = "حئاکتر 10 کاراکتر مجاز است.")]
        [MinLength(10, ErrorMessage = "حداقل 10 کاراکتر وارد کنید.")]
        public string WorkPostalCode { get; set; }
        
        [MaxLength(11, ErrorMessage = "حئاکتر 11 کاراکتر مجاز است.")]
        [MinLength(11, ErrorMessage = "حداقل 11 کاراکتر وارد کنید.")]
        public string WorkPhone { get; set; }

        public string Nationality { get; set; }

        public int Religion { get; set; }

        public string Sect { get; set; }


        public int MilitaryStatus { get; set; }

        public List<UserType> UserFamily { get; set; }

        public UserType UserType { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است.")]
        public string birthdatestring { get; set; }

        public SelectList DegreeEducationList { get; set; }

        public SelectList ProvinceList { get; set; }

        public SelectList ReligionList { get; set; }
        public SelectList MilitaryStatusList { get; set; }

        //public SelectList FamilyTypeList { get; set; }


        public SelectList CityList { get; set; }

        public List<Item> CityItemList { get; set; }



        public User(string nationalCode, string password, string firstName, string lastName)
        {
            NationalCode = nationalCode;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
        }

        public User( string nationalCode, string firstName, string lastName)
        {
           
            NationalCode = nationalCode;
            FirstName = firstName;
            LastName = lastName;
        }

        public User(long Id, string nationalCode, string firstName, string lastName)
        {
            this.Id = Id;
            NationalCode = nationalCode;
            FirstName = firstName;
            LastName = lastName;
        }

        public User()
        {
        }

        public User(string nationalCode, string firstName, string lastName, bool status, bool mainUser, string fatherName, string phoneNumber, string homePhone, char gender, int province, int city, string address, string postalCode, string email, DateTime birthDate, string birthPlace, int degreeEducation, string job, string workPlace, string workPostalCode, string workPhone, string nationality, int religion, string sect, int militaryStatus)
        {
            NationalCode = nationalCode;
            //Password = password;
            FirstName = firstName;
            LastName = lastName;
            Status = status;
            MainUser = mainUser;
            FatherName = fatherName;
            PhoneNumber = phoneNumber;
            HomePhone = homePhone;
            Gender = gender;
            Province = province;
            City = city;
            Address = address;
            PostalCode = postalCode;
            Email = email;
            BirthDate = birthDate;
            BirthPlace = birthPlace;
            DegreeEducation = degreeEducation;
            Job = job;
            WorkPlace = workPlace;
            WorkPostalCode = workPostalCode;
            WorkPhone = workPhone;
            Nationality = nationality;
            Religion = religion;
            Sect = sect;
            MilitaryStatus = militaryStatus;
            birthdatestring = Tools.ToPersianNumber(Tools.ToFarsi(birthDate));
        }
    }
}