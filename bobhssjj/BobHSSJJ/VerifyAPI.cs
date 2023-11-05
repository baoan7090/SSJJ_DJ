using System;
using System.Runtime.InteropServices;

internal class VerifyAPI
{
	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern IntPtr GetCurrentProcess();

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern uint GetCurrentProcessId();

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern uint GetCurrentThreadId();

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern IntPtr OpenThread(uint uint_0, bool bool_0, uint uint_1);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern uint SuspendThread(IntPtr intptr_0);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool GetThreadContext(IntPtr intptr_0, ref Struct19 struct19_0);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool SetThreadContext(IntPtr intptr_0, ref Struct19 struct19_0);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern uint ResumeThread(IntPtr intptr_0);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool CloseHandle(IntPtr intptr_0);

	internal void method_0()
	{
		uint currentThreadId = GetCurrentThreadId();
		IntPtr intPtr = OpenThread((uint)2032639, false, currentThreadId);
		SuspendThread(intPtr);
		Struct19 struct2 = default(Struct19);
		struct2.uint_0 = (uint)4103;
		GetThreadContext(intPtr, ref struct2);
		struct2.uint_17 = unchecked((uint)-854417697);
		struct2.uint_22 = unchecked((uint)-1048592);
		struct2.uint_18 = unchecked((uint)-17825796);
		struct2.uint_19 = 6U;
		struct2.uint_20 = (uint)35;
		SetThreadContext(intPtr, ref struct2);
		ResumeThread(intPtr);
		CloseHandle(intPtr);
	}

	internal void method_1()
	{
		uint currentThreadId = GetCurrentThreadId();
		IntPtr intPtr = OpenThread((uint)2032639, false, currentThreadId);
		SuspendThread(intPtr);
		Struct19 struct2 = default(Struct19);
		struct2.uint_0 = (uint)4103;
		GetThreadContext(intPtr, ref struct2);
		struct2.uint_17 = unchecked((uint)-799891729);
		struct2.uint_22 = unchecked((uint)-4368);
		struct2.uint_18 = unchecked((uint)-286326788);
		struct2.uint_19 = 0U;
		struct2.uint_20 = (uint)35;
		SetThreadContext(intPtr, ref struct2);
		ResumeThread(intPtr);
		CloseHandle(intPtr);
	}

	internal void method_2()
	{
		uint currentThreadId = GetCurrentThreadId();
		IntPtr intPtr = OpenThread((uint)2032639, false, currentThreadId);
		SuspendThread(intPtr);
		Struct19 struct2 = default(Struct19);
		struct2.uint_0 = (uint)4103;
		GetThreadContext(intPtr, ref struct2);
		struct2.uint_17 = unchecked((uint)-1071714593);
		struct2.uint_22 = unchecked((uint)-65552);
		struct2.uint_18 = unchecked((uint)-1114116);
		struct2.uint_19 = (uint)16;
		struct2.uint_20 = (uint)35;
		SetThreadContext(intPtr, ref struct2);
		ResumeThread(intPtr);
		CloseHandle(intPtr);
	}

	internal void method_3()
	{
		uint currentThreadId = GetCurrentThreadId();
		IntPtr intPtr = OpenThread((uint)2032639, false, currentThreadId);
		SuspendThread(intPtr);
		Struct19 struct2 = default(Struct19);
		struct2.uint_0 = (uint)4103;
		GetThreadContext(intPtr, ref struct2);
		struct2.uint_17 = unchecked((uint)-1072521505);
		struct2.uint_22 = unchecked((uint)-16);
		struct2.uint_18 = unchecked((uint)-4);
		struct2.uint_19 = 4U;
		struct2.uint_20 = (uint)35;
		SetThreadContext(intPtr, ref struct2);
		ResumeThread(intPtr);
		CloseHandle(intPtr);
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct Struct18
	{
		private const int int_0 = 260;

		public uint uint_0;

		public uint uint_1;

		public uint uint_2;

		public uint uint_3;

		public int int_1;

		public int int_2;

		public uint uint_4;
	}

	public struct Struct19
	{
		public uint uint_0;

		public uint uint_1;

		public uint uint_2;

		public uint uint_3;

		public uint uint_4;

		public uint uint_5;

		public uint uint_6;

		public uint uint_7;

		public uint uint_8;

		public uint uint_9;

		public uint uint_10;

		public uint uint_11;

		public uint uint_12;

		public uint uint_13;

		public uint uint_14;

		public uint uint_15;

		public uint uint_16;

		public uint uint_17;

		public uint uint_18;

		public uint uint_19;

		public uint uint_20;

		public uint uint_21;

		public uint uint_22;

		public uint uint_23;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
		public byte[] byte_0;
	}

	public struct Struct20
	{
		public uint uint_0;

		public uint uint_1;

		public uint uint_2;

		public uint uint_3;

		public uint uint_4;

		public uint uint_5;

		public uint uint_6;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
		public byte[] byte_0;

		public uint uint_7;
	}
}
