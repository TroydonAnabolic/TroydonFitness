using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TroydonFitnessWebsite.Areas.Identity.Data;
using TroydonFitnessWebsite.Data;

namespace TroydonFitnessWebsite.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<TroydonFitnessWebsiteUser> _userManager;
        private readonly SignInManager<TroydonFitnessWebsiteUser> _signInManager;


        public IndexModel(
            UserManager<TroydonFitnessWebsiteUser> userManager,
            SignInManager<TroydonFitnessWebsiteUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            #region PersonalDetails

            // Personal Data to be added here if possible
            [DataType(DataType.Text)]
            [Display(Name = "Address Line 1")]
            public string AddressLine1 { get; set; }
            [DataType(DataType.Text)]
            [Display(Name = "Address Line 2")]
            public string AddressLine2 { get; set; }
            [DataType(DataType.Text)]
            public string City { get; set; }
            [DataType(DataType.Text)]
            public string State { get; set; }
            [DataType(DataType.Text)]
            public string Zip { get; set; }

            [DataType(DataType.Date)] //TODO: Add this to personal info page
            [Display(Name = "Date Of Birth")]
            public DateTime DateOfBirth { get; set; }

            // BMI Info
            public GenderType? Gender { get; set; }
            public enum GenderType
            {
                Male,
                Female,
            }
            public double Height { get; set; }

            public double Weight { get; set; }

            public ActivityTypeOptions? ActivityType { get; set; } // consider creating a select list like the sample used in selecting prod in personal training TODO
            public enum ActivityTypeOptions
            {
                Sedentary,
                LightExercise,
                ModerateExercise,
                HeavyExercise,
                Athlete
            }

            public double Bodyfat { get; set; }
            #endregion
        }

        private async Task LoadAsync(TroydonFitnessWebsiteUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = phoneNumber,
                // add optional personal info used to calibre
                AddressLine1 = user.AddressLine1,
                AddressLine2 = user.AddressLine2,
                City = user.City,
                Zip = user.Zip,
                DateOfBirth = user.DateOfBirth,
                Gender = (InputModel.GenderType?)user.Gender,
                Height = user.Height,
                Weight = user.Weight,
                ActivityType = (InputModel.ActivityTypeOptions?)user.ActivityType,
                Bodyfat = user.Bodyfat,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            #region AddPersonalDetails

            // Begin adding personal details TODO: Extract to method
            if (Input.FirstName != user.FirstName)
            {
                user.FirstName = Input.FirstName;
            }

            if (Input.LastName != user.LastName)
            {
                user.LastName = Input.LastName;
            }

            if (Input.AddressLine1 != user.AddressLine1)
            {
                user.AddressLine1 = Input.AddressLine1;
            }

            if (Input.AddressLine2 != user.AddressLine2)
            {
                user.AddressLine2 = Input.AddressLine2;
            }

            if (Input.City != user.City)
            {
                user.City = Input.City;
            }

            if (Input.State != user.State)
            {
                user.State = Input.State;
            }
            if (Input.Zip != user.Zip)
            {
                user.Zip = Input.Zip;
            }

            if (Input.DateOfBirth != user.DateOfBirth)
            {
                user.DateOfBirth = Input.DateOfBirth;
            }

            if ((int)Input.Gender != (int)user.Gender)
            {
                user.Gender = (TroydonFitnessWebsiteUser.GenderType)Input.Gender;
            }

            if (Input.Height != user.Height)
            {
                user.Height = Input.Height;
            }

            if (Input.Weight != user.Weight)
            {
                user.Weight = Input.Weight;
            }

            if ((int)Input.ActivityType != (int)user.ActivityType)
            {
                user.ActivityType = (TroydonFitnessWebsiteUser.ActivityTypeOptions)Input.ActivityType;
            }

            if (Input.Bodyfat != user.Bodyfat)
            {
                user.Bodyfat = Input.Bodyfat;
            }
            #endregion

            await _userManager.UpdateAsync(user);


            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
