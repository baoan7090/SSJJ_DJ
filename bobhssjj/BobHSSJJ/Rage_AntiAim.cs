using System;
using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;
using UnityEngine;

internal static class Rage_AntiAim
{
	public static void setPitch(Misc.pitchType pitchType, ref float pitch)
	{
		switch (pitchType)
		{
		    case Misc.pitchType.FakeUp:
			    pitch = -271f;
			    break;
		    case Misc.pitchType.FakeDown:
			    pitch = 271f;
			    break;
		    case Misc.pitchType.Up:
			    pitch = 89f;
			    break;
		    case Misc.pitchType.Down:
			    pitch = -89f;
			    break;
		    case Misc.pitchType.Zero:
			    pitch = 0f;
			    break;
		    default:
			    break;
		}
	}

	public static void KeySetPitch(ref float pitch)
	{
		if (Input.GetKeyDown(KeyCode.Keypad7))
		{
			Main.instance._misc.miscConfig_0.antiAimTypeX = 0;
			//Debug.Log(string.Format("FakeUp Pitch: {0}", pitch));
		}
		if (Input.GetKeyDown(KeyCode.Keypad9))
		{
			Main.instance._misc.miscConfig_0.antiAimTypeX = 1;
			//Debug.Log(string.Format("FakeDown Pitch: {0}", pitch));
		}
		if (Input.GetKeyDown(KeyCode.Keypad2))
		{
			Main.instance._misc.miscConfig_0.antiAimTypeX = 3;
			//Debug.Log(string.Format("Pitch: {0}", pitch));
		}
		if (Input.GetKeyDown(KeyCode.Keypad5))
		{
			Main.instance._misc.miscConfig_0.antiAimTypeX = 4;
			//Debug.Log(string.Format("Pitch: {0}", pitch));
		}
		if (Input.GetKeyDown(KeyCode.Keypad8))
		{
			Main.instance._misc.miscConfig_0.antiAimTypeX = 2;
			//Debug.Log(string.Format("Pitch: {0}", pitch));
		}
		if (Input.GetKeyDown(KeyCode.Z))
		{
            Main.instance._misc.miscConfig_0.antiAimTypeYAngle = -90f;
            //Debug.Log(string.Format("Yaw: {0}", Main.instance._misc.miscConfig_0.antiAimTypeYAngle));
		}
		if (Input.GetKeyDown(KeyCode.X))
		{
			Main.instance._misc.miscConfig_0.antiAimTypeYAngle = -180f;
			//Debug.Log(string.Format("Yaw: {0}", Main.instance._misc.miscConfig_0.antiAimTypeYAngle));
		}
		if (Input.GetKeyDown(KeyCode.C))
		{
			Main.instance._misc.miscConfig_0.antiAimTypeYAngle = 90f;
			//Debug.Log(string.Format("Yaw: {0}", Main.instance._misc.miscConfig_0.antiAimTypeYAngle));
		}
		if (Input.GetKeyDown(KeyCode.Home))
		{
			Main.instance._misc.miscConfig_0.antiAimEnabled = !Main.instance._misc.miscConfig_0.antiAimEnabled;
			//Debug.Log(string.Format("AntiAim: {0}", Main.instance._misc.miscConfig_0.antiAimEnabled));
		}
	}

	public static void ExecuteAntiAim(ref float pitch, UserCmd userCmd, ref float _pitch, ref float _yaw, ref float _moveforward, ref float _moveright, ref int _buttons, ref bool _silenting)
	{
		PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		WeaponEntity currentWeaponEntity = Contexts.sharedInstance.weapon.currentWeaponEntity;
		float YawAngle = 0f;
		if (Main.instance._misc.miscConfig_0.antiAimTypeY == 2)
		{
			YawAngle = UnityEngine.Random.Range(Main.instance._misc.miscConfig_0.antiAimTypeYJitterMin, Main.instance._misc.miscConfig_0.antiAimTypeYJitterMax);
		}
		float CamYaw = userCmd.CameraYaw / 100f;
		float FixedYaw = (180f + CamYaw - Main.instance._misc.miscConfig_0.antiAimTypeYAngle + YawAngle) % 360f - 180f;
		float CamPitch;
		if (pitch != 0f)
		{
			CamPitch = pitch;
		}
		else
		{
			CamPitch = userCmd.CameraPitch / 100f;
		}
		setPitch((Misc.pitchType)Main.instance._misc.miscConfig_0.antiAimTypeX, ref CamPitch);
		if (Main.instance._misc.miscConfig_0.antiAimTypeY == 1)
		{
			float YawAddValue = (180f + CamYaw + 180f + (userCmd.Seq * Main.instance._misc.miscConfig_0.antiAimTypeYSpinFactor % 360)) % 360f;
			FixedYaw = YawAddValue - 180f;
		}
		float moveforward = userCmd.MoveForward;
		float moveright = userCmd.MoveRight;
		int buttons = userCmd.Buttons;
		bool CanShoot = false;
		float weaponSpread = Misc_Weapon.WeaponSpread(userCmd);
		bool isweaponnotnull;
		if (Contexts.sharedInstance != null && Contexts.sharedInstance.weapon != null)
		{
			isweaponnotnull = Contexts.sharedInstance.weapon.currentWeaponEntity != null;
		}
		else
		{
			isweaponnotnull = false;
		}
		if (isweaponnotnull)
		{
			bool _canshoot;
			if (WeaponUtility.CanAttack(Contexts.sharedInstance.weapon.currentWeaponEntity, Contexts.sharedInstance.player.cameraOwnerEntity.GetClientTime() + userCmd.FrameInterval))
			{
				float num14 = weaponSpread;
				_canshoot = num14 >= (Main.instance._misc.miscConfig_0.accurary / 100f);
			}
			else
			{
				_canshoot = false;
			}
			CanShoot = _canshoot;
		}
		bool silenting = false;
		bool canSilentAim;
		if (CanShoot)
		{
			canSilentAim = Rage_SilentAim.SilentAimbot(Contexts.sharedInstance.player.GetEntities(), Main.instance.myPlayer, ref _yaw, ref _pitch, buttons);
		}
		else
		{
			canSilentAim = false;
		}
		if (canSilentAim)
		{
			if (!userCmd.IsAttackOn)
			{
				userCmd.Buttons |= 64;
				buttons = buttons | 64;
			}
			FixedYaw = _yaw;
            CamPitch = _pitch;
			silenting = true;
		}
		Misc_Pos_Movement_Godstate.FixMovement(CamPitch, FixedYaw, CamYaw, ref moveforward, ref moveright);
		bool legit;
		if (Main.instance.myPlayer != null && !Main.instance.myPlayer.IsDead() && (Main.instance._misc.miscConfig_0.antiAimEnabled || silenting) && (silenting || !CanShoot || (!userCmd.IsAttackOn && !userCmd.IsSecondaryAttackOn)))
		{
			legit = Input.GetKey(KeyCode.E);
		}
		else
		{
			legit = true;
		}
		if (legit)
		{
			FixedYaw = CamYaw;
            CamPitch = userCmd.CameraPitch / 100f;
			moveforward = userCmd.MoveForward;
			moveright = userCmd.MoveRight;
		}
		shareYaw = FixedYaw;
		sharePitch = CamPitch;
		_pitch = CamPitch;
		_yaw = FixedYaw;
		_buttons = buttons;
		_moveforward = moveforward;
		_moveright = moveright;
		_silenting = silenting;
		bool_0 = silenting;
	}

	public static int int_0 = 1;

	public static int int_1 = 2;

	public static int int_2 = 4;

	public static int int_3 = 8;

	public static float float_0 = 0f;

	public static float shareYaw = 0f;

	public static float sharePitch = 0f;

	public static float float_3 = 0f;

	public static bool bool_0 = false;

	public static long long_0 = 0L;

	public static double double_0 = 0.0;
}
