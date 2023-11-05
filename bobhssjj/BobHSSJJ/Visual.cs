using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Veh;
using Veh.Hs;

internal class Visual
{
	public Visual(Main class12_1)
	{
		class12_0 = class12_1;
		visualsConfig_0.noTeammateName = true;
		visualsConfig_0.showCrosshair = true;
		visualsConfig_0.noTeammateRender = false;
		visualsConfig_0.noHpBar = true;
	}

	long method_0()
	{
		long ticks = DateTime.Now.Ticks;
		DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
		long num = (ticks - dateTime.Ticks) / 10000;
		return num;
	}

	void method_1()
	{
		ImVec2 imVec = new ImVec2(0f, Screen.height / 2);
		ImVec2 imVec2 = new ImVec2(Screen.width, Screen.height / 2);
		IMGUI._AddLine(imVec, imVec2, IMGUI._GetImU32ByRGBA(0, 255, 0, 255), 1.5f);
		imVec = new ImVec2(Screen.width / 2, 0f);
		imVec2 = new ImVec2(Screen.width / 2, Screen.height);
		IMGUI._AddLine(imVec, imVec2, IMGUI._GetImU32ByRGBA(0, 255, 0, 255), 1.5f);
	}

	public string method_2(string string_0, string string_1, string string_2)
	{
		string text = string_0.Substring(string_0.IndexOf(string_1) + string_1.Length);
		return text.Substring(0, text.IndexOf(string_2));
	}

	bool method_3(string string_0)
	{
		string text = string_0.Replace("[" + method_2(string_0, "[", "]") + "]", "");
		playerEntity_0 = class12_0.myPlayer;
		List<IEntity>.Enumerator enumerator = class12_0.EntityList.GetEnumerator();
		bool flag;
		try
		{
			for (;;)
			{
				if (!enumerator.MoveNext())
				{
					break;
				}
				IEntity entity = enumerator.Current;
				if (entity != null)
				{
					PlayerEntity playerEntity = (PlayerEntity)entity;
					if (playerEntity != null)
					{
						if (playerEntity.hasBasicInfo)
						{
							if (playerEntity_0 != null)
							{
                                if (playerEntity.GetTeam() != playerEntity_0.GetTeam())
                                {
                                }
                                else
                                {
                                    if (playerEntity.basicInfo.PlayerName.Contains(text))
                                    {
                                        goto IL_389;
                                    }
                                }
                            }
						}
					}
				}
			}
			goto IL_3F2;
			IL_389:
			flag = true;
			goto IL_3F5;
		}
		finally
		{
			((IDisposable)enumerator).Dispose();
		}
		IL_3F2:
		flag = false;
		IL_3F5:
		return flag;
	}

	public void verify(ref List<IEntity> list_1, ref PlayerEntity playerEntity_1)
	{
		if (!Main.instance.finishLoad)
		{
		}
		else
		{
			long num = method_0();
			long num2 = num - long_0;
			if (num2 > (long)1000)
			{
				//Verify.smethod_6();
				//Verify.smethod_5();
				list_0.Clear();
				long_0 = num;
				UnityEngine.Object[] array = UnityEngine.Object.FindObjectsOfType(typeof(GameObject));
				int num4 = 0;
				for (;;)
				{
					if (num4 >= array.Length)
					{
						break;
					}
					GameObject gameObject = (GameObject)array[num4];
					bool flag;
					if (gameObject.name == "NameText")
					{
						flag = visualsConfig_0.noTeammateName;
					}
					else
					{
						flag = false;
					}
					if (flag)
					{
						list_0.Add(gameObject);
					}
					bool flag2;
					if (gameObject.name.Contains("[") && gameObject.name.Contains("]") && !gameObject.name.Contains("PlayerHpBar") && visualsConfig_0.noTeammateRender)
					{
						flag2 = method_3(gameObject.name);
					}
					else
					{
						flag2 = false;
					}
					if (flag2)
					{
						list_0.Add(gameObject);
					}
					bool flag3;
					if (gameObject.name.Contains("PlayerHpBar"))
					{
						flag3 = visualsConfig_0.noHpBar;
					}
					else
					{
						flag3 = false;
					}
					if (flag3)
					{
						list_0.Add(gameObject);
					}
					num4++;
				}
			}
			List<GameObject>.Enumerator enumerator = list_0.GetEnumerator();
			try
			{
				for (;;)
				{
					if (!enumerator.MoveNext())
					{
						break;
					}
					GameObject gameObject2 = enumerator.Current;
					if (gameObject2 == null)
					{
					}
					else
					{
						gameObject2.SetActive(false);
					}
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}
	}

	public void method_5()
	{
		if (visualsConfig_0.showCrosshair)
		{
			method_1();
		}
	}

	public void method_6(ref bool bool_0)
	{
		IMGUI._Begin("视觉设置", ref bool_0, 500, 500);
		IMGUI._Checkbox("不显示队友名字(游戏内)", ref visualsConfig_0.noTeammateName);
		IMGUI._SameLine();
		IMGUI._Checkbox("全屏准星", ref visualsConfig_0.showCrosshair);
		IMGUI._Checkbox("不渲染队友模型", ref visualsConfig_0.noTeammateRender);
		IMGUI._SameLine();
		IMGUI._Checkbox("不显示血条(游戏内)", ref visualsConfig_0.noHpBar);
		IMGUI._Checkbox("无视觉后坐力", ref visualsConfig_0.noVisualRecoil);
		IMGUI._End();
	}

	internal VisualsConfig visualsConfig_0;

	PlayerEntity playerEntity_0;

	readonly Main class12_0;

	long long_0 = 0L;

	List<GameObject> list_0 = new List<GameObject>();
}
