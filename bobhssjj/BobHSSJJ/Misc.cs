using System;
using System.Collections.Generic;
using Entitas;
using SSJJUserCmd;
using Veh;
using Veh.Hs;

internal class Misc
{
	public Misc(Main class12_1)
	{
		long_0 = 0L;
		class12_0 = class12_1;
		miscConfig_0.antiAimEnabled = false;
		miscConfig_0.antiAimTypeX = 0;
		miscConfig_0.antiAimTypeY = 1;
		miscConfig_0.antiAimTypeYAngle = 0f;
		miscConfig_0.antiAimTypeYSpinFactor = 12;
		miscConfig_0.antiAimTypeYJitterMin = -45f;
		miscConfig_0.antiAimTypeYJitterMax = 45f;
		miscConfig_0.fakeLag = false;
		miscConfig_0.fakeLagChokeFactor = 10;
		miscConfig_0.bhop = false;
        miscConfig_0.accurary = 0.8f;
    }

	long method_0()
	{
		long ticks = DateTime.Now.Ticks;
		DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		long num = (ticks - dateTime.Ticks) / (long)10000;
		long num2 = num;
		return num2;
	}

	public string method_1(string string_0, string string_1, string string_2)
	{
		string text = string_0.Substring(string_0.IndexOf(string_1) + string_1.Length);
		return text.Substring(0, text.IndexOf(string_2));
	}

	public void bhop(PlayerEntity playerEntity_1, ref UserCmd userCmd_0)
	{
		if (miscConfig_0.bhop)
		{
			if (!playerEntity_1.OnGround())
			{
				if (userCmd_0.IsJump)
				{
					userCmd_0.Buttons &= -33;
				}
				float axisX = userCmd_0.AxisX;
				if (axisX >= 2f)
				{
					UserCmd userCmd = userCmd_0;
					userCmd.MoveRight = 100f;
				}
				else
				{
					float axisX2 = userCmd_0.AxisX;
					if (axisX2 <= -2f)
					{
						userCmd_0.MoveRight = -100f;
					}
				}
			}
		}
	}

	public void HeartBeat()
	{
        /*
		if (Main.instance.finishLoad)
		{
			long num = method_0();
			long num2 = num - long_0;
			if (num2 > (long)1000)
			{
				long_0 = num;
				Verify.smethod_6();
				Verify.smethod_5();
			}
		}
        */
	}

	public void method_4()
	{
	}

	public void MenuDrawing(ref bool bool_0)
	{
		IMGUI._Begin("杂项设置", ref bool_0, 700, 700);
		IMGUI._Checkbox("连跳", ref miscConfig_0.bhop);
		IMGUI._Checkbox("反自瞄启动[Home]", ref miscConfig_0.antiAimEnabled);
		IMGUI._TextColored(new ImVec4(0f, 1f, 0f, 1f), "反自瞄X轴类型:");
		IMGUI._RadioButton("假抬头[Num7]", ref miscConfig_0.antiAimTypeX, 0);
		IMGUI._SameLine();
		IMGUI._RadioButton("假低头[Num9]", ref miscConfig_0.antiAimTypeX, 1);
		IMGUI._RadioButton("抬头[Num8]", ref miscConfig_0.antiAimTypeX, 2);
		IMGUI._SameLine();
		IMGUI._RadioButton("低头[Num2]", ref miscConfig_0.antiAimTypeX, 3);
		IMGUI._RadioButton("平视[Num5]", ref miscConfig_0.antiAimTypeX, 4);
		IMGUI._TextColored(new ImVec4(0f, 1f, 0f, 1f), "反自瞄Y轴类型:");
		IMGUI._RadioButton("手动", ref miscConfig_0.antiAimTypeY, 0);
		IMGUI._SameLine();
		IMGUI._RadioButton("旋转", ref miscConfig_0.antiAimTypeY, 1);
		IMGUI._SameLine();
		IMGUI._RadioButton("抖动", ref miscConfig_0.antiAimTypeY, 2);
		IMGUI._SliderFloat("Y轴角度", ref miscConfig_0.antiAimTypeYAngle, -180f, 180f, "Yaw: %.0f");
		if (miscConfig_0.antiAimTypeY != 2)
		{
			if (miscConfig_0.antiAimTypeY == 1)
			{
				string text = "旋转速度";
				int num = 1;
				int num2 = 1080;
				IMGUI._SliderInt(text, ref miscConfig_0.antiAimTypeYSpinFactor, num, num2, "RPM: %.0f");
			}
		}
		else
		{
			IMGUI._SliderFloat("最小抖动角度", ref miscConfig_0.antiAimTypeYJitterMin, -180f, 180f, "MinJitter: %.0f");
			string text2 = "最大抖动角度";
			float num4 = -180f;
			float num5 = 180f;
			IMGUI._SliderFloat(text2, ref miscConfig_0.antiAimTypeYJitterMax, num4, num5, "MaxJitter: %.0f");
		}
		IMGUI._TextColored(new ImVec4(0f, 1f, 0f, 1f), "键盘快捷键: Z=左 X=背身 C=右");
		IMGUI._Checkbox("假延迟[Num0]", ref miscConfig_0.fakeLag);
		if (miscConfig_0.fakeLag)
		{
			IMGUI._TextColored(new ImVec4(0f, 1f, 0f, 1f), "假延迟延迟数:");
			string text3 = "假延迟";
			int num8 = 0;
			int num9 = 50;
			IMGUI._SliderInt(text3, ref miscConfig_0.fakeLagChokeFactor, num8, num9, "延迟: %.0fTick");
			IMGUI._SameLine();
		}
        IMGUI._TextColored(new ImVec4(0f, 1f, 0f, 1f), "武器:");
        IMGUI._SliderFloat("射击精准度", ref miscConfig_0.accurary, 1f, 100f, "accurary: %.0f");
        IMGUI._SameLine();
        IMGUI._TextColored(new ImVec4(0f, 1f, 0f, 1f), "*过高会不开枪");
        IMGUI._End();
    }

	internal MiscConfig miscConfig_0;

	readonly Main class12_0;

	long long_0;

	public enum pitchType
	{
		FakeUp,
		FakeDown,
		Up,
		Down,
		Zero
	}

	public enum Enum10
	{
		const_0,
		const_1,
		const_2
	}
}
