using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

internal static class Verify
{
	internal static bool VersionCheck()
	{
		bool flag;
		try
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://29c4a1-cdn.lomerry.cloud/k");
			httpWebRequest.Method = "GET";
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			string text = new StreamReader(httpWebResponse.GetResponseStream()).ReadToEnd();
			if (!(text != "MkY5MTQwREFBNzk5OUEwRg==")) //2F9140DAA7999A0F
            {
				flag = true;
				goto IL_174;
			}
			Environment.Exit(0);
			Process.GetCurrentProcess().Kill();
			class13_0.method_2();
			flag = false;
			goto IL_174;
		}
		catch (Exception ex)
		{
			long_4 += 1L;
		}
		flag = false;
		IL_174:
		return flag;
	}

	static long smethod_1()
	{
		long num = DateTime.Now.Ticks / (long)10000000;
		return num;
	}

	internal static void smethod_2()
	{
		namedPipeClientStream_0.Close();
	}

	internal static void ConnectLocalServer()
	{
		namedPipeClientStream_0 = new NamedPipeClientStream("A9CC91EDA92B");
		try
		{
			NamedPipeClientStream namedPipeClientStream = namedPipeClientStream_0;
			namedPipeClientStream.Connect(6204);
		}
		catch (Exception obj)
		{
			Process.GetCurrentProcess().Kill();
			class13_0.method_3();
		}
	}

	internal static void smethod_4()
	{
		Main.instance.method_2();
		Main.instance.method_2();
		long_3 += 1L;
		Main.instance.method_2();
		Main.instance.method_2();
	}

	internal static void smethod_5()
	{
		if (long_2 != 0L && smethod_1() > long_2)
		{
			Process.GetCurrentProcess().Kill();
			Environment.Exit(0);
			class13_0.method_0();
			smethod_4();
		}
		if (long_4 > 4L)
		{
			smethod_5();
			bool_0 = false;
			Environment.Exit(0);
			Process.GetCurrentProcess().Kill();
			class13_0.method_3();
			smethod_4();
		}
	}

	internal static void smethod_6()
	{
		if (!bool_0)
		{
			bool_0 = true;
			ThreadPool.QueueUserWorkItem(new WaitCallback(smethod_7), null);
			long_1 = smethod_1() + (long)28;
		}
		long num = smethod_1();
		if (num > long_1)
		{
			Environment.Exit(0);
			Process.GetCurrentProcess().Kill();
			class13_0.method_1();
		}
		if (long_5 > 2L)
		{
			smethod_5();
			bool_0 = false;
			Environment.Exit(0);
			Process.GetCurrentProcess().Kill();
			class13_0.method_3();
		}
	}

	static void smethod_7(object object_0)
	{
		if (namedPipeClientStream_0.CanRead && namedPipeClientStream_0.IsConnected)
		{
			if (namedPipeClientStream_0.InBufferSize != 0)
			{
				smethod_9(namedPipeClientStream_0, new Action(Class15.__9.method_0), new Action(Class15.__9.method_1));
			}
		}
		else
		{
			Environment.Exit(0);
			Process.GetCurrentProcess().Kill();
			class13_0.method_3();
		}
	}

	static void smethod_9(NamedPipeClientStream namedPipeClientStream_1, Action action_0, Action action_1)
	{
		Class16 @class = new Class16();
		@class.namedPipeClientStream_0 = namedPipeClientStream_1;
		@class.action_0 = action_1;
		@class.action_1 = action_0;
		@class.byte_0 = new byte[1024];
		@class.namedPipeClientStream_0.BeginRead(@class.byte_0, 0, @class.byte_0.Length, new AsyncCallback(@class.method_0), null);
	}

	static bool smethod_10(byte[] byte_1)
	{
		byte[] array = new byte[4];
		Array.Copy(byte_1, byte_1.Length - 4, array, 0, 4);
		byte[] array2 = new byte[byte_1.Length - 4];
		int num = 0;
		for (;;)
		{
			if (num >= byte_1.Length - 4)
			{
				break;
			}
			byte[] array3 = array2;
			int num2 = num;
			int num3 = (int)byte_1[num];
			int num4 = (int)array[num % array.Length];
			array3[num2] = (byte)(num3 ^ (num4 & 255));
			num++;
		}
		byte[] array4 = smethod_11();
		bool flag = smethod_12(array4, array2);
		return flag;
	}

	static byte[] smethod_11()
	{
		string machineName = Environment.MachineName;
		DateTime now = DateTime.Now;
		string text = now.ToString("yyyy-MM-dd");
		string text2 = machineName + text;
		byte[] array = new byte[] { 127, 1, 74, 43, 76, 141, 15, 51 };
		byte[] array2 = new byte[text2.Length];
		int num2 = 0;
		for (;;)
		{
			if (num2 >= text2.Length)
			{
				break;
			}
			array2[num2] = (byte)(text2[num2] ^ (char)array[num2 % array.Length]);
			num2++;
		}
		byte[] array3 = array2;
		return array3;
	}

	static bool smethod_12(byte[] byte_1, byte[] byte_2)
	{
		bool flag;
		if (byte_1.Length == byte_2.Length)
		{
			for (int i = 0; i < byte_1.Length; i++)
			{
				if (byte_1[i] != byte_2[i])
				{
					return false;
				}
			}
			flag = true;
		}
		else
		{
			flag = false;
		}
		return flag;
	}

	// Note: this type is marked as 'beforefieldinit'.
	static Verify()
	{
		class13_0 = new VerifyAPI();
		bool_0 = false;
		string_0 = "A9CC91EDA92B";
		byte_0 = new byte[] { 127, 1, 74, 43, 76, 141, 15, 51 };
		long_1 = 0L;
		long_2 = 0L;
		long_3 = 0L;
		long_4 = 0L;
		long_5 = 0L;
	}

	static VerifyAPI class13_0;

	static bool bool_0;

	static string string_0;

	static readonly byte[] byte_0;

	static NamedPipeClientStream namedPipeClientStream_0;

	const int int_0 = 1024;

	const int int_1 = 4;

	const long long_0 = 10L;

	static long long_1;

	static long long_2;

	static long long_3;

	static long long_4;

	static long long_5;

	[CompilerGenerated]
	[Serializable]
	sealed class Class15
	{
		internal void method_0()
		{
			long_2 = smethod_1() + (long)24;
			bool_0 = false;
		}

		internal void method_1()
		{
			long_3 += 1L;
			if (long_3 > 4L)
			{
				long_5 = (long)10;
				smethod_5();
				bool_0 = false;
				int num = 435027333;
				long_4 = (long)255;
				Environment.Exit(0);
				Process.GetCurrentProcess().Kill();
				class13_0.method_3();
				Main.instance.method_2();
			}
			long_4 += 1L;
			long_5 += 1L;
			bool_0 = false;
		}

		public static readonly Class15 __9 = new Class15();

		public static Action __9__20_0;

		public static Action __9__20_1;
	}

	[CompilerGenerated]
	sealed class Class16
	{
		internal void method_0(IAsyncResult iasyncResult_0)
		{
			int num = namedPipeClientStream_0.EndRead(iasyncResult_0);
			string text = Encoding.ASCII.GetString(byte_0, 0, num).TrimEnd(new char[1]);
			if (text.Length <= 0)
			{
				action_0();
			}
			else
			{
				string text2 = text;
				char[] array = new char[1];
				int num2 = 0;
				array[num2] = (char)124;
				string[] array2 = text2.Split(array);
				byte[] array3 = Convert.FromBase64String(array2[array2.Length - 2]);
				int num4 = array3.Length - 1;
				for (;;)
				{
					if (num4 < 0)
					{
						goto IL_141;
					}
					if (array3[num4] > 0)
					{
						break;
					}
					num4--;
				}
				IL_141:
				byte[] array4 = new byte[num4 + 1];
				Array.Copy(array3, array4, num4 + 1);
				if (!smethod_10(array4))
				{
					action_0();
				}
				else
				{
					long_2 = smethod_1();
					action_1();
				}
			}
		}

		public NamedPipeClientStream namedPipeClientStream_0;

		public byte[] byte_0;

		public Action action_0;

		public Action action_1;
	}
}
