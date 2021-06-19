using System.Threading.Tasks;

namespace UserManagement.Infrastructure.Managers
{
    public interface ISeedManager
    {
        Task InitializeAsync();
    }
}
