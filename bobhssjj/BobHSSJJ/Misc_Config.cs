using System;
using System.IO;
using Newtonsoft.Json;
using Veh;
using Veh.Hs;

internal class Misc_Config
{
	public Misc_Config(Main main)
	{
		string_0 = "";
		imVec4_0 = new ImVec4(0f, 0f, 0f, 0f);
		_main = main;
		bool_0 = CheckConfig();
		if (!bool_0)
		{
			string_0 = "配置文件不存在!";
			imVec4_0 = new ImVec4(1f, 0f, 0f, 1f);
		}
		else
		{
			string_0 = "配置文件存在!";
			imVec4_0 = new ImVec4(0f, 1f, 0f, 1f);
			LoadConfig();
		}
	}

	void SaveConfig()
	{
		string text = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\BobHSSJJ_config";
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		string text2 = text + "\\default.json";
		Main.instance.Log("Configfile will save at " + text2);
		string text3 = JsonConvert.SerializeObject(new AllConfig
		{
			version = "3e8f9f34e1f470992ec447e36dff6d39",
			aimbot_config = _main._rage_aimbot.aimbotConfig_0,
			esp_config = _main._esp.espconfig_0,
			gui_config = _main._menu_bar.guiconfig_0,
			visual_config = _main.class38_0.visualsConfig_0,
			misc_config = _main._misc.miscConfig_0
		}, Formatting.Indented);
		try
		{
			FileStream fileStream = new FileStream(text2, FileMode.Create, FileAccess.Write);
			StreamWriter streamWriter = new StreamWriter(fileStream);
			streamWriter.Write(text3);
			streamWriter.Close();
			fileStream.Close();
		}
		catch (Exception ex)
		{
			string_0 = "保存失败,异常信息:" + ex.Message;
			imVec4_0 = new ImVec4(1f, 0f, 0f, 1f);
		}
		finally
		{
			string_0 = "保存成功!";
			imVec4_0 = new ImVec4(0f, 1f, 0f, 1f);
		}
	}

	void LoadConfig()
	{
		bool_0 = CheckConfig();
		if (bool_0)
		{
			string text = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\BobHSSJJ_config";
			string text2 = text + @"\default.json";
			try
			{
				try
				{
					FileStream fileStream = new FileStream(text2, FileMode.Open, FileAccess.Read);
					StreamReader streamReader = new StreamReader(fileStream);
					string text3 = streamReader.ReadToEnd();
					streamReader.Close();
					fileStream.Close();
					AllConfig allConfig = default(AllConfig);
					allConfig = JsonConvert.DeserializeObject<AllConfig>(text3);
					_main._rage_aimbot.aimbotConfig_0 = allConfig.aimbot_config;
					_main._esp.espconfig_0 = allConfig.esp_config;
					_main._menu_bar.guiconfig_0 = allConfig.gui_config;
					_main.class38_0.visualsConfig_0 = allConfig.visual_config;
                    _main._misc.miscConfig_0 = allConfig.misc_config;
				}
				catch (Exception ex)
				{
					string_0 = "载入失败,异常信息:" + ex.Message;
					imVec4_0 = new ImVec4(1f, 0f, 0f, 1f);
				}
				goto IL_29B;
			}
			finally
			{
				string_0 = "载入成功";
				imVec4_0 = new ImVec4(0f, 1f, 0f, 1f);
			}
		}
		string_0 = "配置文件不存在,载入失败!";
		imVec4_0 = new ImVec4(1f, 0f, 0f, 1f);
    IL_29B:;
	}

	bool CheckConfig()
	{
		string text = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\BobHSSJJ_config";
		bool flag;
		if (Directory.Exists(text))
		{
			string text2 = text + @"\default.json";
			flag = File.Exists(text2);
		}
		else
		{
			flag = false;
		}
		return flag;
	}

	internal void MenuDrawing(ref bool bool_1)
	{
		IMGUI._Begin("配置管理", ref bool_1, 500, 150);
		if (IMGUI._Button("保存配置", 0, 0))
		{
			SaveConfig();
		}
		IMGUI._SameLine();
		if (IMGUI._Button("载入配置", 0, 0))
		{
			LoadConfig();
		}
		if (string_0 != "")
		{
			IMGUI._TextColored(imVec4_0, string_0);
		}
		IMGUI._End();
	}

	internal void nothing()
	{
	}

	readonly Main _main;

	bool bool_0;

	string string_0;

	ImVec4 imVec4_0;
}
