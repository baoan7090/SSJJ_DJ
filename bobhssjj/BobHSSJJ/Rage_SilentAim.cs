using System;
using System.Collections.Generic;
using Assets.Sources.Modules.Player.HitBox;
using Assets.Sources.Utils.Weapon;
using Entitas;
using share;
using SSJJBase.String;
using SSJJMath;
using SSJJPhysics;
using UnityEngine;

internal static class Rage_SilentAim
{
	public static void smethod_0(Vector3 vector3_2, Vector3 vector3_3)
	{
		Vector3[] array = new Vector3[]
		{
			new Vector3(vector3_2.x, vector3_2.y, vector3_2.z),
			new Vector3(vector3_3.x, vector3_2.y, vector3_2.z),
			new Vector3(vector3_3.x, vector3_3.y, vector3_2.z),
			new Vector3(vector3_2.x, vector3_3.y, vector3_2.z),
			new Vector3(vector3_2.x, vector3_2.y, vector3_3.z),
			new Vector3(vector3_3.x, vector3_2.y, vector3_3.z),
			new Vector3(vector3_3.x, vector3_3.y, vector3_3.z),
			new Vector3(vector3_2.x, vector3_3.y, vector3_3.z)
		};
		Vector3[] array2 = new Vector3[8];
		for (int i = 0; i < 8; i++)
		{
			VectorCoordConverter.SsjjToUnity(array[i], out array2[i]);
		}
		Color red = Color.red;
		Debug.DrawLine(array2[0], array2[4], red);
		Debug.DrawLine(array2[1], array2[5], red);
		Debug.DrawLine(array2[2], array2[6], red);
		Debug.DrawLine(array2[3], array2[7], red);
		Debug.DrawLine(array2[0], array2[1], red);
		Debug.DrawLine(array2[4], array2[5], red);
		Debug.DrawLine(array2[3], array2[2], red);
		Debug.DrawLine(array2[6], array2[7], red);
		Debug.DrawLine(array2[0], array2[3], red);
		Debug.DrawLine(array2[1], array2[2], red);
		Debug.DrawLine(array2[4], array2[7], red);
		Debug.DrawLine(array2[5], array2[6], red);
	}

	public static Vector3 smethod_1(Vector3 vector3_2, Vector3 vector3_3)
	{
		Vector3 normalized = (vector3_3 - vector3_2).normalized;
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

	public static float smethod_2(float float_0, float float_1, float float_2)
	{
		float num;
		if (float_0 > float_1)
		{
			if (float_0 < float_2)
			{
				num = float_0;
			}
			else
			{
				num = float_2;
			}
		}
		else
		{
			num = float_1;
		}
		return num;
	}

	public static Vector3 smethod_3(Vector3 vector3_2)
	{
		vector3_2.x = smethod_2(vector3_2.x, -89f, 89f);
		vector3_2.y = smethod_2(vector3_2.y, -180f, 180f);
		vector3_2.z = 0f;
		Vector3 vector = vector3_2;
		return vector;
	}

	public static Vector3 smethod_4(Vector3 vector3_2)
	{
		if (vector3_2.x > 89f)
		{
			vector3_2.x -= 180f;
		}
		float x = vector3_2.x;
		if (x < -89f)
		{
			vector3_2.x += 180f;
		}
		vector3_2.y %= 360f;
		if (vector3_2.y > 180f)
		{
			vector3_2.y -= 360f;
		}
		Vector3 vector = vector3_2;
		return vector;
	}

	static bool canAim(PlayerEntity playerEntity_0, PlayerEntity playerEntity_1, Vector3 vector3_2, Vector3 vector3_3)
	{
		Vector3 vector = Misc_Pos_Movement_Godstate.smethod_2((vector3_3 - vector3_2).normalized);
		TraceResult traceResult = FireUtility.BulletTrace(Contexts.sharedInstance.battleRoom.pyEngine.PyEngine, playerEntity_0, Contexts.sharedInstance.player, 100000f, new Vector3D((double)vector.x, (double)vector.y, (double)vector.z), new float[3], new float[3], false);
		bool flag = traceResult.EntityId == playerEntity_1.GetId();
		return flag;
	}

	public static Vector3 FixPos(PlayerEntity playerEntity_0, PlayerEntity playerEntity_1, Vector3 vector3_2, Vector3 vector3_3)
	{
		Vector3 vector = smethod_1(vector3_2 + Misc_Pos_Movement_Godstate.smethod_0(playerEntity_0.move.Velocity) * ((float)Contexts.sharedInstance.userCommand.commands.CommandToSendList.Last.Value.FrameInterval * 0.001f), vector3_3 + Misc_Pos_Movement_Godstate.smethod_0(playerEntity_1.move.Velocity) * ((float)Contexts.sharedInstance.userCommand.commands.CommandToSendList.Last.Value.FrameInterval * 0.001f));
		vector = smethod_4(vector);
		smethod_3(vector);
		Rage_Norecoil.noRecoil(playerEntity_0, ref vector);
		vector = smethod_4(vector);
		smethod_3(vector);
		Vector3 vector2 = vector;
		return vector2;
	}

	public static int boneHash(string string_1)
	{
		return new IgnoreCaseString(string_1).GetHashCode();
	}

	public static void initbone()
	{
		foreach (string text in string_0)
		{
			list_0.Add(boneHash(text));
		}
	}

	public static bool SilentAimbot(List<IEntity> list_1, PlayerEntity playerEntity_0, ref float float_0, ref float float_1, int int_1)
	{
		bool flag5;
		if (Main.instance._rage_aimbot.aimbotConfig_0.silentAim)
		{
			int num = 0;
            float num2 = 1E+09f;
			Transform transform = null;
			PlayerEntity playerEntity = null;
			Vector2 vector = new Vector2((float)Screen.width / 2f, (float)Screen.height / 2f);
			Vector3 vector2 = default(Vector3);
			vector2.x = playerEntity_0.GetCompenstatePos(playerEntity_0.fpos.Change.GetPosIndex()).x;
			vector2.y = playerEntity_0.GetCompenstatePos(playerEntity_0.fpos.Change.GetPosIndex()).y;
			vector2.z = playerEntity_0.GetCompenstatePos(playerEntity_0.fpos.Change.GetPosIndex()).z + (float)playerEntity_0.move.PyPlayerMove.GetViewHeight();
			vector2 = Misc_Pos_Movement_Godstate.smethod_1(vector2);
			List<IEntity>.Enumerator enumerator = list_1.GetEnumerator();
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
                        PlayerEntity playerEntity2 = (PlayerEntity)entity;
                        if (!playerEntity2.IsMySelf())
                        {
                            if (playerEntity2.hasHitBox)
                            {
                                if (playerEntity2.hasThirdPersonUnityObjects)
                                {
                                    if (playerEntity2.GetTeam() != playerEntity_0.GetTeam())
                                    {
                                        double hpPercent = playerEntity2.GetHpPercent();
                                        if (hpPercent >= 0.0)
                                        {
                                            if (!playerEntity2.IsDead())
                                            {
                                                if (!Misc_Pos_Movement_Godstate.GodState(playerEntity2))
                                                {
                                                    if (playerEntity2.hitBox.HitBoxBrushDirty)
                                                    {
                                                        PlayerHitBoxBrushUtility.UpdatePlayerAllHitBoxBrush(playerEntity2);
                                                    }
                                                    List<int>.Enumerator enumerator2 = list_0.GetEnumerator();
                                                    try
                                                    {
                                                        Transform transform2;
                                                        for (; ; )
                                                        {
                                                            if (!enumerator2.MoveNext())
                                                            {
                                                                break;
                                                            }
                                                            int num3 = enumerator2.Current;
                                                            int num4 = num3;
                                                            bool flag;
                                                            if (Main.instance._rage_aimbot.aimbotConfig_0.bodyAim)
                                                            {
                                                                flag = !Input.GetKey((KeyCode)327);
                                                            }
                                                            else
                                                            {
                                                                flag = false;
                                                            }
                                                            if (flag)
                                                            {
                                                                num4 = list_0[6];
                                                            }
                                                            if (playerEntity2.hitBox.BonetTransform.TryGetValue(num4, out transform2))
                                                            {
                                                                if (Camera.main != null)
                                                                {
                                                                    Vector3 vector3 = Camera.main.WorldToScreenPoint(transform2.position);
                                                                    Vector2 vector4 = new Vector2(vector3.x, (float)Screen.height - vector3.y);
                                                                    bool flag2;
                                                                    if ((vector - vector4).magnitude < num2)
                                                                    {
                                                                        flag2 = vector3.z > 0.01f;
                                                                    }
                                                                    else
                                                                    {
                                                                        flag2 = false;
                                                                    }
                                                                    if (flag2)
                                                                    {
                                                                        num2 = (vector - vector4).magnitude;
                                                                        transform = transform2;
                                                                        playerEntity = playerEntity2;
                                                                        num = playerEntity2.GetId();
                                                                    }
                                                                }
                                                                bool flag3;
                                                                if (canAim(playerEntity_0, playerEntity2, vector2, transform2.position))
                                                                {
                                                                    if (Main.instance._rage_aimbot.aimbotConfig_0.onKeyAim)
                                                                    {
                                                                        if (Main.instance._rage_aimbot.aimbotConfig_0.onKeyAim)
                                                                        {
                                                                            flag3 = Input.GetKey((KeyCode)325);
                                                                        }
                                                                        else
                                                                        {
                                                                            flag3 = false;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        flag3 = true;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    flag3 = false;
                                                                }
                                                                if (flag3)
                                                                {
                                                                    goto IL_8D0;
                                                                }
                                                                bool flag4;
                                                                if (!bool_0)
                                                                {
                                                                    flag4 = !Input.GetKey((KeyCode)0);
                                                                }
                                                                else
                                                                {
                                                                    flag4 = false;
                                                                }
                                                                if (flag4)
                                                                {
                                                                    break;
                                                                }
                                                            }
                                                            else
                                                            {
                                                            }
                                                        }
                                                        goto IL_93D;
                                                    IL_8D0:
                                                        Vector3 vector5 = FixPos(playerEntity_0, playerEntity2, vector2, transform2.position);
                                                        float_0 = vector5.y;
                                                        float_1 = vector5.x;
                                                        flag5 = true;
                                                        goto IL_C13;
                                                    IL_93D:
                                                        ;
                                                    }
                                                    finally
                                                    {
                                                        ((IDisposable)enumerator2).Dispose();
                                                    }
                                                }
                                            }
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
			int_0 = num;
			bool flag6;
			if (Main.instance._misc.miscConfig_0.antiAimEnabled && Input.GetKey((KeyCode)0))
			{
				flag6 = playerEntity != null;
			}
			else
			{
				flag6 = false;
			}
			if (flag6)
			{
				Vector3 vector6 = FixPos(playerEntity_0, playerEntity, vector2, transform.position);
				float_0 = vector6.y;
				float_1 = vector6.x;
				flag5 = true;
			}
			else
			{
				flag5 = false;
			}
		}
		else
		{
			flag5 = false;
		}
    IL_C13:;
		return flag5;
	}

	// Note: this type is marked as 'beforefieldinit'.
	static Rage_SilentAim()
	{
		vector3_0 = Vector3.zero;
		vector3_1 = Vector3.zero;
		list_0 = new List<int>();
		string[] array = new string[9];
		array[0] = "Bip01_Head";
		array[1] = "Bip01_Neck";
		array[2] = "Bip01_R_Forearm";
		array[3] = "Bip01_L_Forearm";
		array[4] = "Bip01_R_Hand";
		array[5] = "Bip01_L_Hand";
		array[6] = "Bip01_Pelvis";
		array[7] = "Bip01_R_Calf";
		array[8] = "Bip01_L_Calf";
		string_0 = array;
		bool_0 = false;
		int_0 = 0;
	}

	public static Vector3 vector3_0;

	public static Vector3 vector3_1;

	public static List<int> list_0;

	public static string[] string_0;

	public static bool bool_0;

	public static int int_0;
}
