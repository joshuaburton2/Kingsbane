using System.Threading.Tasks;
using Kingsbane.Database;

namespace InitDatabase
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await using var kbContext = new KingsbaneContext("Server=.\\SQLEXPRESS;Database=Kingsbane;Trusted_Connection=True;MultipleActiveResultSets=true");
            await DbInitialiser.Initialize(kbContext);
        }
    }
}
