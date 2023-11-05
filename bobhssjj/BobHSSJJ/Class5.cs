 using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class Class5 : IDisposable
{
	public bool Boolean_0 { get; private set; }

	public bool Boolean_1 { get; private set; }

	public Class5(byte[] byte_0)
	{
		intptr_0 = IntPtr.Zero;
		intptr_1 = IntPtr.Zero;
		bool_2 = false;
		delegate0_0 = null;
		delegate1_0 = null;
		bool_3 = false;
		Boolean_0 = false;
		if (byte_0 == null)
		{
			throw new ArgumentNullException("data");
		}
		MemoryLoadLibrary(byte_0);
	}

	~Class5()
	{
		method_5();
	}

	public T method_0<T>(string string_0) where T : class
	{
		if (!typeof(Delegate).IsAssignableFrom(typeof(T)))
		{
			throw new ArgumentException(typeof(T).Name + " is not a delegate");
		}
		
		T t = Marshal.GetDelegateForFunctionPointer(method_2(string_0), typeof(T)) as T;
		if (t == null)
		{
			throw new Exception0();
		}
		T t2 = t;
		return t2;
	}

	public Delegate method_1(string string_0, Type type_0)
	{
		if (type_0 == null)
		{
			throw new ArgumentNullException("delegateType");
		}
		
		if (!typeof(Delegate).IsAssignableFrom(type_0))
		{
			throw new ArgumentException(type_0.Name + " is not a delegate");
		}
		
		Delegate delegateForFunctionPointer = Marshal.GetDelegateForFunctionPointer(method_2(string_0), type_0);
		if (delegateForFunctionPointer == null)
		{
			throw new Exception0("Unable to get managed delegate");
		}
		return delegateForFunctionPointer;
	}

	private IntPtr method_2(string string_0)
	{
        if (Boolean_0)
        {
            //"q"j{-z~>hw";#C?{>/2-Y>^Y/"
            throw new ObjectDisposedException("BRRRRRRRRRRRRuh");
		}
		if (string.IsNullOrEmpty(string_0))
		{
			throw new ArgumentException("funcName");
		}
		if (!Boolean_1)
		{
			throw new InvalidOperationException("Loaded Module is not a DLL");
		}
		if (!bool_2)
		{
			throw new InvalidOperationException("Dll is not initialized");
		}
		IntPtr intPtr = intptr_1;
		int num = 24;
		int num2;
		if (!Boolean_2)
		{
			num2 = 96;
		}
		else
		{
			num2 = 112;
		}
		IntPtr intPtr2 = smethod_11(intPtr, num + num2);
		Struct11 struct2 = smethod_9<Struct11>(intPtr2);
		if (struct2.uint_1 == 0U)
		{
			throw new Exception0("Dll has no export table");
		}
		
		IntPtr intPtr3 = smethod_12(intptr_0, struct2.uint_0);
		Struct15 struct3 = smethod_9<Struct15>(intPtr3);
		bool flag;
		if (struct3.uint_4 != 0U)
		{
			flag = struct3.uint_5 == 0U;
		}
		else
		{
			flag = true;
		}
		if (!flag)
		{
			IntPtr intPtr4 = smethod_12(intptr_0, struct3.uint_7);
			IntPtr intPtr5 = smethod_12(intptr_0, struct3.uint_8);
			int num4 = 0;
			ushort num6;
			for (;;)
			{
				
				if ((long)num4 >= (long)((ulong)struct3.uint_5))
				{
					goto IL_33F;
				}
				
				uint num5 = smethod_9<uint>(intPtr4);
				num6 = smethod_9<ushort>(intPtr5);
				string text = Marshal.PtrToStringAnsi(smethod_12(intptr_0, num5));
				if (text == string_0)
				{
					break;
				}
				num4++;
				intPtr4 = smethod_11(intPtr4, 4);
				intPtr5 = smethod_11(intPtr5, 2);
			}
			
			if ((uint)num6 > struct3.uint_4)
			{
				throw new Exception0("");
			}
			IntPtr intPtr6 = smethod_12(intptr_0, struct3.uint_6 + (uint)(num6 * 4));
			IntPtr intPtr7 = smethod_12(intptr_0, smethod_9<uint>(intPtr6));
			return intPtr7;
			IL_33F:
			throw new Exception0(string_0);
		}
		throw new Exception0("Dll exports no functions");
	}

	public int method_3()
	{
		if (Boolean_0)
		{
            //q"j{-z~>hw";#C?{>/2-Y>^Y/
            throw new ObjectDisposedException("BRRRRRRRRRRRRuh2");
		}
		bool flag;
		if (!Boolean_1 && delegate1_0 != null)
		{
			flag = !bool_3;
		}
		else
		{
			flag = true;
		}
		
		if (flag)
		{
			throw new Exception0("Unable to call entry point. Is loaded module a dll?");
		}
		int num = delegate1_0();
		return num;
	}

	private void MemoryLoadLibrary(byte[] data)
	{
		if (data.Length < Marshal.SizeOf(typeof(Struct7)))
		{
			throw new Exception0("Not a valid executable file");
		}
		Struct7 struct2 = smethod_20<Struct7>(data, 0);
		int ushort_ = (int)struct2.ushort_0;
		if (ushort_ != 23117)
		{
			throw new BadImageFormatException("Not a valid executable file");
		}
		if (data.Length < struct2.int_0 + Marshal.SizeOf(typeof(Struct8)))
		{
			throw new Exception0("Not a valid executable file");
		}
		Struct8 struct3 = smethod_20<Struct8>(data, struct2.int_0);
		if (struct3.uint_0 != (uint)17744)
		{
			throw new BadImageFormatException("Not a valid PE file");
		}
		if ((uint)struct3.struct9_0.ushort_0 != smethod_6())
		{
			throw new BadImageFormatException("Machine type doesn't fit (i386 vs. AMD64)");
		}
		if ((struct3.struct10_0.uint_5 & 1U) > 0U)
		{
			throw new BadImageFormatException("Wrong section alignment");
		}
		if (struct3.struct10_0.uint_3 == 0U)
		{
			throw new Exception0("Module has no entry point");
		}
		Struct16 struct4;
		Class10.GetNativeSystemInfo(out struct4);
		uint num2 = 0U;
		int num3 = Class10.smethod_1(struct2.int_0, struct3.struct9_0.ushort_2);
		int num4 = 0;
		for (;;)
		{
			if (num4 == (int)struct3.struct9_0.ushort_1)
			{
				break;
			}
			
			Struct12 struct5 = smethod_20<Struct12>(data, num3);
			uint uint_ = struct5.uint_1;
			uint num5;
			if (struct5.uint_2 <= 0U)
			{
				
				num5 = struct3.struct10_0.uint_5;
			}
			else
			{
				num5 = struct5.uint_2;
			}
			
			uint num6 = uint_ + num5;
			if (num6 > num2)
			{
				num2 = num6;
			}
			num4++;
			int num7 = num3;
			num3 = num7 + 40;
		}
		uint num9 = smethod_7(struct3.struct10_0.uint_8, struct4.uint_0);
		uint num10 = smethod_7(num2, struct4.uint_0);
		if (num9 != num10)
		{
			throw new BadImageFormatException("Wrong section alignment");
		}
		IntPtr intPtr;
		if (!Boolean_2)
		{
			ulong ulong_ = struct3.struct10_0.ulong_0;
			
			intPtr = (IntPtr)(ulong_ >> 32);
		}
		else
		{
			
			intPtr = (IntPtr)((long)struct3.struct10_0.ulong_0);
		}
		intptr_0 = Class10.VirtualAlloc(intPtr, (UIntPtr)struct3.struct10_0.uint_8, (Enum4)0, Enum5.const_6);
		if (intptr_0 == IntPtr.Zero)
		{
			intptr_0 = Class10.VirtualAlloc(IntPtr.Zero, (UIntPtr)struct3.struct10_0.uint_8, (Enum4)12288, Enum5.const_6);
		}
		if (intptr_0 == IntPtr.Zero)
		{
			throw new Exception0("Out of Memory");
		}
		
		bool flag;
		if (Boolean_2)
		{
			IntPtr intPtr2 = intptr_0;
			uint num12 = num9;
			flag = smethod_19(intPtr2, num12, 32);
		}
		else
		{
			flag = false;
		}
		
		if (flag)
		{
			
			List<IntPtr> list = new List<IntPtr>();
			for (;;)
			{
				IntPtr intPtr3 = intptr_0;
				uint num14 = num9;
				if (!smethod_19(intPtr3, num14, 32))
				{
					break;
				}
				list.Add(intptr_0);
				intptr_0 = Class10.VirtualAlloc(IntPtr.Zero, (UIntPtr)num9, (Enum4)12288, Enum5.const_6);
				if (intptr_0 == IntPtr.Zero)
				{
					goto IL_5FA;
				}
			}
			goto IL_608;
			IL_5FA:
			IL_608:
			List<IntPtr>.Enumerator enumerator = list.GetEnumerator();
			try
			{
				for (;;)
				{
					if (!enumerator.MoveNext())
					{
						break;
					}
					IntPtr intPtr4 = enumerator.Current;
					IntPtr intPtr5 = intPtr4;
					IntPtr zero = IntPtr.Zero;
					int num16 = -2069665606;
					Class10.VirtualFree(intPtr5, zero, (Enum4)32768);
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			if (intptr_0 == IntPtr.Zero)
			{
				throw new Exception0("Out of Memory");
			}
		}
		IntPtr intPtr6 = intptr_0;
		UIntPtr uintPtr = (UIntPtr)struct3.struct10_0.uint_9;
		IntPtr intPtr7 = Class10.VirtualAlloc(intPtr6, uintPtr, (Enum4)4096, Enum5.const_6);
		if (!(intPtr7 == IntPtr.Zero))
		{
			Marshal.Copy(data, 0, intPtr7, (int)struct3.struct10_0.uint_9);
			intptr_1 = smethod_11(intPtr7, struct2.int_0);
			IntPtr intPtr8 = smethod_15(intptr_0, intPtr);
			if (intPtr8 != IntPtr.Zero)
			{
				Marshal.OffsetOf(typeof(Struct8), "OptionalHeader");
				Marshal.OffsetOf(typeof(Struct10), "ImageBaseLong");
				IntPtr intPtr9 = intptr_1;
				int num18 = 24;
				int num20;
				if (!Boolean_2)
				{
					num20 = 28;
				}
				else
				{
					num20 = 24;
				}
				IntPtr intPtr10 = smethod_11(intPtr9, num18 + num20);
				smethod_10<IntPtr>(intPtr10, intptr_0);
			}
			
			smethod_0(ref struct3, intptr_0, intptr_1, data);
			bool flag2;
			if (!(intPtr8 != IntPtr.Zero))
			{
				flag2 = true;
			}
			else
			{
				flag2 = smethod_1(ref struct3, intptr_0, intPtr8);
			}
			bool_3 = flag2;
			intptr_2 = smethod_2(ref struct3, intptr_0);
			smethod_3(ref struct3, intptr_0, intptr_1, struct4.uint_0);
			smethod_5(ref struct3, intptr_0, intptr_1);
			int ushort_2 = (int)struct3.struct9_0.ushort_3;
			Boolean_1 = (ushort_2 & 0) != 0;
			if (struct3.struct10_0.uint_3 > 0U)
			{
				if (Boolean_1)
				{
					IntPtr intPtr11 = smethod_12(intptr_0, struct3.struct10_0.uint_3);
					delegate0_0 = (Delegate0)Marshal.GetDelegateForFunctionPointer(intPtr11, typeof(Delegate0));
					bool flag3;
					if (delegate0_0 != null)
					{
						flag3 = delegate0_0(intptr_0, Enum8.const_0, IntPtr.Zero);
					}
					else
					{
						flag3 = false;
					}
					bool_2 = flag3;
					if (!bool_2)
					{
						throw new Exception0("Can't attach DLL to process");
					}
				}
				else
				{
					IntPtr intPtr12 = smethod_12(intptr_0, struct3.struct10_0.uint_3);
					delegate1_0 = (Delegate1)Marshal.GetDelegateForFunctionPointer(intPtr12, typeof(Delegate1));
				}
			}
			return;
		}
		throw new Exception0("Out of Memory");
	}

	private static void smethod_0(ref Struct8 struct8_0, IntPtr intptr_3, IntPtr intptr_4, byte[] byte_0)
	{
		IntPtr intPtr = Class10.smethod_0(intptr_4, struct8_0.struct9_0.ushort_2);
		int num = 0;
		for (;;)
		{
			
			if (num >= (int)struct8_0.struct9_0.ushort_1)
			{
				goto IL_2C5;
			}
			
			Struct12 struct2 = smethod_9<Struct12>(intPtr);
			if (struct2.uint_2 != 0U)
			{
				IntPtr intPtr2 = Class10.VirtualAlloc(smethod_12(intptr_3, struct2.uint_1), (UIntPtr)struct2.uint_2, (Enum4)4096, Enum5.const_6);
				if (intPtr2 == IntPtr.Zero)
				{
					break;
				}
				intPtr2 = smethod_12(intptr_3, struct2.uint_1);
				checked
				{
					Marshal.Copy(byte_0, (int)struct2.uint_3, intPtr2, (int)struct2.uint_2);
				}
				smethod_10<uint>(smethod_11(intPtr, 8), (uint)(long)intPtr2);
			}
			else
			{
				uint uint_ = struct8_0.struct10_0.uint_5;
				if (uint_ > 0U)
				{
					IntPtr intPtr3 = Class10.VirtualAlloc(smethod_12(intptr_3, struct2.uint_1), (UIntPtr)uint_, (Enum4)4096, Enum5.const_6);
					if (intPtr3 == IntPtr.Zero)
					{
						goto IL_2A5;
					}
					intPtr3 = smethod_12(intptr_3, struct2.uint_1);
					smethod_10<uint>(smethod_11(intPtr, 8), (uint)(long)intPtr3);
					Class10.memset(intPtr3, 0, (UIntPtr)uint_);
				}
			}
			num++;
			IntPtr intPtr4 = intPtr;
			intPtr = smethod_11(intPtr4, 40);
		}
		throw new Exception0("Out of Memory");
        IL_2A5:
            throw new Exception0("Unable to allocate memory");
        IL_2C5:
            ;
	}

	private static bool smethod_1(ref Struct8 struct8_0, IntPtr intptr_3, IntPtr intptr_4)
	{
		bool flag;
		if (struct8_0.struct10_0.struct11_5.uint_1 == 0U)
		{
			flag = intptr_4 == IntPtr.Zero;
		}
		else
		{
			
			IntPtr intPtr = smethod_12(intptr_3, struct8_0.struct10_0.struct11_5.uint_0);
			for (;;)
			{
				
				Struct13 struct2 = smethod_9<Struct13>(intPtr);
				if (struct2.uint_0 == 0U)
				{
					break;
				}
				
				IntPtr intPtr2 = smethod_12(intptr_3, struct2.uint_0);
				IntPtr intPtr3 = smethod_11(intPtr, 8);
				uint num = (struct2.uint_1 - 8U) / 2U;
				uint num2 = 0U;
				for (;;)
				{
					if (num2 == num)
					{
						break;
					}
					ushort num3 = (ushort)Marshal.PtrToStructure(intPtr3, typeof(ushort));
					Enum3 @enum = (Enum3)(num3 >> 12);
					int num4 = (int)num3 & 4095;
					IntPtr intPtr4 = smethod_11(intPtr2, num4);
					Enum3 enum2 = @enum;
					Enum3 enum3 = enum2;
					if (enum3 == Enum3.const_0)
					{
					}
					else
					{
						
						if (enum3 != Enum3.const_3)
						{
							if (enum3 != (Enum3)10)
							{
							}
							else
							{
								long num5 = (long)Marshal.PtrToStructure(intPtr4, typeof(long));
								num5 += (long)intptr_4;
								Marshal.StructureToPtr(num5, intPtr4, false);
							}
						}
						else
						{
							int num6 = (int)Marshal.PtrToStructure(intPtr4, typeof(int));
							num6 += (int)intptr_4;
							Marshal.StructureToPtr(num6, intPtr4, false);
						}
					}
					num2 += 1U;
					intPtr3 = smethod_11(intPtr3, 2);
				}
				intPtr = smethod_12(intPtr, struct2.uint_1);
			}
			flag = true;
		}
		return flag;
	}

	private static IntPtr[] smethod_2(ref Struct8 struct8_0, IntPtr intptr_3)
	{
		List<IntPtr> list = new List<IntPtr>();
		uint num = struct8_0.struct10_0.struct11_1.uint_1 / (uint)20;
		IntPtr intPtr = smethod_12(intptr_3, struct8_0.struct10_0.struct11_1.uint_0);
		uint num2 = 0U;
		Struct14 struct2;
		for (;;)
		{
			if (num2 == num)
			{
				break;
			}
			
			struct2 = smethod_9<Struct14>(intPtr);
			if (struct2.uint_3 == 0U)
			{
				goto IL_48C;
			}
			IntPtr intPtr2 = Class10.LoadLibrary(smethod_12(intptr_3, struct2.uint_3));
			if (smethod_18(intPtr2))
			{
				goto IL_34B;
			}
			list.Add(intPtr2);
			IntPtr intPtr3;
			IntPtr intPtr4;
			if (struct2.uint_0 <= 0U)
			{
				intPtr3 = smethod_12(intptr_3, struct2.uint_4);
				intPtr4 = smethod_12(intptr_3, struct2.uint_4);
			}
			else
			{
				intPtr3 = smethod_12(intptr_3, struct2.uint_0);
				intPtr4 = smethod_12(intptr_3, struct2.uint_4);
			}
			
			int size = IntPtr.Size;
			for (;;)
			{
				IntPtr intPtr5 = smethod_9<IntPtr>(intPtr3);
				if (intPtr5 == IntPtr.Zero)
				{
					break;
				}
				IntPtr intPtr6;
				if (Class10.smethod_3(intPtr5))
				{
					intPtr6 = Class10.GetProcAddress(intPtr2, Class10.smethod_2(intPtr5));
				}
				else
				{
					intPtr6 = Class10.GetProcAddress(intPtr2, smethod_11(smethod_13(intptr_3, intPtr5), 2));
				}
				if (intPtr6 == IntPtr.Zero)
				{
					goto IL_32B;
				}
				smethod_10<IntPtr>(intPtr4, intPtr6);
				intPtr3 = smethod_11(intPtr3, size);
				intPtr4 = smethod_11(intPtr4, size);
			}
			num2 += 1U;
			IntPtr intPtr7 = intPtr;
			int num3 = 490370489;
			intPtr = smethod_11(intPtr7, 0);
		}
		goto IL_49C;
		IL_32B:
		throw new Exception0("Can't get adress for imported function");
		IL_34B:
		List<IntPtr>.Enumerator enumerator = list.GetEnumerator();
		try
		{
			for (;;)
			{
				if (!enumerator.MoveNext())
				{
					break;
				}
				IntPtr intPtr8 = enumerator.Current;
				Class10.FreeLibrary(intPtr8);
			}
		}
		finally
		{
			((IDisposable)enumerator).Dispose();
		}
		list.Clear();
		throw new Exception0("Can't load libary" + Marshal.PtrToStringAnsi(smethod_12(intptr_3, struct2.uint_3)));
    IL_48C:
        ;
		IL_49C:
		IntPtr[] array;
		if (list.Count <= 0)
		{
			array = null;
		}
		else
		{
			array = list.ToArray();
		}
		return array;
	}

	private static void smethod_3(ref Struct8 struct8_0, IntPtr intptr_3, IntPtr intptr_4, uint uint_0)
	{
		UIntPtr uintPtr;
		if (!Boolean_2)
		{
			uintPtr = UIntPtr.Zero;
		}
		else
		{
			ulong num = (ulong)intptr_3.ToInt64();
			int num2 = 1263001915;
			
			uintPtr = (UIntPtr)(num & unchecked((ulong)-4294967296));
		}
		UIntPtr uintPtr2 = uintPtr;
		IntPtr intPtr = Class10.smethod_0(intptr_4, struct8_0.struct9_0.ushort_2);
		Struct12 struct2 = smethod_9<Struct12>(intPtr);
		Struct6 struct3 = default(Struct6);
		struct3.intptr_0 = smethod_16(smethod_12((IntPtr)0, struct2.uint_0), uintPtr2);
		struct3.intptr_1 = smethod_17(struct3.intptr_0, (UIntPtr)uint_0);
		struct3.intptr_2 = smethod_8(ref struct2, ref struct8_0);
		struct3.uint_0 = struct2.uint_6;
		struct3.bool_0 = false;
		intPtr = smethod_11(intPtr, 40);
		int num3 = 1;
		for (;;)
		{
			if (num3 >= (int)struct8_0.struct9_0.ushort_1)
			{
				break;
			}
			struct2 = smethod_9<Struct12>(intPtr);
			IntPtr intPtr2 = smethod_16(smethod_12((IntPtr)0, struct2.uint_0), uintPtr2);
			IntPtr intPtr3 = smethod_17(intPtr2, (UIntPtr)uint_0);
			IntPtr intPtr4 = smethod_8(ref struct2, ref struct8_0);
			smethod_13(struct3.intptr_0, struct3.intptr_2).ToInt64();
			//(long)intPtr3;
			bool flag;
			if (!(struct3.intptr_1 == intPtr3))
			{
				flag = smethod_13(struct3.intptr_0, struct3.intptr_2).ToInt64() > (long)intPtr3;
			}
			else
			{
				flag = true;
			}
			if (!flag)
			{
				smethod_4(struct3, uint_0, struct8_0.struct10_0.uint_5);
				struct3.intptr_0 = intPtr2;
				struct3.intptr_1 = intPtr3;
				struct3.intptr_2 = intPtr4;
				struct3.uint_0 = struct2.uint_6;
			}
			else
			{
				bool flag2;
				if ((struct2.uint_6 & (uint)33554432) != 0U)
				{
					int uint_ = (int)struct3.uint_0;
					flag2 = (uint_ & 33554432) == 0;
				}
				else
				{
					flag2 = true;
				}
				if (flag2)
				{
					struct3.uint_0 = (struct3.uint_0 | struct2.uint_6) & (uint)4261412863;
				}
				else
				{
					struct3.uint_0 |= struct2.uint_6;
				}
				struct3.intptr_2 = smethod_15(smethod_13(intPtr2, intPtr4), struct3.intptr_0);
			}
			num3++;
			IntPtr intPtr5 = intPtr;
			intPtr = smethod_11(intPtr5, 40);
		}
		struct3.bool_0 = true;
		smethod_4(struct3, uint_0, struct8_0.struct10_0.uint_5);
	}

	private static void smethod_4(Struct6 struct6_0, uint uint_0, uint uint_1)
	{
		if (struct6_0.intptr_2 == IntPtr.Zero)
		{
		}
		else if ((struct6_0.uint_0 & (uint)33554432) <= 0U)
		{
			int num;
			if ((struct6_0.uint_0 & (uint)1073741824) == 0U)
			{
				num = 0;
			}
			else
			{
				num = 1;
			}
			int num2 = num;
			int num3;
			if ((struct6_0.uint_0 & unchecked((uint)-2147483648)) == 0U)
			{
				num3 = 0;
			}
			else
			{
				num3 = 1;
			}
			int num4 = num3;
			int num5;
			if ((struct6_0.uint_0 & (uint)536870912) == 0U)
			{
				num5 = 0;
			}
			else
			{
				num5 = 1;
			}
			int num6 = num5;
			uint num7 = (uint)enum6_0[num6, num2, num4];
			if ((struct6_0.uint_0 & (uint)67108864) > 0U)
			{
				num7 |= (uint)512;
			}
			uint num8;
			if (!Class10.VirtualProtect(struct6_0.intptr_0, struct6_0.intptr_2, num7, out num8))
			{
				throw new Exception0("Error protecting memory page");
			}
		}
		else
		{
			bool flag;
			if (struct6_0.intptr_0 == struct6_0.intptr_1)
			{
				if (!struct6_0.bool_0 && uint_1 != uint_0)
				{
					flag = struct6_0.intptr_2.ToInt64() % (long)((ulong)uint_0) == 0L;
				}
				else
				{
					flag = true;
				}
			}
			else
			{
				flag = false;
			}
			if (flag)
			{
				Class10.VirtualFree(struct6_0.intptr_0, struct6_0.intptr_2, (Enum4)0);
			}
		}
	}

	private static void smethod_5(ref Struct8 struct8_0, IntPtr intptr_3, IntPtr intptr_4)
	{
		if (struct8_0.struct10_0.struct11_9.uint_0 != 0U)
		{
			Struct17 @struct = smethod_9<Struct17>(smethod_12(intptr_3, struct8_0.struct10_0.struct11_9.uint_0));
			IntPtr intPtr = @struct.intptr_2;
			if (intPtr != IntPtr.Zero)
			{
				IntPtr intPtr2;
				while ((intPtr2 = smethod_9<IntPtr>(intPtr)) != IntPtr.Zero)
				{
					Delegate2 @delegate = (Delegate2)Marshal.GetDelegateForFunctionPointer(intPtr2, typeof(Delegate2));
					@delegate(intptr_3, Enum8.const_0, IntPtr.Zero);
					intPtr = smethod_11(intPtr, IntPtr.Size);
				}
			}
		}
	}

	public static bool Boolean_2
	{
		get
		{
			return IntPtr.Size == 8;
		}
	}

	private static uint smethod_6()
	{
		if (IntPtr.Size != 8)
		{
			goto IL_41;
		}
		uint num2 = (uint)34404;
		goto IL_A0;
		int num4;
    IL_5D:
        for (;;)
		{
			
			int num3 = num4;
			switch (~(~((num3 ^ -331407991) - -1920657905)) % 4)
			{
			case 0:
				num4 = 523950681;
				continue;
			case 2:
				goto IL_41;
			case 3:
				goto IL_86;
			}
			break;
		}
		uint num5;
		return 332;
		IL_86:
		num2 = (uint)332;
		goto IL_A0;
		IL_41:
		num4 = 1503399067;
		goto IL_5D;
		IL_A0:
		num5 = num2;
		num4 = 69160762;
		goto IL_5D;
	}

	private static uint smethod_7(uint uint_0, uint uint_1)
	{
		return (uint_0 + uint_1 - 1U) & ~(uint_1 - 1U);
	}

	private static IntPtr smethod_8(ref Struct12 struct12_0, ref Struct8 struct8_0)
	{
		uint num = struct12_0.uint_2;
		if (num == 0U)
		{
			if ((struct12_0.uint_6 & (uint)64) > 0U)
			{
				num = struct8_0.struct10_0.uint_1;
			}
			else
			{
				int uint_ = (int)struct12_0.uint_6;
				if ((uint_ & 128) != 0)
				{
					num = struct8_0.struct10_0.uint_2;
				}
			}
		}
		IntPtr intPtr;
		if (IntPtr.Size != 8)
		{
			intPtr = (IntPtr)((int)num);
		}
		else
		{
			intPtr = (IntPtr)((long)((ulong)num));
		}
		IntPtr intPtr2 = intPtr;
		return intPtr2;
	}

	public void method_4()
	{
		((IDisposable)this).Dispose();
	}

	void IDisposable.Dispose()
	{
		method_5();
		GC.SuppressFinalize(this);
	}

	public void method_5()
	{
		if (bool_2)
		{
            delegate0_0?.Invoke(intptr_0, Enum8.const_3, IntPtr.Zero);
            bool_2 = false;
		}
		if (intptr_2 != null)
		{
			IntPtr[] array = intptr_2;
			int num = 0;
			for (;;)
			{
				if (num >= array.Length)
				{
					break;
				}
				IntPtr intPtr = array[num];
				if (!smethod_18(intPtr))
				{
					Class10.FreeLibrary(intPtr);
				}
				num++;
			}
			intptr_2 = null;
		}
		if (intptr_0 != IntPtr.Zero)
		{
			Class10.VirtualFree(intptr_0, IntPtr.Zero, (Enum4)32768);
			intptr_0 = IntPtr.Zero;
			intptr_1 = IntPtr.Zero;
		}
		Boolean_0 = true;
	}

	private static T smethod_9<T>(IntPtr intptr_3)
	{
		return (T)((object)Marshal.PtrToStructure(intptr_3, typeof(T)));
	}

	private static void smethod_10<T>(IntPtr intptr_3, T gparam_0)
	{
		Marshal.StructureToPtr(gparam_0, intptr_3, false);
	}

	private static IntPtr smethod_11(IntPtr intptr_3, int int_0)
	{
		return (IntPtr)(intptr_3.ToInt64() + (long)int_0);
	}

	private static IntPtr smethod_12(IntPtr intptr_3, uint uint_0)
	{
		return (IntPtr.Size == 8) ? ((IntPtr)(intptr_3.ToInt64() + (long)((ulong)uint_0))) : ((IntPtr)(intptr_3.ToInt32() + (int)uint_0));
	}

	private static IntPtr smethod_13(IntPtr intptr_3, IntPtr intptr_4)
	{
		return (IntPtr.Size == 8) ? ((IntPtr)(intptr_3.ToInt64() + intptr_4.ToInt64())) : ((IntPtr)(intptr_3.ToInt32() + intptr_4.ToInt32()));
	}

	private static IntPtr smethod_14(IntPtr intptr_3, UIntPtr uintptr_0)
	{
		return (IntPtr.Size == 8) ? ((IntPtr)(intptr_3.ToInt64() + (long)uintptr_0.ToUInt64())) : ((IntPtr)(intptr_3.ToInt32() + (int)uintptr_0.ToUInt32()));
	}

	private static IntPtr smethod_15(IntPtr intptr_3, IntPtr intptr_4)
	{
		return (IntPtr.Size == 8) ? ((IntPtr)(intptr_3.ToInt64() - intptr_4.ToInt64())) : ((IntPtr)(intptr_3.ToInt32() - intptr_4.ToInt32()));
	}

	private static IntPtr smethod_16(IntPtr intptr_3, UIntPtr uintptr_0)
	{
		return (IntPtr.Size == 8) ? ((IntPtr)(intptr_3.ToInt64() | (long)uintptr_0.ToUInt64())) : ((IntPtr)(intptr_3.ToInt32() | (int)uintptr_0.ToUInt32()));
	}

	private static IntPtr smethod_17(IntPtr intptr_3, UIntPtr uintptr_0)
	{
		return (IntPtr)(intptr_3.ToInt64() & (long)(~(long)(uintptr_0.ToUInt64() - 1UL)));
	}

	private static bool smethod_18(IntPtr intptr_3)
	{
		return intptr_3 == IntPtr.Zero || intptr_3 == ((IntPtr.Size == 8) ? ((IntPtr)(-1L)) : ((IntPtr)(-1)));
	}

	private static bool smethod_19(IntPtr intptr_3, uint uint_0, int int_0)
	{
		bool flag = (ulong)intptr_3.ToInt64() >> (int_0 & 63) < (ulong)(intptr_3.ToInt64() + (long)((ulong)uint_0)) >> (int_0 & 63);
		return flag;
	}

	private static T smethod_20<T>(byte[] byte_0, int int_0)
	{
		int num = Marshal.SizeOf(typeof(T));
		IntPtr intPtr = Marshal.AllocHGlobal(num);
		Marshal.Copy(byte_0, int_0, intPtr, num);
		T t = (T)((object)Marshal.PtrToStructure(intPtr, typeof(T)));
		Marshal.FreeHGlobal(intPtr);
		return t;
	}

	// Note: this type is marked as 'beforefieldinit'.
	static Class5()
	{
		Enum6[,,] array = new Enum6[2, 2, 2];
		array[0, 0, 0] = Enum6.const_0;
		array[0, 0, 1] = Enum6.const_3;
		array[0, 1, 0] = Enum6.const_1;
		array[0, 1, 1] = Enum6.const_2;
		array[1, 0, 0] = (Enum6)16;
		array[1, 0, 1] = (Enum6)128;
		array[1, 1, 0] = (Enum6)32;
		array[1, 1, 1] = (Enum6)64;
		enum6_0 = array;
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool bool_0;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool bool_1;

	private IntPtr intptr_0;

	private IntPtr intptr_1;

	private IntPtr[] intptr_2;

	private bool bool_2;

	private Delegate0 delegate0_0;

	private Delegate1 delegate1_0;

	private bool bool_3;

	private static readonly Enum6[,,] enum6_0;

	public class Exception0 : Exception
	{
		public Exception0()
		{
		}

		public Exception0(string string_0)
			: base(string_0)
		{
		}

		public Exception0(string string_0, Exception exception_0)
			: base(string_0, exception_0)
		{
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	private delegate bool Delegate0(IntPtr hinstDLL, Enum8 fdwReason, IntPtr lpReserved);

	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	private delegate int Delegate1();

	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	private delegate void Delegate2(IntPtr dllHandle, Enum8 reason, IntPtr reserved);

	private struct Struct6
	{
		internal IntPtr intptr_0;

		internal IntPtr intptr_1;

		internal IntPtr intptr_2;

		internal uint uint_0;

		internal bool bool_0;
	}

	private class Class6
	{
		internal const int int_0 = 24;

		internal const int int_1 = 8;

		internal const int int_2 = 2;
	}

	private class Class7
	{
		internal const int int_0 = 28;

		internal const int int_1 = 96;
	}

	private class Class8
	{
		internal const int int_0 = 24;

		internal const int int_1 = 112;
	}

	private class Class9
	{
		internal const int int_0 = 40;

		internal const int int_1 = 8;

		internal const int int_2 = 20;
	}

	private struct Struct7
	{
		public ushort ushort_0;

		public ushort ushort_1;

		public ushort ushort_2;

		public ushort ushort_3;

		public ushort ushort_4;

		public ushort ushort_5;

		public ushort ushort_6;

		public ushort ushort_7;

		public ushort ushort_8;

		public ushort ushort_9;

		public ushort ushort_10;

		public ushort ushort_11;

		public ushort ushort_12;

		public ushort ushort_13;

		public ushort ushort_14;

		public ushort ushort_15;

		public ushort ushort_16;

		public ushort ushort_17;

		public ushort ushort_18;

		public ushort ushort_19;

		public ushort ushort_20;

		public ushort ushort_21;

		public ushort ushort_22;

		public ushort ushort_23;

		public ushort ushort_24;

		public ushort ushort_25;

		public ushort ushort_26;

		public ushort ushort_27;

		public ushort ushort_28;

		public ushort ushort_29;

		public int int_0;
	}

	private struct Struct8
	{
		public uint uint_0;

		public Struct9 struct9_0;

		public Struct10 struct10_0;
	}

	private struct Struct9
	{
		public ushort ushort_0;

		public ushort ushort_1;

		public uint uint_0;

		public uint uint_1;

		public uint uint_2;

		public ushort ushort_2;

		public ushort ushort_3;
	}

	private struct Struct10
	{
		public Enum0 enum0_0;

		public byte byte_0;

		public byte byte_1;

		public uint uint_0;

		public uint uint_1;

		public uint uint_2;

		public uint uint_3;

		public uint uint_4;

		public ulong ulong_0;

		public uint uint_5;

		public uint uint_6;

		public ushort ushort_0;

		public ushort ushort_1;

		public ushort ushort_2;

		public ushort ushort_3;

		public ushort ushort_4;

		public ushort ushort_5;

		public uint uint_7;

		public uint uint_8;

		public uint uint_9;

		public uint uint_10;

		public Enum1 enum1_0;

		public Enum2 enum2_0;

		public IntPtr intptr_0;

		public IntPtr intptr_1;

		public IntPtr intptr_2;

		public IntPtr intptr_3;

		public uint LoaderFlags;

		public uint uint_11;

		public Struct11 struct11_0;

		public Struct11 struct11_1;

		public Struct11 struct11_2;

		public Struct11 struct11_3;

		public Struct11 struct11_4;

		public Struct11 struct11_5;

		public Struct11 struct11_6;

		public Struct11 struct11_7;

		public Struct11 struct11_8;

		public Struct11 struct11_9;

		public Struct11 LoadConfigTable;

		public Struct11 struct11_10;

		public Struct11 struct11_11;

		public Struct11 struct11_12;

		public Struct11 struct11_13;

		public Struct11 struct11_14;
	}

	private struct Struct11
	{
		public uint uint_0;

		public uint uint_1;
	}

	private struct Struct12
	{
		public ulong ulong_0;

		public uint uint_0;

		public uint uint_1;

		public uint uint_2;

		public uint uint_3;

		public uint uint_4;

		public uint uint_5;

		public ushort ushort_0;

		public ushort ushort_1;

		public uint uint_6;
	}

	private struct Struct13
	{
		public uint uint_0;

		public uint uint_1;
	}

	private struct Struct14
	{
		public uint uint_0;

		public uint uint_1;

		public uint uint_2;

		public uint uint_3;

		public uint uint_4;
	}

	private struct Struct15
	{
		public uint uint_0;

		public uint uint_1;

		public ushort ushort_0;

		public ushort ushort_1;

		public uint uint_2;

		public uint uint_3;

		public uint uint_4;

		public uint uint_5;

		public uint uint_6;

		public uint uint_7;

		public uint uint_8;
	}

	private struct Struct16
	{
		public ushort ushort_0;

		public ushort ushort_1;

		public uint uint_0;

		public IntPtr intptr_0;

		public IntPtr intptr_1;

		public IntPtr intptr_2;

		public uint uint_1;

		public uint uint_2;

		public uint uint_3;

		public ushort ushort_2;

		public ushort ushort_3;
	}

	private struct Struct17
	{
		public IntPtr StartAddressOfRawData;

		public IntPtr intptr_0;

		public IntPtr intptr_1;

		public IntPtr intptr_2;

		public IntPtr intptr_3;

		public uint uint_0;
	}

	private enum Enum0 : ushort
	{
		const_0 = 267,
		const_1 = 523
	}

	private enum Enum1 : ushort
	{
		const_0,
		const_1,
		const_2,
		const_3,
		const_4 = 7,
		const_5 = 9,
		const_6,
		const_7,
		const_8,
		const_9,
		const_10
	}

	private enum Enum2 : ushort
	{
		const_0 = 1,
		const_1,
		const_2 = 4,
		const_3 = 8,
		const_4 = 64,
		const_5 = 128,
		const_6 = 256,
		const_7 = 512,
		const_8 = 1024,
		const_9 = 2048,
		const_10 = 4096,
		const_11 = 8192,
		const_12 = 32768
	}

	private enum Enum3
	{
		const_0,
		const_1,
		const_2,
		const_3,
		const_4,
		const_5,
		const_6 = 9,
		const_7 = 9,
		const_8
	}

	private enum Enum4 : uint
	{
		const_0 = 4096U,
		const_1 = 8192U,
		const_2 = 524288U,
		const_3 = 536870912U,
		const_4 = 4194304U,
		const_5 = 1048576U,
		const_6 = 2097152U,
		const_7 = 16384U,
		const_8 = 32768U
	}

	private enum Enum5 : uint
	{
		const_0 = 16U,
		const_1 = 32U,
		const_2 = 64U,
		const_3 = 128U,
		const_4 = 1U,
		const_5,
		const_6 = 4U,
		const_7 = 8U,
		const_8 = 256U,
		const_9 = 512U,
		const_10 = 1024U
	}

	private enum Enum6
	{
		const_0 = 1,
		const_1,
		const_2 = 4,
		const_3 = 8,
		const_4 = 16,
		const_5 = 32,
		const_6 = 64,
		const_7 = 128,
		const_8 = 256,
		const_9 = 512,
		const_10 = 1024
	}

	private enum Enum7 : uint
	{
		const_0 = 16777216U,
		const_1 = 33554432U,
		const_2 = 67108864U,
		const_3 = 134217728U,
		const_4 = 268435456U,
		const_5 = 536870912U,
		const_6 = 1073741824U,
		const_7 = 2147483648U
	}

	private enum Enum8 : uint
	{
		const_0 = 1U,
		const_1,
		const_2,
		const_3 = 0U
	}

	private class Class10
	{
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr VirtualAlloc(IntPtr intptr_0, UIntPtr uintptr_0, Enum4 enum4_0, Enum5 enum5_0);

		[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr memset(IntPtr intptr_0, int int_0, UIntPtr uintptr_0);

		[DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern IntPtr LoadLibrary(IntPtr lpFileName);

		[DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr GetProcAddress(IntPtr intptr_0, IntPtr intptr_1);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool VirtualFree(IntPtr intptr_0, IntPtr intptr_1, Enum4 enum4_0);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool VirtualProtect(IntPtr intptr_0, IntPtr intptr_1, uint uint_9, out uint uint_10);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool FreeLibrary(IntPtr intptr_0);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern void GetNativeSystemInfo(out Struct16 struct16_0);

		public static IntPtr smethod_0(IntPtr intptr_0, ushort ushort_1)
		{
			IntPtr intPtr = smethod_11(intptr_0, 24 + (int)ushort_1);
			return intPtr;
		}

		public static int smethod_1(int int_0, ushort ushort_1)
		{
			int num = int_0 + 24 + (int)ushort_1;
			return num;
		}

		public static IntPtr smethod_2(IntPtr intptr_0)
		{
			IntPtr intPtr = (IntPtr)((int)(intptr_0.ToInt64() & (long)65535));
			return intPtr;
		}

		public static bool smethod_3(IntPtr intptr_0)
		{
			return (IntPtr.Size == 8) ? (intptr_0.ToInt64() < 0L) : (intptr_0.ToInt32() < 0);
		}

		public const ushort ushort_0 = 23117;

		public const uint uint_0 = 17744U;

		public const uint uint_1 = 332U;

		public const uint uint_2 = 34404U;

		public const uint uint_3 = 512U;

		public const uint uint_4 = 64U;

		public const uint uint_5 = 128U;

		public const uint uint_6 = 33554432U;

		public const uint uint_7 = 67108864U;

		public const uint uint_8 = 8192U;
	}
}
