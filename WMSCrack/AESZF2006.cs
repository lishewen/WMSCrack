using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace WMSCrack
{
   public class AESZF2006
    {
		public AESZF2006()
		{
			mobjCryptoService = new RijndaelManaged();
		}

		public void AESKeySet(string sValue)
		{
			this.AESKey = sValue;
		}

		public void AESKeyIVSet(string sValue)
		{
			this.AESKeyIV = sValue;
		}

		private byte[] GetLegalKey()
		{
			string text = this.AESKey;
			this.mobjCryptoService.GenerateKey();
			byte[] key = this.mobjCryptoService.Key;
			int num = key.Length;
			if (text.Length > num)
			{
				text = text.Substring(0, num);
			}
			else if (text.Length < num)
			{
				text = text.PadRight(num, ' ');
			}
			return Encoding.ASCII.GetBytes(text);
		}

		private byte[] GetLegalIV()
		{
			string text = this.AESKeyIV;
			this.mobjCryptoService.GenerateIV();
			byte[] iv = this.mobjCryptoService.IV;
			int num = iv.Length;
			if (text.Length > num)
			{
				text = text.Substring(0, num);
			}
			else if (text.Length < num)
			{
				text = text.PadRight(num, ' ');
			}
			return Encoding.ASCII.GetBytes(text);
		}

		public string AESEncrypto(string Source)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(Source + AESZF2006.strAES);
			MemoryStream memoryStream = new MemoryStream();
			this.mobjCryptoService.Key = this.GetLegalKey();
			this.mobjCryptoService.IV = this.GetLegalIV();
			ICryptoTransform transform = this.mobjCryptoService.CreateEncryptor();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(bytes, 0, bytes.Length);
			cryptoStream.FlushFinalBlock();
			memoryStream.Close();
			byte[] inArray = memoryStream.ToArray();
			return Convert.ToBase64String(inArray);
		}

		public string AESDecrypto(string Source)
		{
			string result;
			try
			{
				if (Source != "0" && Source != "")
				{
					byte[] array = Convert.FromBase64String(Source);
					MemoryStream stream = new MemoryStream(array, 0, array.Length);
					this.mobjCryptoService.Key = this.GetLegalKey();
					this.mobjCryptoService.IV = this.GetLegalIV();
					ICryptoTransform transform = this.mobjCryptoService.CreateDecryptor();
					CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
					StreamReader streamReader = new StreamReader(stream2);
					result = streamReader.ReadToEnd().Replace(AESZF2006.strAES, "");
				}
				else
				{
					result = "";
				}
			}
			catch
			{
				result = "";
			}
			return result;
		}

		public static string strAES = "lkjlsadf#98234FD)(L:DFS#@T()GDFOKDfsf2r0=3589DFOI#";

		private readonly SymmetricAlgorithm mobjCryptoService;

		private string AESKey = "";

		private string AESKeyIV = "";
	}
}
