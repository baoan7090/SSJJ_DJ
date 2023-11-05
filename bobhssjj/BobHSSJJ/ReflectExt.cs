using System;
using System.Reflection;

internal static class ReflectExt
{
	public static T smethod_0<T>(Type type_0, string string_0)
	{
		BindingFlags bindingFlags = (BindingFlags)60;
		FieldInfo field = type_0.GetField(string_0, bindingFlags);
		T t = (T)((object)field.GetValue(null));
		return t;
	}

	public static T smethod_1<T>(this object object_0, string string_0)
	{
		BindingFlags bindingFlags = (BindingFlags)52;
		Type type = object_0.GetType();
		FieldInfo field = type.GetField(string_0, bindingFlags);
		T t = (T)((object)field.GetValue(object_0));
		return t;
	}

	public static void smethod_2(this object object_0, string string_0, object object_1)
	{
		BindingFlags bindingFlags = (BindingFlags)52;
		Type type = object_0.GetType();
		FieldInfo field = type.GetField(string_0, bindingFlags);
		field.SetValue(object_0, object_1);
	}

	public static T smethod_3<T>(this object object_0, string string_0)
	{
		BindingFlags bindingFlags = (BindingFlags)52;
		Type type = object_0.GetType();
		PropertyInfo property = type.GetProperty(string_0, bindingFlags);
		T t = (T)((object)property.GetValue(object_0, null));
		return t;
	}

	public static void smethod_4(this object object_0, string string_0, object object_1)
	{
		BindingFlags bindingFlags = (BindingFlags)52;
		Type type = object_0.GetType();
		PropertyInfo property = type.GetProperty(string_0, bindingFlags);
		property.SetValue(object_0, object_1, null);
	}

	public static T smethod_5<T>(this object object_0, string string_0, params object[] object_1)
	{
		BindingFlags bindingFlags = (BindingFlags)52;
		Type type = object_0.GetType();
		MethodInfo method = type.GetMethod(string_0, bindingFlags);
		T t = (T)((object)method.Invoke(object_0, object_1));
		return t;
	}

	public static T smethod_6<T>(this object object_0, string string_0)
	{
		T t = (T)((object)object_0.GetType().GetField(string_0, (BindingFlags)60).GetValue(object_0));
		return t;
	}

	public static void smethod_7<T>(this object object_0, string string_0, object object_1)
	{
		if (object_0 == null)
		{
		}
		else
		{
			Type type = object_0.GetType();
			type.GetField(string_0, (BindingFlags)60).SetValue(object_0, object_1);
		}
	}

	public static void smethod_8(this object object_0, string string_0)
	{
		if (object_0 != null)
		{
			Type type = object_0.GetType();
			type.GetField(string_0, (BindingFlags)60).SetValue(object_0, null);
		}
	}

	public static object smethod_9(this object object_0, string string_0, params object[] object_1)
	{
		MethodInfo method = object_0.GetType().GetMethod(string_0, (BindingFlags)60);
		object obj;
		if (method == null)
		{
			obj = null;
		}
		else
		{
			obj = method.Invoke(object_0, object_1);
		}
		return obj;
	}
}
