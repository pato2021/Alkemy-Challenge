using BudgetManagerApp.BLL.DTO;
using BudgetManagerApp.BLL.Infrastructure;
using BudgetManagerApp.BLL.Interfaces;
using BudgetManagerApp.DAL.Entities;
using BudgetManagerApp.DAL.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagerApp.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                await Database.UserManager.CreateAsync(user, userDto.Password);

                UserProfile userProfile = new UserProfile
                {
                    Id = user.Id,
                    Name = userDto.Name,
                    Address = userDto.Address,              
                };
                Database.UserProfileManager.Create(userProfile);
                await Database.SaveAsync();
                return new OperationDetails(true, "Registro completado con éxito", "");
            }
            else
            {
                return new OperationDetails(false, "Ya existe un usuario con este inicio de sesión", "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;

            ApplicationUser user = await Database.UserManager.FindAsync(userDto.Email, userDto.Password);

            if (user != null)
                claim = await Database.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }


        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
