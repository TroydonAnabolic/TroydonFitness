using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Schema;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TroydonFitnessWebsite.Areas.Identity.Data.CustomIdentityConfig.IdentityModel;

namespace TroydonFitnessWebsite.Areas.Identity.Data.CustomIdentityConfig
{
    public class AdditionalUserClaimsPrincipalFactory
		 : UserClaimsPrincipalFactory<TroydonFitnessWebsiteUser, IdentityRole>
	{
		public AdditionalUserClaimsPrincipalFactory(
			UserManager<TroydonFitnessWebsiteUser> userManager,
			RoleManager<IdentityRole> roleManager,
			IOptions<IdentityOptions> optionsAccessor)
			: base(userManager, roleManager, optionsAccessor)
		{ }


        public async override Task<ClaimsPrincipal> CreateAsync(TroydonFitnessWebsiteUser user)
		{
			const string Issuer = "https://troydonfitness.com"; //TODO: change to the official websitename when live

			var principal = await base.CreateAsync(user);
			var identity = (ClaimsIdentity)principal.Identity;

			var claims = new List<Claim>();
			if (user.IsAdmin)
			{
				claims.Add(new Claim(JwtClaimTypes.Role, "Admin", Issuer)); //TODO: Add issuer to all claims when i am cleaning up
			}
			else if (user.IsMasterAdmin)
			{
				claims.Add(new Claim(JwtClaimTypes.Role, "Master Admin", Issuer));
			}
			else
			{
				claims.Add(new Claim(JwtClaimTypes.Role, "Standard User", Issuer));
			}

			identity.AddClaims(claims);
			return principal;
		}

		protected override async Task<ClaimsIdentity> GenerateClaimsAsync(TroydonFitnessWebsiteUser user)
		{
			var identity = await base.GenerateClaimsAsync(user);
			// Below claims determine if user can place orders for supplements and training equipment, as it will not be allowed if they do not have appropriate profile info filled
			// only add claims if the user info is present
			if (user.FirstName != null)
				identity.AddClaim(new Claim(JwtClaimTypes.GivenName, user.FirstName ));
			if (user.LastName != null)
				identity.AddClaim(new Claim(JwtClaimTypes.FamilyName, user.LastName ));
			if (user.EmailConfirmed)
				identity.AddClaim(new Claim(JwtClaimTypes.EmailVerified, user.EmailConfirmed.ToString()));
			if (user.DateOfBirth.ToString() != "1/01/0001 12:00:00 AM")
				identity.AddClaim(new Claim(JwtClaimTypes.BirthDate, user.DateOfBirth.ToString()));
			//if(user.AddressLine1.Equals("N/A", System.StringComparison.OrdinalIgnoreCase))
			//	identity.AddClaim(new Claim(JwtClaimTypes.Address, user.AddressLine1 ));
			if (user.AddressLine2 != null)
				identity.AddClaim(new Claim("AddressLine2", user.AddressLine2));
			if (user.City != null)
				identity.AddClaim(new Claim("City", user.City));
			if (user.State != null)
				identity.AddClaim(new Claim("State", user.State));
			if (user.Zip != null)
				identity.AddClaim(new Claim("Zip", user.Zip));
			if (user.PhoneNumber != null)
				identity.AddClaim(new Claim(JwtClaimTypes.PhoneNumber, user.PhoneNumber));
			// for creating orders for diet and training equipment the below claims are needed in addition to the above, as I need the below info in order to come up with a diet / training solution
			if (user.Bodyfat != 0.0d) // check if it has default value for double
				identity.AddClaim(new Claim("Bodyfat", user.Bodyfat.ToString()));
			if (user.Gender.ToString() != "Undefined")
				identity.AddClaim(new Claim(JwtClaimTypes.Gender, user.Gender.ToString()));
			if (user.Height != 0.0d)
				identity.AddClaim(new Claim("Height", user.Height.ToString()));
			if (user.Weight != 0.0d)
				identity.AddClaim(new Claim("Weight", user.Weight.ToString()));
			if (user.ActivityType.ToString() != "Undefined")
				identity.AddClaim(new Claim("ActivityType", user.ActivityType.ToString()));
			return identity;
		}
	}
}