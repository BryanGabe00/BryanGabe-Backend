using System;
using System.Security.Cryptography;
using System.Text;

namespace BryanGabeDAL.Utility
{
	public static class BryanGabeUtils
	{
		public static string HashPassword(string password)
		{
			SHA512 sha512 = SHA512.Create();
			byte[] data = Encoding.UTF8.GetBytes(password);
			byte[] hash = sha512.ComputeHash(data);
			return GetStringFromHash(hash);
		}

		public static string GetStringFromHash(byte[] hash)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for(int i = 0; i < hash.Length; i++)
			{
				stringBuilder.Append(hash[i].ToString("X2"));
			}
			return stringBuilder.ToString();
		}
	}
}

