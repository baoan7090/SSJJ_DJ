using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Veh;
using Veh.Hs;

internal class Menu_Bar
{
	public void MenuDrawing()
	{
        //eClass11._MsgLoop();
        if (Main.instance.finishLoad)
		{
			try
			{
                
				bool isMenull;
				if (main.EntityList != null)
				{
					isMenull = main.myPlayer == null;
				}
				else
				{
					isMenull = true;
				}
				if (isMenull)
				{
					//return;
				}
				main._esp.DrawESP();
				main._misc_config.nothing();
                
				if (!ShowMenu)
				{
					return;
				}
                
				if (IMGUI._BeginMainMenuBar())
				{
					IMGUI._Text("迪迦 - 破解版");
					IMGUI._MenuItem("透视", ref guiconfig_0.ESPWindow);
					IMGUI._MenuItem("自动瞄准", ref guiconfig_0.AimbotWindow);
					IMGUI._MenuItem("视觉", ref guiconfig_0.VisualsWindow);
					IMGUI._MenuItem("杂项", ref guiconfig_0.MiscWindow);
					IMGUI._MenuItem("配置文件", ref guiconfig_0.ConfigWindow);
					ImVec4 imVec = new ImVec4(0f, 1f, 0f, 1f);
					IMGUI._TextColored(imVec, "FPS: " + IMGUI._GetFps().ToString());
					IMGUI._EndMainMenuBar();
				}
				if (guiconfig_0.ESPWindow)
				{
					main._esp.MenuDrawing(ref guiconfig_0.ESPWindow);
				}
				if (guiconfig_0.AimbotWindow)
				{
					main._rage_aimbot.MenuDrawing(ref guiconfig_0.AimbotWindow);
				}
				if (!guiconfig_0.NoRecoilWindow)
				{
				}
				if (guiconfig_0.VisualsWindow)
				{
					main.class38_0.method_6(ref guiconfig_0.VisualsWindow);
				}
				if (guiconfig_0.MiscWindow)
				{
					main._misc.MenuDrawing(ref guiconfig_0.MiscWindow);
				}
				if (guiconfig_0.ConfigWindow)
				{
					main._misc_config.MenuDrawing(ref guiconfig_0.ConfigWindow);
				}
				//goto IL_511;
			}
			catch (Exception ex)
			{
				Main.instance.Log(string.Format("[ImGui]捕获到未处理异常：{0}\r\n异常信息：{1}\r\n异常堆栈：{2}", ex.GetType(), ex.Message, ex.StackTrace));
				Main.instance.error_counter++;
				if (Main.instance.error_counter >= 100)
				{
					Loader.Unload();
				}
				//goto IL_511;
			}
		}
    //IL_511:;
	}

	public void CheckMenuKey()
	{
		if (Main.instance.finishLoad)
		{
			if (Input.GetKeyDown(KeyCode.Insert))
			{
				ShowMenu = !ShowMenu;
			}
		}
	}

	public Menu_Bar(Main _main)
	{
		drawCallback = null;
		guiconfig_0.ESPWindow = false;
		guiconfig_0.AimbotWindow = false;
		guiconfig_0.NoRecoilWindow = false;
		guiconfig_0.VisualsWindow = false;
		guiconfig_0.AntidetectionWindow = true;
		guiconfig_0.AIWalkerWindow = false;
		ShowMenu = true;
		main = _main;
        //int_0 = 
        IMGUI._CreateScreenWindow();
		drawCallback = new IMGUI.DrawCallback(MenuDrawing);
		IMGUI._StartDrawThread(drawCallback, 10);
    }

	internal GUIConfig guiconfig_0;

	readonly Main main;

	//public int int_0;

	public bool ShowMenu;

	IMGUI.DrawCallback drawCallback;
}
