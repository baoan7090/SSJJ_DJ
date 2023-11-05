using System;
using share.constant;
using UnityEngine;

internal class Misc_Pos_Movement_Godstate
{
	public static Vector3 smethod_0(Vector3 vector3_0)
	{
		return new Vector3(-vector3_0.y, vector3_0.z, vector3_0.x);
	}

	public static Vector3 smethod_1(Vector3 vector3_0)
	{
		return new Vector3(-vector3_0.y, vector3_0.z, vector3_0.x);
	}

	public static Vector3 smethod_2(Vector3 vector3_0)
	{
		return new Vector3(vector3_0.z, -vector3_0.x, vector3_0.y);
	}

	public static Vector3 GetEntityPos(PlayerEntity playerEntity_0)
	{
		return smethod_1(new Vector3((float)playerEntity_0.GetX(), (float)playerEntity_0.GetY(), (float)playerEntity_0.GetZ()));
	}

	internal static bool GodState(PlayerEntity playerEntity_0)
	{
		bool flag;
		if (!(playerEntity_0.basicInfo.CareerInfo.Name == "bossjy6001" && !playerEntity_0.HasStatus(PlayerInfoStatusConstant.HERO_COLD_DEATH_SKILL.ID)))
		{
			if (!playerEntity_0.HasState(1))
			{
				flag = playerEntity_0.GetPlayerInfo().InFrantic;
			}
			else
			{
				flag = true;
			}
		}
		else
		{
			flag = false;
		}
		bool flag2 = flag;
		return flag2;
	}

	internal static void FixMovement(float float_0, float float_1, float float_2, ref float float_3, ref float float_4)
	{
		float num;
		if (float_2 >= 0f)
		{
			num = 0f;
		}
		else
		{
			num = 360f;
		}
		float num3 = float_2 + num;
		float num4;
		if (float_1 >= 0f)
		{
			num4 = 0f;
		}
		else
		{
			num4 = 360f;
		}
		float num6 = float_1 + num4;
		float num8;
		if (num6 >= num3)
		{
			num8 = 360f - Math.Abs(num6 - num3);
		}
		else
		{
			num8 = Math.Abs(num6 - num3);
		}
		float num9 = num8;
		num9 = 360f - num9;
		float num10 = float_3;
		float num11 = float_4;
		float_3 = Mathf.Cos(0.01745329f * num9) * num10 + Mathf.Cos(0.01745329f * (num9 + 90f)) * num11;
		float_4 = Mathf.Sin(0.01745329f * num9) * num10 + Mathf.Sin(0.01745329f * (num9 + 90f)) * num11;
		float_3 = Mathf.Clamp(float_3, -100f, 100f);
		float_4 = Mathf.Clamp(float_4, -100f, 100f);
	}
}
