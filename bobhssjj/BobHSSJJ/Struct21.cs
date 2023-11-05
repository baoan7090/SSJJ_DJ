using System;
using System.Reflection;
using UnityEngine;

internal struct Struct21
{
	public static void Start()
	{
		texture2D_2 = new Texture2D(2, 2, TextureFormat.ARGB32, false);
		texture2D_2.SetPixel(0, 0, Color.red);
		texture2D_2.SetPixel(1, 0, Color.red);
		texture2D_2.SetPixel(0, 1, Color.red);
		texture2D_2.SetPixel(1, 1, Color.red);
		texture2D_2.Apply();
		texture2D_3 = new Texture2D(2, 2, TextureFormat.ARGB32, false);
		texture2D_3.SetPixel(0, 0, Color.green);
		texture2D_3.SetPixel(1, 0, Color.green);
		texture2D_3.SetPixel(0, 1, Color.green);
		texture2D_3.SetPixel(1, 1, Color.green);
		texture2D_3.Apply();
		texture2D_4 = new Texture2D(2, 2, TextureFormat.ARGB32, false);
		texture2D_4.SetPixel(0, 0, Color.gray);
		texture2D_4.SetPixel(1, 0, Color.gray);
		texture2D_4.SetPixel(0, 1, Color.gray);
		texture2D_4.SetPixel(1, 1, Color.gray);
		texture2D_4.Apply();
		texture2D_5 = new Texture2D(2, 2, TextureFormat.ARGB32, false);
		texture2D_5.SetPixel(0, 0, Color.blue);
		texture2D_5.SetPixel(1, 0, Color.blue);
		texture2D_5.SetPixel(0, 1, Color.blue);
		texture2D_5.SetPixel(1, 1, Color.blue);
		texture2D_5.Apply();
		texture2D_6 = new Texture2D(2, 2, TextureFormat.ARGB32, false);
		texture2D_6.SetPixel(0, 0, Color.yellow);
		texture2D_6.SetPixel(1, 0, Color.yellow);
		texture2D_6.SetPixel(0, 1, Color.yellow);
		texture2D_6.SetPixel(1, 1, Color.yellow);
		texture2D_6.Apply();
		if (texture2D_1 == null)
		{
			texture2D_1 = new Texture2D(1, 1, TextureFormat.ARGB32, false);
			texture2D_1.SetPixel(0, 1, Color.white);
			texture2D_1.Apply();
		}
		
		if (texture2D_0 == null)
		{
			texture2D_0 = new Texture2D(1, 3, TextureFormat.ARGB32, false);
			texture2D_0.SetPixel(0, 0, new Color(1f, 1f, 1f, 0f));
			texture2D_0.SetPixel(0, 1, Color.white);
			texture2D_0.SetPixel(0, 2, new Color(1f, 1f, 1f, 0f));
			texture2D_0.Apply();
		}
		material_0 = (Material)typeof(GUI).GetMethod("get_blitMaterial", (BindingFlags)40).Invoke(null, null);
		material_1 = (Material)typeof(GUI).GetMethod("get_blendMaterial", (BindingFlags)40).Invoke(null, null);
		guistyle_0 = new GUIStyle();
		guistyle_0.fontSize = 15;
		guistyle_0.normal.textColor = new Color(1f, 1f, 1f);
	}

	public static void smethod_0(Rect rect_1, string string_0, GUIStyle guistyle_1, bool bool_0 = true)
	{
		Color textColor = guistyle_1.normal.textColor;
		guistyle_1.normal.textColor = new Color(0f, 0f, 0f);
		GUI.Label(new Rect(rect_1.x - 2, rect_1.y - 2, rect_1.width, rect_1.height), string_0, guistyle_1);
		GUI.Label(new Rect(rect_1.x - 2, rect_1.y + 2, rect_1.width, rect_1.height), string_0, guistyle_1);
		GUI.Label(new Rect(rect_1.x + 2, rect_1.y + 2, rect_1.width, rect_1.height), string_0, guistyle_1);
		GUI.Label(new Rect(rect_1.x + 2, rect_1.y - 2, rect_1.width, rect_1.height), string_0, guistyle_1);
		guistyle_1.normal.textColor = textColor;
		GUI.Label(rect_1, string_0, guistyle_1);
	}

	public static void smethod_1(Vector2 vector2_0, Vector2 vector2_1, Color color_0, float float_0, bool bool_0)
	{
		Color color = GUI.color;
		float num = vector2_1.x - vector2_0.x;
		float num2 = vector2_1.y - vector2_0.y;
		float num3 = Mathf.Sqrt(num * num + num2 * num2);
		if (num3 < 0.001)
		{
		}
		else
		{
			Texture2D texture2D;
			if (bool_0)
			{
				float_0 *= 3;
				texture2D = texture2D_0;
			}
			else
			{
				texture2D = texture2D_1;
			}
			float num4 = float_0 * num2 / num3;
			float num5 = float_0 * num / num3;
			Matrix4x4 identity = Matrix4x4.identity;
			identity.m00 = num;
			identity.m01 = -num4;
			identity.m03 = vector2_0.x + 0.5f * num4;
			identity.m10 = num2;
			identity.m11 = num5;
			float y = vector2_0.y;
			identity.m13 = y - 0.5f * num5;
			GL.PushMatrix();
			GL.MultMatrix(identity);
			GUI.color = color_0;
			GUI.DrawTexture(rect_0, texture2D);
			GL.PopMatrix();
			GUI.color = color;
		}
	}

	public static void smethod_2(float float_0, float float_1, float float_2, float float_3, Texture2D texture2D_7)
	{
		GUI.DrawTexture(new Rect(float_0, float_1, float_2, float_3), texture2D_7);
	}

	public static void smethod_3(float float_0, float float_1, float float_2, float float_3, Texture2D texture2D_7, float float_4 = 1f)
	{
		smethod_2(float_0, float_1, float_4, float_3, texture2D_7);
		smethod_2(float_0 + float_2 - float_4, float_1, float_4, float_3, texture2D_7);
		smethod_2(float_0 + float_4, float_1, float_2 - float_4 * 2, float_4, texture2D_7);
		smethod_2(float_0 + float_4, float_1 + float_3 - float_4, float_2 - float_4 * 2, float_4, texture2D_7);
	}

	public static void smethod_4(float float_0, float float_1, float float_2, float float_3, Texture2D texture2D_7, float float_4 = 1f)
	{
		smethod_3(float_0 - float_2 / 2, float_1 - float_3, float_2, float_3, texture2D_7, float_4);
	}

	public static void smethod_5()
	{
		texture2D_0 = null;
		texture2D_1 = null;
		texture2D_2 = null;
		texture2D_3 = null;
		texture2D_4 = null;
		texture2D_5 = null;
		texture2D_6 = null;
		material_0 = null;
		material_1 = null;
	}


	private static Texture2D texture2D_0 = null;

	private static Texture2D texture2D_1 = null;

	public static Texture2D texture2D_2 = null;

	public static Texture2D texture2D_3 = null;

	public static Texture2D texture2D_4 = null;

	public static Texture2D texture2D_5 = null;

	public static Texture2D texture2D_6 = null;

	public static Material material_0 = null;

	public static Material material_1 = null;

	public static Rect rect_0 = new Rect(0f, 0f, 1f, 1f);

	public static GUIStyle guistyle_0 = GUIStyle.none;
}

static class ext
{
    public static MethodInfo method_0(this Type type, string string_0, BindingFlags bindingFlags_0)
    {
        return type.GetMethod(string_0, bindingFlags_0);
    }
}
