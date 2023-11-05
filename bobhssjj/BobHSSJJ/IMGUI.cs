using System;
using System.Runtime.InteropServices;
using Veh;

internal class IMGUI
{
	[DllImport("C:\\UI.dll")]
	public static extern bool _is32Running();

	[DllImport("C:\\UI.dll")]
	public static extern bool _is64Running();

	[DllImport("C:\\UI.dll")]
	public static extern int _CreateScreenWindow();

	[DllImport("C:\\UI.dll")]
	public static extern void _StartDrawThread(DrawCallback callback, int drawDelay);

	[DllImport("C:\\UI.dll")]
	public static extern float _GetFps();

	[DllImport("C:\\UI.dll")]
	public static extern void _MsgLoop();

	[DllImport("C:\\UI.dll")]
	public static extern void _SetConvertUTF8(bool bool_0);

	[DllImport("C:\\UI.dll")]
	public static extern bool _Begin(string string_1, ref bool bool_0, int int_0, int int_1);

	[DllImport("C:\\UI.dll")]
	public static extern void _End();

	[DllImport("C:\\UI.dll")]
	public static extern bool _Button(string string_1, int int_0, int int_1);

	[DllImport("C:\\UI.dll")]
	public static extern bool _TreeNode(string string_1);

	[DllImport("C:\\UI.dll")]
	public static extern void _TreePop();

	[DllImport("C:\\UI.dll")]
	public static extern void _SameLine();

	[DllImport("C:\\UI.dll")]
	public static extern bool _Checkbox(string string_1, ref bool bool_0);

	[DllImport("C:\\UI.dll")]
	public static extern bool _RadioButton(string string_1, ref int int_0, int int_1);

	[DllImport("C:\\UI.dll")]
	public static extern void _TextColored(ImVec4 imVec4_0, string string_1);

	[DllImport("C:\\UI.dll")]
	public static extern bool _SliderInt(string string_1, ref int int_0, int int_1, int int_2, string string_2);

	[DllImport("C:\\UI.dll")]
	public static extern bool _SliderFloat(string string_1, ref float float_0, float float_1, float float_2, string string_2);

	[DllImport("C:\\UI.dll")]
	public static extern void _Text(string string_1);

	[DllImport("C:\\UI.dll")]
	public static extern bool _ColorEdit4(string string_1, ref ImVec4 imVec4_0);

	[DllImport("C:\\UI.dll")]
	public static extern bool _BeginMainMenuBar();

	[DllImport("C:\\UI.dll")]
	public static extern bool _MenuItem(string string_1, ref bool bool_0);

	[DllImport("C:\\UI.dll")]
	public static extern void _EndMainMenuBar();

	[DllImport("C:\\UI.dll")]
	public static extern uint _GetImU32ByImVec4(ImVec4 imVec4_0);

	[DllImport("C:\\UI.dll")]
	public static extern uint _GetImU32ByRGBA(int int_0, int int_1, int int_2, int int_3);

	[DllImport("C:\\UI.dll")]
	public static extern void _AddCircleFilled(ImVec2 imVec2_0, float float_0, uint uint_0, int int_0);

	[DllImport("C:\\UI.dll")]
	public static extern void _AddCircle(ImVec2 imVec2_0, float float_0, uint uint_0, int int_0, float float_1);

	[DllImport("C:\\UI.dll")]
	public static extern void _AddLine(ImVec2 imVec2_0, ImVec2 imVec2_1, uint uint_0, float float_0);

	[DllImport("C:\\UI.dll")]
	public static extern void _AddText(ImVec2 imVec2_0, uint uint_0, string string_1);

	[DllImport("C:\\UI.dll")]
	public static extern void _AddText1(int int_0, float float_0, ImVec2 imVec2_0, uint uint_0, string string_1);

	[DllImport("C:\\UI.dll")]
	public static extern void _AddText2(float float_0, ImVec2 imVec2_0, uint uint_0, string string_1);

	[DllImport("C:\\UI.dll")]
	public static extern void _CalcTextSizeNew(int int_0, int int_1, int int_2, string string_1, ref float float_0, ref float float_1);

	public static ImVec2 smethod_30(int int_0, int int_1, int int_2, string string_1)
	{
		ImVec2 imVec = default(ImVec2);
		_CalcTextSizeNew(int_0, int_1, int_2, string_1, ref imVec.x, ref imVec.y);
		return imVec;
	}

	[DllImport("C:\\UI.dll")]
	public static extern void _AddRect(ImVec2 imVec2_0, ImVec2 imVec2_1, uint uint_0, int int_0, int int_1, float float_0);

	[DllImport("C:\\UI.dll")]
	public static extern void _AddRectFilled(ImVec2 imVec2_0, ImVec2 imVec2_1, uint uint_0, int int_0, int int_1);

	[DllImport("C:\\UI.dll")]
	public static extern void _AddTriangleFilled(ImVec2 imVec2_0, ImVec2 imVec2_1, ImVec2 imVec2_2, uint uint_0);

	[DllImport("C:\\UI.dll")]
	public static extern void _AddTriangle(ImVec2 imVec2_0, ImVec2 imVec2_1, ImVec2 imVec2_2, uint uint_0, float float_0);

	[DllImport("C:\\UI.dll")]
	public static extern int _CreateImageFromBytes(byte[] byte_0, int int_0);

	public static int CreateImageFromBytes(byte[] byte_0, int int_0)
	{
		int num;
		try
		{
			num = _CreateImageFromBytes(byte_0, int_0);
		}
		catch (Exception ex)
		{
            Main.instance.Log("exception:" + ex.ToString());
			num = 0;
		}
		return num;
	}

	[DllImport("C:\\UI.dll")]
	public static extern void _AddImage(int int_0, ImVec2 imVec2_0, ImVec2 imVec2_1, ImVec2 imVec2_2, ImVec2 imVec2_3, uint uint_0);

	[DllImport("C:\\UI.dll")]
	public static extern int _CreateFontFromTTF(string string_1, float float_0);

	internal const string UIDll = "C:\\UI.dll";

	public delegate void DrawCallback();
}
