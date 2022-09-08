
using EMarket.Entities;
using EMarket.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EMarket.Data
{
    /// <summary>Copy of Microsoft.AspNetCore.Identity UserValidator with added SiteId checking</summary>
    public class ApplicationUserValidator<TUser> : UserValidator<TUser> where TUser : ApplicationUser
    {
        public ApplicationUserValidator(IOptions<IdentityOptions> optionsAccessor, IdentityErrorDescriber errors = null)
        {
            Options = optionsAccessor?.Value ?? new IdentityOptions();
            Describer = errors ?? new IdentityErrorDescriber();
        }

        protected internal IdentityOptions Options { get; set; }

        public new IdentityErrorDescriber Describer { get; private set; }

        public override async Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user)
        {
            if (manager == null) throw new ArgumentNullException(nameof(manager));
            if (user == null) throw new ArgumentNullException(nameof(user));
            var errors = new List<IdentityError>();
            if (Options.User.RequireUniqueEmail) await ValidateEmail(manager, user, errors);

            return errors.Count > 0 ? IdentityResult.Failed(errors.ToArray()) : IdentityResult.Success;
        }

        private async Task ValidateUserName(UserManager<TUser> manager, TUser user, ICollection<IdentityError> errors)
        {
            var userName = await manager.GetUserNameAsync(user);
            if (string.IsNullOrWhiteSpace(userName)) errors.Add(Describer.InvalidUserName(userName));
            else if (!string.IsNullOrEmpty(Options.User.AllowedUserNameCharacters) && userName.Any(c => !Options.User.AllowedUserNameCharacters.Contains(c))) errors.Add(Describer.InvalidUserName(userName));
            else
            {
                var owner = await manager.FindByNameAsync(userName);
                if (owner != null && !string.Equals(await manager.GetUserIdAsync(owner), await manager.GetUserIdAsync(user)) && owner.CustomerCode == Startup.CustomerCode) errors.Add(Describer.DuplicateUserName(userName));
            }
        }

        private async Task ValidateEmail(UserManager<TUser> manager, TUser user, List<IdentityError> errors)
        {
            var email = await manager.GetEmailAsync(user);
            if (string.IsNullOrWhiteSpace(email)) { errors.Add(Describer.InvalidEmail(email)); return; }
            var owner = await manager.FindByEmailAsync(email);
            if (owner != null && !string.Equals(await manager.GetUserIdAsync(owner), await manager.GetUserIdAsync(user)) && owner.CustomerCode == Startup.CustomerCode) errors.Add(Describer.DuplicateEmail(email));
        }
    }

    /// <summary>Simple derivation of base class removing all Microsoft.AspNetCore.Identity UserValidator</summary>
    public class ApplicationUserManager<TUser> : UserManager<TUser> where TUser : ApplicationUser
    {
        public ApplicationUserManager(
            IUserStore<TUser> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<TUser> passwordHasher,
            IEnumerable<IUserValidator<TUser>> userValidators,
            IEnumerable<IPasswordValidator<TUser>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<TUser>> logger
            ) : base(
                store,
                optionsAccessor,
                passwordHasher,
                userValidators.Where(p => p.GetType().Namespace != "Microsoft.AspNetCore.Identity"),
                passwordValidators,
                keyNormalizer,
                errors,
                services,
                logger)
        { }
    }

    /// <summary>Derivation of base class overriding all functions that need SiteId checking</summary>
    public class ApplicationUserStore : UserStore<ApplicationUser, IdentityRole<string>, PostgreSqlContext, string>
    {
        public ApplicationUserStore(PostgreSqlContext context,  IdentityErrorDescriber describer = null) : base(context, describer)
        { }

        public override Task<ApplicationUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            // return Users.FirstOrDefaultAsync(u => u.NormalizedEmail == normalizedEmail && (u.CustomerCode == Startup.CustomerCode), cancellationToken);
            return Users.FirstOrDefaultAsync(u => u.NormalizedEmail == normalizedEmail, cancellationToken);
        }

        public override Task<ApplicationUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            return Users.FirstOrDefaultAsync(u => u.NormalizedUserName == normalizedUserName && (u.CustomerCode == Startup.CustomerCode), cancellationToken);
        }
    }
}