using BryanGabeDAL.Models;

namespace BryanGabeDAL;
public class CommonRepository
{
    private readonly ChaosSoftwareContext _context;
    public CommonRepository()
    {
        _context = new ChaosSoftwareContext();
    }
}

