using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Assets.Sources.Components.UserComand;
using Assets.Sources.Utils.Weapon;
using Entitas;
using share;
using SSJJPhysics;
using UnityEngine;
using Veh;
using Veh.Hs;

internal class Rage_Aimbot
{
	[DllImport("user32.dll")]
	static extern void mouse_event(int int_3, int int_4, int int_5, int int_6, int int_7);

	public Rage_Aimbot(Main main)
	{
		mainCam = null;
		bool_0 = false;
		playerEntity_0 = null;
		int_1 = 1;
		_tempAimkey = 3;
		_main = main;
		mainCam = Camera.main;
		aimbotConfig_0.enable = true;
		aimbotConfig_0.aimPos = "Bip01_Head";
		aimbotConfig_0.aimType = 2;
		aimbotConfig_0.aimKey = KeyCode.Mouse0;
		aimbotConfig_0.aimRange = 1000;
		aimbotConfig_0.smooth = 0.1f;
		aimbotConfig_0.maxMoveAngle = 999f;
		aimbotConfig_0.aimTeam = false;
		aimbotConfig_0.onKeyAim = false;
		aimbotConfig_0.bodyAim = false;
		aimbotConfig_0.hitScan = false;
		aimbotConfig_0.silentAim = true;
		aimbotConfig_0.pSilent = true;
		aimbotConfig_0.noRecoil = true;
	}

	Vector3 method_0(Vector3 vector3_0)
	{
		return new Vector3(-vector3_0.y, vector3_0.z, vector3_0.x);
	}

	Vector3 method_1(Vector3 vector3_0)
	{
		return new Vector3(vector3_0.z, -vector3_0.x, vector3_0.y);
	}

	bool method_2(ref PlayerEntity playerEntity_2, ref PlayerEntity playerEntity_3)
	{
		Vector3 normalized = (Misc_Pos_Movement_Godstate.GetEntityPos(playerEntity_2) - Misc_Pos_Movement_Godstate.GetEntityPos(playerEntity_3)).normalized;
		TraceResult traceResult = FireUtility.BulletTrace(Contexts.sharedInstance.battleRoom.pyEngine.PyEngine, playerEntity_3, Contexts.sharedInstance.player, 100000f, new Vector3D((double)normalized.x, (double)normalized.y, (double)normalized.z), new float[3], new float[3], false);
		bool flag = traceResult.EntityId == playerEntity_2.GetId();
		return flag;
	}

	public static Vector3 smethod_0(Vector3 vector3_0, Vector3 vector3_1)
	{
		Vector3 normalized = (vector3_1 - vector3_0).normalized;
		float num = Mathf.Atan2(normalized.z, normalized.x) * 57.29578f - 90f;
		float num2 = num;
		if (num2 < -180f)
		{
			num += 360f;
		}
		float num4 = num;
		if (num4 > 180f)
		{
			num -= 360f;
		}
		float num6 = Mathf.Asin(normalized.y / normalized.magnitude) * 57.29578f;
		num = Mathf.Clamp(num, -180f, 180f);
		num6 = Mathf.Clamp(num6, -89f, 89f);
		Vector3 vector = new Vector3(num6, num, 0f);
		return vector;
	}

	public static float smethod_1(float float_0, float float_1, float float_2)
	{
		float num;
		if (float_0 <= float_1)
		{
			num = float_1;
		}
		else if (float_0 >= float_2)
		{
			num = float_2;
		}
		else
		{
			num = float_0;
		}
		return num;
	}

	public static Vector3 smethod_2(Vector3 vector3_0)
	{
		vector3_0.x = smethod_1(vector3_0.x, -89f, 89f);
		vector3_0.y = smethod_1(vector3_0.y, -180f, 180f);
		vector3_0.z = 0f;
		Vector3 vector = vector3_0;
		return vector;
	}

	public static Vector3 smethod_3(Vector3 vector3_0)
	{
		if (vector3_0.x > 89f)
		{
			vector3_0.x -= 180f;
		}
		float x = vector3_0.x;
		if (x < -89f)
		{
			vector3_0.x += 180f;
		}
		vector3_0.y %= 360f;
		if (vector3_0.y > 180f)
		{
			vector3_0.y -= 360f;
		}
		Vector3 vector = vector3_0;
		return vector;
	}

	public void method_3(Vector3 vector3_0)
	{
		Vector3 vector = mainCam.transform.position + Misc_Pos_Movement_Godstate.smethod_0(playerEntity_1.move.Velocity) * ((float)Contexts.sharedInstance.userCommand.commands.CommandToSendList.Last.Value.FrameInterval * 0.001f);
		InputComponent input = Contexts.sharedInstance.userCommand.input;
		Vector3 vector2 = smethod_0(vector, vector3_0);
		vector2 = smethod_3(vector2);
		smethod_2(vector2);
		if (aimbotConfig_0.noRecoil)
		{
			Rage_Norecoil.noRecoil(playerEntity_1, ref vector2);
		}
		vector2 = smethod_3(vector2);
		smethod_2(vector2);
		input.Pitch = vector2.x;
		input.Yaw = vector2.y;
	}

	void Aimbot(ref List<IEntity> list_0, ref PlayerEntity playerEntity_2)
	{
		float num = 1E+09f;
		if (playerEntity_0 != null)
		{
			playerEntity_0 = null;
		}
		bool flag;
		if (bool_0)
		{
			flag = playerEntity_0 == null;
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			List<IEntity>.Enumerator enumerator = list_0.GetEnumerator();
			try
			{
				for (;;)
				{
					if (!enumerator.MoveNext())
					{
						break;
					}
					IEntity entity = enumerator.Current;
					if (entity == null)
					{
					}
					else
					{
						PlayerEntity playerEntity = (PlayerEntity)entity;
						if (playerEntity == playerEntity_2)
						{
						}
						else
						{
							if (!playerEntity.hasThirdPersonUnityObjects)
							{
							}
							else
							{
								Transform bone = playerEntity.thirdPersonUnityObjects.Animator.GetBone(aimbotConfig_0.aimPos);
								if (bone == null)
								{
								}
								else
								{
									bool flag2;
									if (playerEntity.GetTeam() == playerEntity_2.GetTeam())
									{
										flag2 = !aimbotConfig_0.aimTeam;
									}
									else
									{
										flag2 = false;
									}
									if (flag2)
									{
									}
									else
									{
										double hpPercent = playerEntity.GetHpPercent();
										if (hpPercent > 0.0)
										{
											if (!Misc_Pos_Movement_Godstate.GodState(playerEntity))
											{
												Vector3 vector = mainCam.WorldToScreenPoint(bone.position);
												if (vector.z >= 0f)
												{
													Vector2 vector2 = new Vector2(vector.x, (float)Screen.height - vector.y);
													float num2 = (float)Screen.width / 2f;
													float num3 = (float)Screen.height;
													Vector2 vector3 = new Vector2(num2, num3 / 2f);
													if ((vector3 - vector2).magnitude <= (float)aimbotConfig_0.aimRange)
													{
														if ((vector3 - vector2).magnitude < num)
														{
															num = (vector3 - vector2).magnitude;
															playerEntity_0 = playerEntity;
														}
													}
												}
												else
												{
												}
											}
											else
											{
											}
										}
										else
										{
										}
									}
								}
							}
						}
					}
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}
		if (playerEntity_0 != null)
		{
			if (!playerEntity_0.hasThirdPersonUnityObjects)
			{
			}
			else
			{
				Transform bone2 = playerEntity_0.thirdPersonUnityObjects.Animator.GetBone(aimbotConfig_0.aimPos);
				if (!(bone2 == null))
				{
					Vector3 vector4 = mainCam.WorldToScreenPoint(bone2.position);
					if (vector4.z >= 0f)
					{
						int num5 = (int)(vector4.x - (float)Screen.width / 2f);
						int num6 = (int)((float)Screen.height - vector4.y - (float)Screen.height / 2f);
						if (aimbotConfig_0.aimType != 1)
						{
							if (aimbotConfig_0.aimType == 2)
							{
								method_3(bone2.position + Misc_Pos_Movement_Godstate.smethod_0(playerEntity_0.move.Velocity) * ((float)Contexts.sharedInstance.userCommand.commands.CommandToSendList.Last.Value.FrameInterval * 0.001f));
							}
						}
						else
						{
							int num7 = 1;
							int num8 = (int)((float)num5 * aimbotConfig_0.smooth / 10f);
							float num9 = (float)num6 * aimbotConfig_0.smooth;
							mouse_event(num7, num8, (int)(num9 / 10f), 0, 0);
						}
						if (method_2(ref playerEntity_0, ref playerEntity_2))
						{
							int_0 = 3;
						}
						else
						{
							int_0 = 2;
						}
					}
					else
					{
					}
				}
				else
				{
				}
			}
		}
		else
		{
		}
	}

	bool CheckAimkey()
	{
		bool flag;
		if (!_main._menu_bar.ShowMenu)
		{
			if (aimbotConfig_0.aimKey == KeyCode.Mouse0)
			{
				flag = Input.GetMouseButton(0);
			}
			else if (aimbotConfig_0.aimKey != KeyCode.Mouse1)
			{
				flag = Input.GetKey(aimbotConfig_0.aimKey);
			}
			else
			{
				flag = Input.GetMouseButton(1);
			}
		}
		else
		{
			flag = false;
		}
		return flag;
	}

	public void Aiming(ref List<IEntity> EntityList, ref PlayerEntity myPlayer)
	{
		playerEntity_1 = myPlayer;
		mainCam = Camera.main;
		if (aimbotConfig_0.enable)
		{
			int_0 = 1;
			if (!CheckAimkey())
			{
				bool_0 = false;
				playerEntity_0 = null;
			}
			else
			{
				bool_0 = true;
				Aimbot(ref EntityList, ref myPlayer);
			}
		}
	}

	public void method_7()
	{
		if (aimbotConfig_0.enable)
		{
			if (int_0 == 1)
			{
				ImVec2 imVec = new ImVec2((float)Screen.width / 2f, (float)Screen.height / 2f);
				float num = (float)aimbotConfig_0.aimRange * 1f;
				uint num2 = IMGUI._GetImU32ByRGBA(255, 255, 255, 255);
				int num3 = 80;
				IMGUI._AddCircle(imVec, num, num2, num3, 1.5f);
			}
			else
			{
				if (int_0 == 2)
				{
					ImVec2 imVec2 = new ImVec2((float)Screen.width / 2f, (float)Screen.height / 2f);
					float num5 = (float)aimbotConfig_0.aimRange * 1f;
					uint num6 = IMGUI._GetImU32ByRGBA(255, 0, 0, 255);
					int num7 = 80;
					IMGUI._AddCircle(imVec2, num5, num6, num7, 1.5f);
				}
				else
				{
					if (int_0 == 3)
					{
						ImVec2 imVec3 = new ImVec2((float)Screen.width / 2f, (float)Screen.height / 2f);
						float num9 = (float)aimbotConfig_0.aimRange * 1f;
						uint num10 = IMGUI._GetImU32ByRGBA(0, 255, 0, 255);
						int num11 = 80;
						IMGUI._AddCircle(imVec3, num9, num10, num11, 1.5f);
					}
				}
			}
		}
	}

	void UpdateConfigAimpos()
	{
		if (int_1 != 1)
		{
			if (int_1 != 2)
			{
				if (int_1 == 3)
				{
					aimbotConfig_0.aimPos = "Bip01_Spine2";
				}
				else
				{
					if (int_1 == 4)
					{
						aimbotConfig_0.aimPos = "Bip01_Spine";
					}
				}
			}
			else
			{
				aimbotConfig_0.aimPos = "Bip01_Neck";
			}
		}
		else
		{
			aimbotConfig_0.aimPos = "Bip01_Head";
		}
	}

	void UpdateConfigAimkey()
	{
		if (_tempAimkey != 1)
		{
			if (_tempAimkey == 2)
			{
				aimbotConfig_0.aimKey = KeyCode.LeftControl;
			}
			else
			{
				if (_tempAimkey == 3)
				{
					aimbotConfig_0.aimKey = KeyCode.Mouse0;
				}
				else
				{
					if (_tempAimkey == 4)
					{
						aimbotConfig_0.aimKey = KeyCode.Mouse1;
					}
				}
			}
		}
		else
		{
			aimbotConfig_0.aimKey = KeyCode.E;
		}
	}

	public void MenuDrawing(ref bool bool_1)
	{
		IMGUI._Begin("自动瞄准", ref bool_1, 800, 800);
		IMGUI._Checkbox("启动标准自瞄", ref aimbotConfig_0.enable);
		IMGUI._SameLine();
		IMGUI._Checkbox("是否瞄准队友", ref aimbotConfig_0.aimTeam);
		IMGUI._TextColored(new ImVec4(0f, 1f, 0f, 1f), "瞄准方式:");
		IMGUI._RadioButton("鼠标API自瞄", ref aimbotConfig_0.aimType, 1);
		IMGUI._SameLine();
		IMGUI._RadioButton("内部摄像机自瞄", ref aimbotConfig_0.aimType, 2);
		IMGUI._TextColored(new ImVec4(0f, 1f, 0f, 1f), "瞄准位置:");
		IMGUI._RadioButton("头部", ref int_1, 1);
		IMGUI._SameLine();
		IMGUI._RadioButton("脖子", ref int_1, 2);
		IMGUI._SameLine();
		IMGUI._RadioButton("上脊柱", ref int_1, 3);
		IMGUI._SameLine();
		IMGUI._RadioButton("下脊柱", ref int_1, 4);
		UpdateConfigAimpos();
		IMGUI._TextColored(new ImVec4(0f, 1f, 0f, 1f), "自瞄按键:");
		IMGUI._RadioButton("E键", ref _tempAimkey, 1);
		IMGUI._SameLine();
		IMGUI._RadioButton("左Ctrl键", ref _tempAimkey, 2);
		IMGUI._SameLine();
		IMGUI._RadioButton("鼠标左键", ref _tempAimkey, 3);
		IMGUI._SameLine();
		IMGUI._RadioButton("鼠标右键", ref _tempAimkey, 4);
		UpdateConfigAimkey();
		IMGUI._TextColored(new ImVec4(0f, 1f, 0f, 1f), "自瞄范围:");
		IMGUI._SliderInt("自瞄范围", ref aimbotConfig_0.aimRange, 10, Math.Min(Screen.height / 2, Screen.width / 2), "半径: %.0f");
		IMGUI._TextColored(new ImVec4(0f, 1f, 0f, 1f), "自瞄速度:");
		if (aimbotConfig_0.aimType == 1)
		{
			string text = "自瞄平滑度";
			float num = 0.1f;
			float num2 = 15f;
			IMGUI._SliderFloat(text, ref aimbotConfig_0.smooth, num, num2, "平滑度: %.2f");
		}
		if (aimbotConfig_0.aimType == 2)
		{
			string text2 = "摄像机自瞄最大角度";
			float num4 = 0.1f;
			float num5 = 100f;
			IMGUI._SliderFloat(text2, ref aimbotConfig_0.maxMoveAngle, num4, num5, "最大角度: %.2f");
		}
		IMGUI._Checkbox("无后坐力(瞄准时)", ref aimbotConfig_0.noRecoil);
		IMGUI._TextColored(new ImVec4(0f, 1f, 0f, 1f), "暴力自瞄:");
		IMGUI._Checkbox("启动子弹追踪", ref aimbotConfig_0.silentAim);
		IMGUI._SameLine();
		IMGUI._Checkbox("手动开枪(按中键开枪)[P]", ref aimbotConfig_0.onKeyAim);
		IMGUI._Checkbox("完美静默(网络通畅时使用)", ref aimbotConfig_0.pSilent);
		IMGUI._SameLine();
		IMGUI._Checkbox("全身扫描(卡顿)[鼠标上侧键-按住临时切换]", ref aimbotConfig_0.hitScan);
		if (!aimbotConfig_0.hitScan)
		{
			IMGUI._Checkbox("仅攻击身体", ref aimbotConfig_0.bodyAim);
		}
		IMGUI._End();
	}

	Camera mainCam;

	public AimbotConfig aimbotConfig_0;

	readonly Main _main;

	int int_0;

	bool bool_0;

	PlayerEntity playerEntity_0;

	PlayerEntity playerEntity_1;

	int int_1;

	int _tempAimkey;
}
