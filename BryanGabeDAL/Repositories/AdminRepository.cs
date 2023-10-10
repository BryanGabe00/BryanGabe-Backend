using System;
using System.Data;
using System.Linq;
using BryanGabeDAL.Models;
using BryanGabeDAL.Utility;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BryanGabeDAL.Repositories
{
	public class AdminRepository
	{
		private readonly ChaosSoftwareContext _context;
		public AdminRepository()
		{
			_context = new ChaosSoftwareContext();
		}

		/**
		 * 
		 * Gets all the Users - Deleted ones
		 * 
		 */
		public List<User> GetActiveUsers()
		{
			List<User> users = new List<User>();
			try
			{
				users = (from u in _context.Users
						 where u.Deleted == false
						 select u).ToList();
			} catch
			{
				users = null;
			}
			return users;
		}

		public List<User> GetAllUsers() 
		{
			List<User> users = new List<User>();
			try
			{
				users = (from u in _context.Users
				select u).ToList();
			} catch
			{
				users = null;
			}
			return users;
		}

		/**
		 * 
		 * Add a User to the database using the User model
		 * 
		 */
		public bool AddUser(RegisterUser user)
		{
			bool result = false;
			SqlParameter prmFirstName = new SqlParameter("@FirstName", user.FirstName);
			SqlParameter prmLastName = new SqlParameter("@LastName", user.LastName);
			SqlParameter prmDisplayName = new SqlParameter("@DisplayName", user.DisplayName.ToLower());
			SqlParameter prmPassword = new SqlParameter("@Password", user.Password);
			SqlParameter prmEmail = new SqlParameter("@Email", user.Email);
			SqlParameter prmDOB = new SqlParameter("@DOB", user.Dob);
			SqlParameter prmRoleId = new SqlParameter("@RoleId", user.RoleId);

			try 
			{
				int returnVal = _context.Database.ExecuteSqlRaw("exec dbo.usp_CreateUser @FirstName, @LastName, @DisplayName, @Password, @Email, @DOB, @RoleId",
				prmFirstName, prmLastName, prmDisplayName, prmPassword, prmEmail, prmDOB, prmRoleId);
				
				if(returnVal == 1)
					result = true;
				else
					result = false;
			} catch 
			{
				result = false;
			}
			return result;
		}

		/**
		 * 
		 * Soft Deletes Users by setting the Deleted column as 1
		 * 
		 */
		public bool DeleteUser(int id)
		{
			User? userObj = _context.Users.Find(id);

			if(userObj != null)
			{
				userObj.Deleted = true;
				_context.Users.Update(userObj);
				_context.SaveChanges();
				return true;
			}
			return false;
		}
	}
}

