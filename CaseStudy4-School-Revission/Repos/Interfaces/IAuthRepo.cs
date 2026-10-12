using CaseStudy4_School_Revission.DTOs.ApplicationUserDTOs;

namespace CaseStudy4_School_Revission.Repos.Interfaces
{
    public interface IAuthRepo
    {
        Task<bool> Register(RegisterDTO dto);
        Task<string?> Login(LoginDTO dto);
    }
}
