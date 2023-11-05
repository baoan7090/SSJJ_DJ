using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Utils.Player;
using data;
using physics;
using SSJJUserCmd;
using UnityEngine;

internal static class Misc_Weapon
{
	public static float WeaponSpread(UserCmd userCmd_0)
	{
		bool flag;
		if (Contexts.sharedInstance.weapon != null && Contexts.sharedInstance.battleRoom != null && Contexts.sharedInstance.weapon.currentWeaponEntity != null)
		{
			flag = Contexts.sharedInstance.player == null;
		}
		else
		{
			flag = true;
		}
		float num;
		if (flag)
		{
			num = 0f;
		}
		else
		{
			IEntitsWeaponInfo info = Contexts.sharedInstance.weapon.currentWeaponEntity.basicInfo.Info;
			IPyEngine pyEngine = Contexts.sharedInstance.battleRoom.pyEngine.PyEngine;
			PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
			WeaponEntity currentWeaponEntity = Contexts.sharedInstance.weapon.currentWeaponEntity;
			SceneMoveData sceneMoveData = pyEngine.GetWorld().GetSceneMoveData() as SceneMoveData;
			bool flag2;
			if (sceneMoveData != null)
			{
				flag2 = sceneMoveData.isWeightlessness;
			}
			else
			{
				flag2 = false;
			}
			bool flag3 = flag2;
			bool flag4;
			if (!userCmd_0.PredicatedOnce && info.AccuracyLogic != null)
			{
				flag4 = info.SpreadLogic != null;
			}
			else
			{
				flag4 = false;
			}
			if (flag4)
			{
				info.SpreadLogic.BeforeFire(out currentWeaponEntity.spread.Spread, myPlayerEntity, currentWeaponEntity, userCmd_0, flag3);
				info.AccuracyLogic.BeforeFire(userCmd_0.Seq, myPlayerEntity, currentWeaponEntity, myPlayerEntity.clientTime.ClientTime);
			}
			float num2 = 0f;
			int weaponType = info.WeaponType;
			int num3 = weaponType;
			float num6;
			switch (num3)
			{
			case 0:
			{
				float num4 = currentWeaponEntity.accuracy.Accuracy * 100f;
				num6 = num4 / 92f;
				goto IL_579;
			}
			case 1:
			case 6:
				goto IL_4DD;
			case 2:
			case 3:
			case 4:
				break;
			case 5:
			{
				if (myPlayerEntity.fov.IsZoom())
				{
					num6 = 1f;
				}
				else
				{
					num6 = 0f;
				}
				float num7 = PlayerUtility.PlayerLength2D(myPlayerEntity);
				num2 = 0f;
				if (num7 <= 350f)
				{
					float num8 = num7;
					if (num8 > 25f)
					{
						num2 = 0.7f;
					}
				}
				else
				{
					num2 = 0.4f;
				}
				goto IL_579;
			}
			default:
			{
				int num10 = num3;
				switch (num10 - 10)
				{
				case 0:
				case 2:
				{
					float num12 = 1f;
					float num13 = (currentWeaponEntity.accuracy.Accuracy - info.AccuracyOffset) * 100f;
					float num14 = info.MaxInaccuracy - info.AccuracyOffset;
					num6 = num12 - num13 / (num14 * 100f);
					num2 = currentWeaponEntity.spread.Spread;
					goto IL_579;
				}
				case 4:
					goto IL_4DD;
				}
				break;
			}
			}
			num6 = 0f;
			num2 = currentWeaponEntity.spread.Spread;
			goto IL_579;
			IL_4DD:
			float num16 = 1f;
			float num17 = (currentWeaponEntity.accuracy.Accuracy - info.DefaultAccuracy) * 100f;
			float num18 = info.MaxInaccuracy - info.DefaultAccuracy;
			num6 = num16 - num17 / (num18 * 100f);
			num2 = currentWeaponEntity.spread.Spread;
			IL_579:
			float num20 = num6 - num2;
			num20 = Mathf.Clamp(num20, 0f, 1f);
			num = num20;
		}
		return num;
	}
}
