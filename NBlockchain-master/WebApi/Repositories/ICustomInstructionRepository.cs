using System.Collections.Generic;
using BlockCycle.Model;

namespace BlockCycle.WebApi.Repositories
{
    public interface ICustomInstructionRepository
    {
        IEnumerable<BCycle> GetBlocks(string address);
        IEnumerable<Course> GetCourses();
    }
}
