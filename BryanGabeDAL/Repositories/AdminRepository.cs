using System;
using BryanGabeDAL.Models;
using BryanGabeDAL.Utility;

namespace BryanGabeDAL.Repositories
{
	public class AdminRepository
	{
		private readonly ChaosSoftwareContext _context;
		public AdminRepository()
		{
			_context = new ChaosSoftwareContext();
		}

		public bool AddUser(User user)
		{
			bool result = false;
			User u = new()
			{
				FirstName = user.FirstName,
				LastName = user.LastName,
				DisplayName = user.DisplayName,
				Email = user.Email,
				HashPassword = BryanGabeUtils.HashPassword(user.HashPassword),
				Dob = user.Dob,
				LastLogin = user.LastLogin,
				DateCreated = user.DateCreated,
				RoleId = user.RoleId,
				Deleted = user.Deleted
			};
			try
			{
				_context.Users.Add(u);
				_context.SaveChanges();
			} catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return result;
		}
	}
}

