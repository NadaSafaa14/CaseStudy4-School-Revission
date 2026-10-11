using CaseStudy4_School_Revission.Data;
using CaseStudy4_School_Revission.Models;
using CaseStudy4_School_Revission.Repos.Interfaces;

namespace CaseStudy4_School_Revission.Repos.Implementations
{
    public class EnrollmentRepo : GenericRepo<Enrollment>, IEnrollmentRepo
    {
        public EnrollmentRepo(AppDbContext context) : base(context)
        {
        }
    }
}
