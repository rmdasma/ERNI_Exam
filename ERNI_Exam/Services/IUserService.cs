using ERNI_Exam.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERNI_Exam.Services
{
    public interface IUserService
    {
        Task<List<UserModel>> GetUsers();
    }
}