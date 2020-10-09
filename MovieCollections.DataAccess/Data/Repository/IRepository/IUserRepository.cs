using Microsoft.AspNetCore.Mvc.Rendering;
using MovieCollections.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCollections.DataAccess.Data.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        void Update(User user);

    }
}
