using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Veh;
using Veh.Hs;

internal static class Rage_Norecoil
{
	public static void noRecoil(PlayerEntity myPlayer, ref Vector3 vector3_0)
	{
		if (myPlayer != null)
		{
			float punchPitch = myPlayer.GetPunchPitch();
			float punchYaw = myPlayer.GetPunchYaw();
			vector3_0.x -= 2 * punchPitch;
			float y = vector3_0.y;
			vector3_0.y = y - 2 * punchYaw;
			_tempPunchpitch = punchPitch;
			_tempPunchyaw = punchYaw;
		}
		else
		{
		}
	}

	public static void nothing()
	{
	}

	public static void MenuDrawing(ref bool bool_0)
	{
		IMGUI._Begin("智能压枪", ref bool_0, 500, 100);
		IMGUI._TextColored(new ImVec4(1f, 1f, 0f, 1f), "请注意,就算是智能压枪,依然会有抖动");
		IMGUI._Checkbox("启用", ref noRecoilConfig_0.enable);
		IMGUI._End();
	}

	public static void Update(ref List<IEntity> playerEntityList, ref PlayerEntity myentity)
	{
		if (!noRecoilConfig_0.enable)
		{
		}
	}

	static float _tempPunchpitch;

	static float _tempPunchyaw;

	internal static NoRecoilConfig noRecoilConfig_0;
}
