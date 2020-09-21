using home.Api.Data;
using home.Api.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace home.Api.Servcie
{
    public class UserService : IUserService
    {
        private readonly HomeContext homeContext;

        public UserService(HomeContext homeContext)
        {
            this.homeContext = homeContext;
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user">用户</param>
        public void AddUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            user.Id = Guid.NewGuid();
            user.CreateTime = DateTime.Now;
            if(user.HomeBases != null)
            {
                foreach (var homeBase in user.HomeBases)
                {
                    homeBase.Id = Guid.NewGuid();
                }
            }
            homeContext.Users.Add(user);
        }
        /// <summary>
        /// 查找指定用户
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public async Task<User> GetUser(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentNullException(nameof(userId));
            return await homeContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
        }
        /// <summary>
        /// 查找所有用户
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await homeContext.Users.ToListAsync();
        }

        public async Task SaveAsync()
        {
            await homeContext.SaveChangesAsync();
        }
    }
}
