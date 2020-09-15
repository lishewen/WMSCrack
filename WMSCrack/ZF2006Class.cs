using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace WMSCrack
{
   public class ZF2006Class
    {
		private readonly string[] pwPro = new string[18];
		private readonly string[] czPro = new string[18];
		public ZF2006Class()
		{
			this.pwPro[0] = "8:UI491Md2Ax2dZa6flS#$5";
			this.pwPro[1] = ">BJ5#*W45a45%6qfgd#vFas";
			this.pwPro[2] = "3%5*eKsLwe3#$@23aSDFGt4";
			this.pwPro[3] = "lsX3d)!T#$sd^RH0W^ws3gf";
			this.pwPro[4] = "O54#$GESrs*t8V$!B%9uiHa";
			this.pwPro[5] = "<>*93A2K;la@EWR#2s3&af@";
			this.pwPro[6] = "30M1a2u@#af23af$73SVdA%";
			this.pwPro[7] = "u0P45yER$8%G3hw98-2q3=D";
			this.pwPro[8] = "3M8h3AD&*(@F324M<%#aP5l";
			this.pwPro[9] = "}$!3408SF)(bx,.nxS24P@#";
			this.pwPro[10] = "sdJF+@lewGH42}POfsdg93";
			this.pwPro[11] = "*@KJhf23B2709-FSF2x(&2";
			this.pwPro[12] = "njs)(@#$fANdeLP<ZWRfda";
			this.pwPro[13] = "*)(@sd21@(*)20945HGAfa";
			this.pwPro[14] = "@#$)Jlf;a8724hjahgfAEF";
			this.pwPro[15] = "78t28F#%#$@%dsfasf35AF";
			this.pwPro[16] = "Xaf234bxjkADSF@#*!@5a9";
			this.czPro[0] = "8A923z;lZv30s*6fl;f*we";
			this.czPro[1] = "S3%8^&5GaVdfKi0934aewP";
			this.czPro[2] = "?%#$3498uCsdu&*SDFG3-e";
			this.czPro[3] = "sLd2sK*%$sg23*R^%526hs";
			this.czPro[4] = "8<F<#E$sGfa;df@#M@!1k3";
		}
		public string md5Target(string str, string sType)
		{
			return this.md5TargetH(str, sType);
		}
		private string md5TargetH(string str, string sType)
		{
			switch (sType)
			{
				case "pw":
					{
						string text = this.md5Base(str + this.pwPro[0]);
						return text + this.md5Base(this.pwPro[1] + text);
					}
				case "pw2":
					{
						string text = this.md5Base(str + this.pwPro[1]);
						return text + this.md5Base(this.pwPro[0] + text);
					}
				case "qx":
					return this.md5Base(str + this.pwPro[2] + DateTime.Now.ToString("ddMMyyyyddMMyydd"));
				case "page":
					return this.md5Base(str + this.pwPro[1] + this.pwPro[2]);
				case "cookie1":
					return this.md5Base(str + this.pwPro[3]);
				case "cookie2":
					return this.md5Base(str + this.pwPro[4]);
				case "rk":
					return this.md5Base(str + this.pwPro[5] + this.md5DT(sType));
				case "rkx2":
					return this.md5Base(str + this.pwPro[6]);
				case "gid":
					return this.md5Base(str + this.pwPro[2] + this.md5DT(sType));
				case "gid2":
					return this.md5Base(str + this.pwPro[3] + this.md5DT(sType));
				case "da":
					return this.md5Base(str + this.pwPro[3] + this.md5DT(sType));
				case "tz":
					return this.md5Base(str + this.pwPro[3] + this.pwPro[2] + this.md5DT(sType));
				case "pd":
					return this.md5Base(str + this.pwPro[3] + this.pwPro[4] + this.md5DT(sType));
				case "gt":
					return this.md5Base(str + this.pwPro[2] + this.pwPro[4] + this.md5DT(sType));
				case "czkn":
					return this.md5Base(str + this.pwPro[2] + this.pwPro[5]);
				case "czkp":
					return this.md5Base(str + this.pwPro[3] + this.pwPro[6]);
				case "czk":
					return this.md5Base(str + this.pwPro[5] + this.pwPro[6] + this.md5DT(sType)) + this.md5Base(str + this.pwPro[3] + this.pwPro[2] + this.md5DT(sType));
				case "czkey":
					return this.md5Base(str + this.pwPro[6] + this.pwPro[8] + this.md5DT(sType)) + this.md5Base(str + this.pwPro[5] + this.pwPro[7] + this.md5DT(sType));
				case "czsend0":
					return this.md5Base(str + this.czPro[0] + this.czPro[3] + this.md5DT(sType)) + this.md5Base(str + this.czPro[0] + this.czPro[1] + this.md5DT(sType));
				case "czsend1":
					return this.md5Base(str + this.czPro[1] + this.czPro[2] + this.md5DT(sType)) + this.md5Base(str + this.czPro[1] + this.czPro[2] + this.md5DT(sType));
				case "czsend2":
					return this.md5Base(str + this.czPro[2] + this.czPro[1] + this.md5DT(sType)) + this.md5Base(str + this.czPro[2] + this.czPro[3] + this.md5DT(sType));
				case "czsend3":
					return this.md5Base(str + this.czPro[3] + this.czPro[0] + this.md5DT(sType)) + this.md5Base(str + this.czPro[3] + this.czPro[0] + this.md5DT(sType));
				case "czye":
					return this.md5Base(str + this.czPro[4] + this.md5DT(sType)) + this.md5Base(str + this.md5DT(sType) + this.md5DT(sType));
				case "czclear":
					return this.md5Base(str + this.czPro[0] + this.czPro[3] + this.md5DT(sType)) + this.md5Base(str + this.md5DT(sType) + this.czPro[1] + this.czPro[2]);
				case "seed":
					return this.md5Base(str + this.pwPro[3]);
				case "key":
					return this.md5Base(str + this.pwPro[4]);
				case "keyiv":
					return this.md5Base(str + this.pwPro[5]);
				case "xchk":
					return this.md5Base(str + this.pwPro[6]);
				case "ck":
					return this.md5Base(str + this.pwPro[8]);
				case "center":
					return this.md5Base(str + this.pwPro[9]);
				case "goods":
					return this.md5Base(str + this.pwPro[10]);
				case "js":
					return this.md5Base(str + this.pwPro[11]);
				case "app":
					return this.md5Base(str + this.pwPro[12]);
				case "cg":
					return this.md5Base(str + this.pwPro[13]);
				case "jccanel":
					return this.md5Base(str + this.pwPro[14]);
				case "gogt":
					return this.md5Base(str + this.pwPro[15]);
				case "g2":
					return this.md5Base(str + this.pwPro[16]);
			}
			return this.md5Base(str);
		}
		private string md5Base(string str)
		{
			byte[] array = Encoding.Default.GetBytes(str);
			array = new MD5CryptoServiceProvider().ComputeHash(array);
			string text = "";
			for (int i = 0; i < array.Length; i++)
			{
				text += array[i].ToString("x").PadLeft(2, '0');
			}
			return text;
		}
		private string md5DT(string sType)
		{
			string result = "";
			switch (sType)
			{
				case "rk":
					result = DateTime.Now.ToString("MMMMddyyyy");
					break;
				case "da":
					result = DateTime.Now.ToString("yyMMddyyyy");
					break;
				case "gid":
					result = DateTime.Now.ToString("yyMMddyydd");
					break;
				case "tz":
					result = DateTime.Now.ToString("yyyyMMddyyddMMyydd");
					break;
				case "pd":
					result = DateTime.Now.ToString("ddMMyyddMMyy");
					break;
				case "gt":
					result = DateTime.Now.ToString("MMyyddddMMyy");
					break;
				case "czk":
					result = DateTime.Now.ToString("yyMMddMMMMyyddyyyy");
					break;
				case "czkey":
					result = DateTime.Now.ToString("MMddddddyyyyddMMyy");
					break;
				case "czsend0":
					result = DateTime.Now.ToString("MMMMddMMyyyyddMMyy");
					break;
				case "czsend1":
					result = DateTime.Now.ToString("MMMMMMddddMMyyddMM");
					break;
				case "czsend2":
					result = DateTime.Now.ToString("yyyyyyddMMMMddyydd");
					break;
				case "czsend3":
					result = DateTime.Now.ToString("MMddMMyyyyddyyMMyy");
					break;
				case "czye":
					result = DateTime.Now.ToString("ddyyMMyyMMddMMyyyy");
					break;
				case "czclear":
					result = DateTime.Now.ToString("ddyMMyyddMMMMyyddddMM");
					break;
			}
			return result;
		}
	}
}
