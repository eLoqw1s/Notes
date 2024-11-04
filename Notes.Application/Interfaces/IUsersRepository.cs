﻿using Notes.Domain.Models;

namespace Notes.Application.Interfaces
{
    public interface IUsersRepository
    {
        Task Add(User user);
        Task<User> GerByEmail(string email);
    }
}