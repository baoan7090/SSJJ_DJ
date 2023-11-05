using System;
using System.Collections.Generic;
using Assets.Sources.Utils.Optimize;
using UnityEngine;

internal class Class28
{
	public static bool smethod_0(PlayerEntity playerEntity_0, PlayerEntity playerEntity_1)
	{
		return false;
	}

	public static void smethod_1(int int_0)
	{
		Class30 @class = new Class30();
		dictionary_0.Add(int_0, @class);
	}

	public static void smethod_2(int int_0, Vector3 vector3_0, float float_0, float float_1, int int_1, DateTime dateTime_0, int int_2, int int_3)
	{
		Class29 @class = new Class29();
		@class.float_1 = float_1;
		@class.float_0 = float_0;
		@class.vector3_0 = vector3_0;
		@class.int_0 = int_1;
		@class.dateTime_0 = dateTime_0;
		@class.int_1 = int_2;
		@class.int_2 = int_3;
		if (!dictionary_0.ContainsKey(int_0))
		{
			smethod_1(int_0);
			dictionary_0[int_0].method_0(@class);
		}
		else
		{
			dictionary_0[int_0].method_0(@class);
		}
	}

	public static Class29 smethod_3(int int_0)
	{
		Class29 @class;
		if (!dictionary_0.ContainsKey(int_0))
		{
			@class = null;
		}
		else
		{
			@class = dictionary_0[int_0].method_2();
		}
		return @class;
	}

	public static Dictionary<int, Class30> smethod_4()
	{
		return dictionary_0;
	}

	// Note: this type is marked as 'beforefieldinit'.
	static Class28()
	{
		dictionary_0 = new Dictionary<int, Class30>(16);
	}

	public static Dictionary<int, Class30> dictionary_0;

	public class Class29
	{
		public Vector3 vector3_0;

		public float float_0;

		public float float_1;

		public int int_0;

		public DateTime dateTime_0;

		public int int_1;

		public int int_2;
	}

	public class Class30
	{
		public void method_0(Class29 class29_0)
		{
			if (circularBuffer_0.Capacity == circularBuffer_0.Size)
			{
				circularBuffer_0.PopBack();
			}
			circularBuffer_0.PushFront(class29_0);
		}

		public Class29 method_1(int int_0)
		{
			Class29 @class;
			if (circularBuffer_0.IsEmpty)
			{
				@class = null;
			}
			else
			{
				@class = circularBuffer_0[int_0];
			}
			return @class;
		}

		public Class29 method_2()
		{
			Class29 @class;
			if (circularBuffer_0.IsEmpty)
			{
				@class = null;
			}
			else
			{
				@class = circularBuffer_0.Back();
			}
			return @class;
		}

		public CircularBuffer<Class29> circularBuffer_0 = new CircularBuffer<Class29>(3);
	}
}
