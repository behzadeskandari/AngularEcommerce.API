using AutoMapper;
using Ecommerce.Common.BindingModels;
using Ecommerce.Common.Dtos.UserDto;
using Ecommerce.Common.Interfaces;
using Ecommerce.Common.Models;
using Ecommerce.Common.Statics;
using Ecommerce.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using Microsoft.Identity.Web;

namespace Ecommerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {

        //private IAddressService AddressService { get; }
        private readonly ILogger<AddressController> _logger;
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationUser> _roleManager;
        private readonly IMapper _mapper;


        public AccountController(ILogger<AddressController> logger, UserManager<ApplicationUser> userManger, SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationUser> roleManager,
            IMapper mapper)
        {
            //AddressService = addressService;
            _logger = logger;
            _userManger = userManger;
            _signInManager = signInManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            _logger.LogInformation($"Registration Attempt for {userDto.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest($"Not Found {ModelState}");

            }
            try
            {
                var user = _mapper.Map<ApplicationUser>(userDto);
                
                var result = await _userManger.CreateAsync(user);
                if (!result.Succeeded)
                {
                    return BadRequest($"Error In Creating TryAgain");
                }
                else if(userDto.IsAdmin)
                {
                    if (!await _roleManager.RoleExistsAsync(userDto.Role))
                    {
                        var newRole = new IdentityRole(userDto.Role);
                        var Roleresult = await _roleManager.CreateAsync(user);

                        if (!Roleresult.Succeeded)
                        {
                            // Role creation successful
                            _logger.LogError($"Something went Wrong in the Regiter Method{nameof(Register)}");
                            return Problem($"Something Went Wrong in the {nameof(Register)}", statusCode: 500);
                        }
                    }
                    else
                    {
                        _logger.LogError($"Something went Wrong in the Regiter Method{nameof(Register)}");
                        return Problem($"Something Went Wrong in the {nameof(Register)}", statusCode: 409);
                    }

                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went Wrong in the Regiter Method{nameof(Register)}");
               
                //throw new EntityNotFoundException("Entity Not found", ex.InnerException);
                //return StatusCode(500,$"Internal Server Error Please Try Again ");
                return Problem($"Something Went Wrong in the {nameof(Register)}",statusCode: 500);
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserDto userDto)
        {
            _logger.LogInformation($"Registration Attempt for {userDto.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest($"Not Found {ModelState}");

            }
            try
            {
                var result = await _signInManager.PasswordSignInAsync(userDto.Email, userDto.Password,false,false);
                if (!result.Succeeded)
                {
                    return Unauthorized($"Unauthorized {userDto}");
                }
                else
                {
                    var tempUser = await _userManger.FindByEmailAsync(userDto.Email);
                    var tempUserClaims = _userManger.GetClaimsAsync(tempUser).Result.ToList();
                    userDto.Claims = new List<UserClaimsDto>();
                    foreach (var claim in tempUserClaims)
                    {
                        userDto.Claims.Add(new UserClaimsDto()
                        {
                            ClaimType = claim.Type,
                            ClaimValue = claim.Value
                        });
                    }
                    string role = _userManger.GetRolesAsync(tempUser).Result.FirstOrDefault() ?? "";
                    if (role != UserRoles.Admin)
                    {
                        userDto.Claims.Add(new UserClaimsDto() { ClaimType = UserRoles.Admin, ClaimValue = role });
                    }
                    if (role != UserRoles.User)
                    {
                        userDto.Claims.Add(new UserClaimsDto() { ClaimType = UserRoles.User, ClaimValue = role });
                    }
                    userDto.FirstName = tempUser.FirstName;
                    userDto.LastName = tempUser.LastName;
                    userDto.Role = role;
                    userDto.Email = tempUser.Email;
                }

                return Accepted(userDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went Wrong in the Regiter Method{nameof(Register)}");

                //throw new EntityNotFoundException("Entity Not found", ex.InnerException);
                //return StatusCode(500,$"Internal Server Error Please Try Again ");
                return Problem($"Something Went Wrong in the {nameof(Register)}", statusCode: 500);
            }
        }
        //[HttpPost]
        //public async Task<ActionResult<UserDto>> Login([FromBody] LoginBindingModel model) 
        //{
        //    try
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(model.Email,model.Password,false,false);
        //        var userDto = new UserDto();
        //        if (result != null && result.Succeeded)
        //        {
        //            var tempUser = await _userManger.FindByEmailAsync(model.Email);
        //            var tempUserClaims = _userManger.GetClaimsAsync(tempUser).Result.ToList();
        //            userDto.Claims = new List<UserClaimsDto>();
        //            foreach (var claim in tempUserClaims)
        //            {
        //                userDto.Claims.Add(new UserClaimsDto()
        //                {
        //                    ClaimType = claim.Type,
        //                    ClaimValue = claim.Value
        //                });
        //            }
        //            string role = _userManger.GetRolesAsync(tempUser).Result.FirstOrDefault() ?? "";
        //            if (role != UserRoles.Admin)
        //            {
        //                userDto.Claims.Add(new UserClaimsDto() { ClaimType = UserRoles.Admin, ClaimValue = role });
        //            }
        //            if (role != UserRoles.User)
        //            {
        //                userDto.Claims.Add(new UserClaimsDto() { ClaimType = UserRoles.User, ClaimValue = role });
        //            }
        //            userDto.FirstName = tempUser.FirstName;
        //            userDto.LastName = tempUser.LastName;
        //            userDto.Role = role;
        //            userDto.Email = tempUser.Email;
        //            return userDto;
        //        }
        //        else
        //        {
        //            _logger.LogError("Email or PassWord Is Incorrect...");
        //            return BadRequest("Email or PassWord Is Incorrect");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Bad Request Login...");
        //        throw new EntityNotFoundException("Entity Not found", ex.InnerException);
        //        return BadRequest(ex.Message);
        //    }
        //}




    }
}
