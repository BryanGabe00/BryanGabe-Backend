using System;
using BryanGabeDAL.Models;

namespace BryanGabeDAL.Repositories
{
	public class AdminRepository
	{
		private readonly ChaosSoftwareContext _context;
		public AdminRepository()
		{
			_context = new ChaosSoftwareContext();
		}
	}
}

