
using Microsoft.EntityFrameworkCore;

namespace  BryanGabeDAL.Models {
    [Keyless]
 public class LoginUser {
    public string DisplayName {get; set;} = null!;
    public string Password {get; set;} = null!;
    }   
}