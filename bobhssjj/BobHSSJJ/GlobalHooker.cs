using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets.Libs.ForAce;
using Assets.Sources.Components.Camera;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.Camera;
using Assets.Sources.Components.Snapshot;
using Assets.Sources.Components.UserComand;
using Assets.Sources.Config;
using Assets.Sources.Info.Camera.CameraLogic;
using Assets.Sources.Modules.Player.EntityCreate;
using Assets.Sources.Modules.Player.Orientation;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Modules.WorldCamera;
using Assets.Sources.Networking.Server;
using Assets.Sources.Snapshots;
using Assets.Sources.Systems.PacketHandle.Handlers;
using Assets.Sources.Systems.Snapshot;
using Assets.Sources.Systems.UserCommand;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Player;
using config;
using I2.Loc;
using MonoMod.RuntimeDetour;
using NetData;
using physics;
using share;
using SSJJBase.Singleton;
using SSJJBase.Utility;
using SSJJMath;
using SSJJNetworking.Packet;
using SSJJUserCmd;
using UnityEngine;

internal static class GlobalHooker
{
	public static bool Start(Type type, string origFunc, Delegate hookFunc, IDetour detourObj = null)
	{
		bool flag;
		if (list_0 == null)
		{
			flag = false;
		}
		else
		{
			Class27 @class = new Class27();
			if (detourObj == null)
			{
				@class.idetour_0 = new Hook(type.GetMethod(origFunc, bindingFlags_0), hookFunc.Method);
			}
			else
			{
				@class.idetour_0 = detourObj;
			}
			list_0.Add(@class);
			flag = true;
		}
		return flag;
	}

	public static void smethod_0()
	{
		foreach (Class27 @class in list_0)
		{
			if (@class.idetour_0 != null)
			{
				@class.idetour_0.Undo();
			}
		}
	}

	internal static bool smethod_1()
	{
		return list_1.Count() + 1 < Main.instance._misc.miscConfig_0.fakeLagChokeFactor && !bool_0;
	}

	public static void Update()
	{
		Start(typeof(AbstractCaptureSnapshot), "ScreenNow", new Delegate11(hk_ScreenNow), null);
		Start(typeof(ExclusiveCaptureSnapshot), "UpdateScreen", new DoUpdateScreen1Delegate(DoUpdateScreen1), null);
		Start(typeof(WindowCaptureSnapshot), "UpdateScreen", new DoUpdateScreen2Delegate(DoUpdateScreen2), null);
		Start(typeof(WindowHdcCaptureSnapshot), "UpdateScreen", new DoUpdateScreen3Delegate(DoUpdateScreen3), null);
		Start(typeof(CaptureCameraManager), "CaptureCamera", new Delegate10(hk_CaptureCamera), null);
		Start(typeof(PostProcessUserCommandSystem), "InterceptNew", new Delegate12(hk_InterceptNew), null);
		Start(typeof(SendUserCommandSystem), "GetUserCmdBytes", new Delegate25(hk_GetUserCmdBytes), null);
		Start(typeof(BattleServer), "SendUdpData", new Delegate8(hk_SendUdpData), null);
		Start(typeof(ComputeUserCommandSystem), "MakeCommand", new Delegate16(hk_MakeCommand), null);
		Start(typeof(TpsCameraLogic), "IsActive", new Delegate24(hk_IsActive), null);
		Start(typeof(TpsCameraLogic), "Update", new DoTpsCameraLogicUpdateDelegate(DoTpsCameraLogicUpdate), null);
		Start(typeof(CameraFunction), "GetCurrentCmdYaw", new Delegate22(hk_GetCurrentCmdYaw), null);
		Start(typeof(CameraFunction), "GetCurrentCmdPitch", new Delegate23(hk_GetCurrentCmdPitch), null);
		Start(typeof(UiIEventCondition), "Get_ControlEntityData_Yaw", new Delegate21(hk_Get_ControlEntityData_Yaw), null);
		Start(typeof(UiIEventCondition), "Get_cameraOwnerData_Yaw", new Delegate20(hk_Get_cameraOwnerData_Yaw), null);
		Start(typeof(PlayerOrientationPredicationSystem), "OnPredicate", new Delegate18(hk_OnPredicate), null);
		Start(typeof(PlayerOrientationPlabackSystem), "OnPlayback", new Delegate17(hk_OnPlayback), null);
		Start(typeof(PlayerOrientationPredicationSystem), "PredictCmdOnCamera", new Delegate19(hk_PredictCmdOnCamera), null);
		Start(typeof(CommandsComponent), "LastCameraYaw", new Delegate14(hk_LastCameraYaw), null);
		Start(typeof(CommandsComponent), "LastCameraPitch", new Delegate15(hk_LastCameraPitch), null);
		Start(typeof(CameraLogicToTransformSystem), "OnAfterPredication", new Delegate13(hk_OnAfterPredication), null);
		Start(typeof(PlayerSpeedUtil), "GetPlayerSpeed", new Delegate9(hk_GetPlayerSpeed), null);
		Start(typeof(HitPlayerHandler), "Handle", new Delegate7(hk_Handle), null);
		Start(typeof(LocalizationManager), "SelectStartupLanguage", new DoSelectStartupLanguageDelegate(DoSelectStartupLanguage), null);
		Start(typeof(TplManager), "GetBootConfig", new Delegate4(hk_GetBootConfig), null);
	}

	public static GameBootConfig hk_GetBootConfig(Func<TplManager, GameBootConfig> func_0, TplManager tplManager_0)
	{
		GameBootConfig gameBootConfig = func_0(tplManager_0);
		MonoBehaviourSingleton<AceClientManager>.Instance.Close();
		return gameBootConfig;
	}

	public static void smethod_3(Action<AssembleSystem, SnapshotsComponent, ISnapshot> action_0, AssembleSystem assembleSystem_0, SnapshotsComponent snapshotsComponent_0, ISnapshot isnapshot_0)
	{
		action_0(assembleSystem_0, snapshotsComponent_0, isnapshot_0);
	}

	public static PlayerEntity smethod_4(Func<PlayerEntityCreateSystem, int, PlayerEntity> func_0, PlayerEntityCreateSystem playerEntityCreateSystem_0, int int_1)
	{
		Class28.smethod_1(int_1);
		return func_0(playerEntityCreateSystem_0, int_1);
	}

	public static void DoSelectStartupLanguage()
	{
		//Verify.smethod_6();
		//Verify.smethod_5();
		string @string = PlayerPrefs.GetString("I2 Language", string.Empty);
		string text = "ChineseSimplified";
		if (text == "ChineseSimplified")
		{
			text = "Chinese (Simplified)";
		}
		if (text == "ChineseTraditional")
		{
			text = "Chinese (Traditional)";
		}
		if (LocalizationManager.HasLanguage(@string, true, false))
		{
			LocalizationManager.CurrentLanguage = @string;
		}
		else
		{
			string supportedLanguage = LocalizationManager.GetSupportedLanguage(text);
			if (string.IsNullOrEmpty(supportedLanguage))
			{
				int num = 0;
				int count = LocalizationManager.Sources.Count;
				for (;;)
				{
					if (num >= count)
					{
						break;
					}
					if (LocalizationManager.Sources[num].mLanguages.Count > 0)
					{
						goto IL_1BD;
					}
					num++;
				}
				goto IL_22A;
				IL_1BD:
				LocalizationManager.SetLanguageAndCode(LocalizationManager.Sources[num].mLanguages[0].Name, LocalizationManager.Sources[num].mLanguages[0].Code, false, false);
			}
			else
			{
				LocalizationManager.SetLanguageAndCode(supportedLanguage, LocalizationManager.GetLanguageCode(supportedLanguage), false, false);
			}
		}
    IL_22A:
        ;
    }

	public static void hk_Handle(Action<HitPlayerHandler, GameServerSetupData> action_0, HitPlayerHandler hitPlayerHandler_0, GameServerSetupData gameServerSetupData_0)
	{
		action_0(hitPlayerHandler_0, gameServerSetupData_0);
	}

	public static void hk_SendUdpData(Action<BattleServer, int, byte[]> action_0, BattleServer battleServer_0, int int_1, byte[] byte_0 = null)
	{
		bool flag;
		if ((Main.instance._misc.miscConfig_0.fakeLag || Main.instance._rage_aimbot.aimbotConfig_0.pSilent || Main.instance._rage_aimbot.aimbotConfig_0.silentAim) && !Input.GetKey((KeyCode)326) && Main.instance.myPlayer != null && Contexts.sharedInstance.player.cameraOwnerEntity != null)
		{
			flag = Main.instance.myPlayer.IsDead();
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			action_0(battleServer_0, int_1, byte_0);
		}
		else
		{
			UdpPacket udpPacket = UdpPacket.CreateUdpPacket(battleServer_0.ConnectionId, int_1, byte_0);
			list_1.Add(udpPacket);
			bool flag2;
			if (Rage_AntiAim.bool_0 && Main.instance._rage_aimbot.aimbotConfig_0.pSilent)
			{
				flag2 = Main.instance._rage_aimbot.aimbotConfig_0.silentAim;
			}
			else
			{
				flag2 = false;
			}
			if (flag2)
			{
				bool_0 = true;
			}
			else
			{
				bool flag3;
				if (list_1.Count<UdpPacket>() < Main.instance._misc.miscConfig_0.fakeLagChokeFactor && !bool_0)
				{
					float num = PlayerUtility.PlayerLength2D(Contexts.sharedInstance.player.cameraOwnerEntity);
					flag3 = num <= 0.1f;
				}
				else
				{
					flag3 = true;
				}
				if (flag3)
				{
					List<UdpPacket>.Enumerator enumerator = list_1.GetEnumerator();
					try
					{
						for (;;)
						{
							if (!enumerator.MoveNext())
							{
								break;
							}
							UdpPacket udpPacket2 = enumerator.Current;
							battleServer_0.UdpSocket.Send(udpPacket2.FinalData, udpPacket2.FinalLength);
						}
					}
					finally
					{
						((IDisposable)enumerator).Dispose();
					}
					bool_0 = false;
					list_1.Clear();
				}
			}
		}
	}

	public static int hk_GetPlayerSpeed(Func<IPyPlayerMove, IPyUserCmd, int> func_0, IPyPlayerMove ipyPlayerMove_0, IPyUserCmd ipyUserCmd_0)
	{
		return func_0(ipyPlayerMove_0, ipyUserCmd_0);
	}

	public static void DoUpdateScreen3(Action<WindowHdcCaptureSnapshot> orig, WindowHdcCaptureSnapshot self)
	{
	}

	public static void DoUpdateScreen2(Action<WindowCaptureSnapshot> orig, WindowCaptureSnapshot self)
	{
	}

	public static void DoUpdateScreen1(Action<ExclusiveCaptureSnapshot> orig, ExclusiveCaptureSnapshot self)
	{
	}

	public static IEnumerator hk_CaptureCamera(Func<CaptureCameraManager, IEnumerator> func_0, CaptureCameraManager captureCameraManager_0)
	{
		return null;
	}

	public static void hk_ScreenNow(Action<AbstractCaptureSnapshot> action_0, AbstractCaptureSnapshot abstractCaptureSnapshot_0)
	{
	}

	public static void hk_InterceptNew(Action<PostProcessUserCommandSystem, UserCmd> action_0, PostProcessUserCommandSystem postProcessUserCommandSystem_0, UserCmd userCmd_0)
	{
		if (Main.instance.myPlayer == null || Main.instance.myPlayer.IsDead())
		{
			action_0(postProcessUserCommandSystem_0, userCmd_0);
		}
	}

	public static void hk_OnAfterPredication(Action<CameraLogicToTransformSystem> action_0, CameraLogicToTransformSystem cameraLogicToTransformSystem_0)
	{
		WorldCameraContext worldCameraContext = cameraLogicToTransformSystem_0.smethod_6<WorldCameraContext>("_worldCameraContext");
		ICameraLogic cameraLogic = worldCameraContext.cameraLogic.CameraLogic;
		bool flag;
		if (cameraLogic != null)
		{
			flag = Main.instance.myPlayer == null;
		}
		else
		{
			flag = true;
		}
		if (!flag)
		{
			float viewPitch = Main.instance.myPlayer.GetViewPitch();
			float num;
			if (!Main.instance.class38_0.visualsConfig_0.noVisualRecoil)
			{
				num = Main.instance.myPlayer.GetPunchPitch();
			}
			else
			{
				num = 0f;
			}
			float num2 = viewPitch + num;
			float viewYaw = Main.instance.myPlayer.GetViewYaw();
			float num3;
			if (!Main.instance.class38_0.visualsConfig_0.noVisualRecoil)
			{
				num3 = Main.instance.myPlayer.GetPunchYaw();
			}
			else
			{
				num3 = 0f;
			}
			Vector3 vector = new Vector3(num2, viewYaw + num3, 0f);
			worldCameraContext.cameraMode.Mode = cameraLogic.CameraMode();
			worldCameraContext.cameraTransform.Fov = cameraLogic.Fov();
			CameraTransformComponent cameraTransform = worldCameraContext.cameraTransform;
			float num4;
			if (!Main.instance.myPlayer.IsDead())
			{
				num4 = vector.x;
			}
			else
			{
				num4 = cameraLogic.Pitch();
			}
			cameraTransform.Pitch = num4;
			worldCameraContext.cameraTransform.Roll = cameraLogic.Roll();
			CameraTransformComponent cameraTransform2 = worldCameraContext.cameraTransform;
			float num5;
			if (!Main.instance.myPlayer.IsDead())
			{
				num5 = vector.y;
			}
			else
			{
				num5 = cameraLogic.Yaw();
			}
			cameraTransform2.Yaw = num5;
			worldCameraContext.cameraTransform.position = cameraLogic.Position();
		}
		else
		{
		}
	}

	public static short hk_LastCameraYaw(Func<CommandsComponent, short> func_0, CommandsComponent commandsComponent_0)
	{
		bool flag;
		if (Main.instance.myPlayer != null)
		{
			flag = Main.instance.myPlayer.IsDead();
		}
		else
		{
			flag = true;
		}
		short num2;
		if (!flag)
		{
			float yaw = Contexts.sharedInstance.worldCamera.cameraTransform.Yaw;
			num2 = (short)(yaw * 100f);
		}
		else
		{
			num2 = func_0(commandsComponent_0);
		}
		return num2;
	}

	public static short hk_LastCameraPitch(Func<CommandsComponent, short> func_0, CommandsComponent commandsComponent_0)
	{
		bool flag;
		if (Main.instance.myPlayer != null)
		{
			flag = Main.instance.myPlayer.IsDead();
		}
		else
		{
			flag = true;
		}
		short num2;
		if (!flag)
		{
			float pitch = Contexts.sharedInstance.worldCamera.cameraTransform.Pitch;
			num2 = (short)(pitch * 100f);
		}
		else
		{
			num2 = func_0(commandsComponent_0);
		}
		return num2;
	}

	public static void hk_MakeCommand(Action<ComputeUserCommandSystem, UserCmd, PlayerEntity> action_0, ComputeUserCommandSystem computeUserCommandSystem_0, UserCmd userCmd_0, PlayerEntity playerEntity_0)
	{
		action_0(computeUserCommandSystem_0, userCmd_0, playerEntity_0);
		if (Main.instance.myPlayer == null || Main.instance.myPlayer.IsDead())
		{
		}
	}

	public static void hk_OnPlayback(Action<PlayerOrientationPlabackSystem> action_0, PlayerOrientationPlabackSystem playerOrientationPlabackSystem_0)
	{
		action_0(playerOrientationPlabackSystem_0);
		if (Main.instance.myPlayer != null && !Main.instance.myPlayer.IsDead() && Contexts.sharedInstance != null && Contexts.sharedInstance.player != null && Contexts.sharedInstance.player.cameraOwnerEntity != null)
		{
			PlayerEntity cameraOwnerEntity = Contexts.sharedInstance.player.cameraOwnerEntity;
			if (cameraOwnerEntity.orientation != null && cameraOwnerEntity.basicInfo != null && cameraOwnerEntity.punchOrientation != null)
			{
				PlayerEntityData current = cameraOwnerEntity.basicInfo.Current;
				PlayerEntityData next = cameraOwnerEntity.basicInfo.Next;
				cameraOwnerEntity.orientation.Pitch = Rage_AntiAim.sharePitch;
				cameraOwnerEntity.orientation.Yaw = Rage_AntiAim.shareYaw;
				cameraOwnerEntity.punchOrientation.PunchPitch = next.PunchPitch;
				cameraOwnerEntity.punchOrientation.PunchYaw = next.PunchYaw;
				cameraOwnerEntity.orientation.MoveYaw = Rage_AntiAim.shareYaw;
				cameraOwnerEntity.orientation.ActThirdMoveInterYaw = Rage_AntiAim.shareYaw;
			}
		}
	}

	public static void hk_OnPredicate(Action<PlayerOrientationPredicationSystem, PlayerEntity, IUserCmd> action_0, PlayerOrientationPredicationSystem playerOrientationPredicationSystem_0, PlayerEntity playerEntity_0, IUserCmd iuserCmd_0)
	{
		if (Contexts.sharedInstance != null && Contexts.sharedInstance.player != null && Contexts.sharedInstance.player.cameraOwnerEntity != null)
		{
			PlayerEntity cameraOwnerEntity = Contexts.sharedInstance.player.cameraOwnerEntity;
			if (cameraOwnerEntity.orientation != null)
			{
				if (Main.instance.myPlayer != null && !Main.instance.myPlayer.IsDead())
				{
					cameraOwnerEntity.orientation.Pitch = Rage_AntiAim.sharePitch;
					cameraOwnerEntity.orientation.Yaw = Rage_AntiAim.shareYaw;
					action_0(playerOrientationPredicationSystem_0, playerEntity_0, iuserCmd_0);
				}
				else
				{
					action_0(playerOrientationPredicationSystem_0, playerEntity_0, iuserCmd_0);
				}
			}
		}
	}

	public static void hk_PredictCmdOnCamera(Action<PlayerOrientationPredicationSystem, PlayerEntity, IUserCmd> action_0, PlayerOrientationPredicationSystem playerOrientationPredicationSystem_0, PlayerEntity playerEntity_0, IUserCmd iuserCmd_0)
	{
		if (Main.instance.myPlayer == null || Main.instance.myPlayer.IsDead())
		{
			action_0(playerOrientationPredicationSystem_0, playerEntity_0, iuserCmd_0);
		}
	}

	public static float hk_Get_cameraOwnerData_Yaw(Func<float> func_0)
	{
		float num;
		if (Main.instance.myPlayer != null && !Main.instance.myPlayer.IsDead())
		{
			num = Contexts.sharedInstance.worldCamera.cameraTransform.Yaw;
		}
		else
		{
			num = func_0();
		}
		return num;
	}

	public static float hk_Get_ControlEntityData_Yaw(Func<float> func_0)
	{
		float num;
		if (Main.instance.myPlayer != null && !Main.instance.myPlayer.IsDead())
		{
			num = UiIEventCondition.Get_cameraOwnerData_Yaw();
		}
		else
		{
			num = func_0();
		}
		return num;
	}

	public static float hk_GetCurrentCmdYaw(Func<ICameraLogic, float> func_0, ICameraLogic icameraLogic_0)
	{
		float num;
		if (Main.instance.myPlayer != null && !Main.instance.myPlayer.IsDead())
		{
			num = Contexts.sharedInstance.worldCamera.cameraTransform.Yaw;
		}
		else
		{
			num = func_0(icameraLogic_0);
		}
		return num;
	}

	public static float hk_GetCurrentCmdPitch(Func<ICameraLogic, float> func_0, ICameraLogic icameraLogic_0)
	{
		float num;
		if (Main.instance.myPlayer != null && !Main.instance.myPlayer.IsDead())
		{
			num = Contexts.sharedInstance.worldCamera.cameraTransform.Pitch;
		}
		else
		{
			num = func_0(icameraLogic_0);
		}
		return num;
	}

	public static void DoTpsCameraLogicUpdate(Action<TpsCameraLogic> orig, TpsCameraLogic self)
	{
		orig(self);
		bool flag;
		if (Main.instance.myPlayer != null)
		{
			flag = Main.instance.myPlayer.IsDead();
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
		}
		else
		{
			CameraDataComponent cameraData = self.smethod_6<Contexts>("Contexts").worldCamera.cameraData;
			PlayerEntity myPlayerEntity = self.smethod_6<Contexts>("Contexts").player.myPlayerEntity;
			Vector3 vector = self.smethod_6<Vector3>("_viewOrgPosition");
			Vector3 vector2 = default(Vector3);
			if (cameraData.IsTps)
			{
				vector2 = self.GetCalculateCameraEndPos(vector, cameraData.CameraYawAddValue, cameraData.CameraPitchAddValue, self.smethod_6<float>("_distance"), 10f);
				Vector3D vector3D = new Vector3D();
				Vector3D vector3D2 = new Vector3D();
				Vector3D vector3D3 = new Vector3D();
				AngleUtility.AnglesToVectors2(self.smethod_6<float>("_yaw"), self.smethod_6<float>("_pitch"), vector3D, vector3D2, vector3D3);
				vector3D.Normalize();
				vector3D2.Normalize();
				vector3D3.Normalize();
				vector3D2.ScaleBy(50f);
				vector2 = self.GetCalculateCameraEndPos(vector2, cameraData.CameraYawAddValue, 0f, 50f, 10f);
				bool flag2;
				if (myPlayerEntity != null)
				{
					flag2 = myPlayerEntity.fov.Fov != cameraData.Fov;
				}
				else
				{
					flag2 = false;
				}
				if (flag2)
				{
					myPlayerEntity.fov.Fov = cameraData.Fov;
					myPlayerEntity.fov.DelayFov = cameraData.Fov;
				}
			}
			if (cameraData.TransTime != 0)
			{
				self.InterpolateCamareDeadEndPos(vector, vector2, cameraData.TransTime);
			}
		}
	}

	public static bool hk_IsActive(Func<TpsCameraLogic, bool> func_0, TpsCameraLogic tpsCameraLogic_0)
	{
		func_0(tpsCameraLogic_0);
		CameraDataComponent cameraData = Contexts.sharedInstance.worldCamera.cameraData;
		cameraData.Fov = 90;
		cameraData.CameraYawAddValue = tpsCameraLogic_0.smethod_6<float>("_yaw");
		cameraData.CameraPitchAddValue = tpsCameraLogic_0.smethod_6<float>("_pitch") - 5f;
		cameraData.TransTime = Mathf.Max(230, cameraData.TransTime + Contexts.sharedInstance.time.time.FrameInterval);
		cameraData.IsTps = !Main.ThirdPerson;
		bool flag = !Main.ThirdPerson;
		return flag;
	}

	public static void smethod_23(Action<SendUserCommandSystem> action_0, SendUserCommandSystem sendUserCommandSystem_0)
	{
		action_0(sendUserCommandSystem_0);
	}

	public static byte[] hk_GetUserCmdBytes(Delegate26 delegate26_0, SendUserCommandSystem sendUserCommandSystem_0, LinkedList<UserCmd> linkedList_0, SnapshotsComponent snapshotsComponent_0, out int int_1, bool bool_1)
	{
		int_1 = 0;
		bool flag;
		if (Main.instance.myPlayer != null)
		{
			flag = Main.instance.myPlayer.IsDead();
		}
		else
		{
			flag = true;
		}
		byte[] array;
		if (flag)
		{
			array = delegate26_0(sendUserCommandSystem_0, linkedList_0, snapshotsComponent_0, out int_1, bool_1);
		}
		else
		{
			if (linkedList_0.Count != 0)
			{
				UserCmd _Usercmd = linkedList_0.First.Value;
				float _yaw = 0f;
				float _pitch = 0f;
				float _moveforward = 0f;
				float _moveright = 0f;
				int _buttons = 0;
				int seq = _Usercmd.Seq;
				Rage_AntiAim.KeySetPitch(ref pitch);
				bool flag2 = false;
				Main.instance._misc.bhop(Main.instance.myPlayer, ref _Usercmd);
				Rage_AntiAim.ExecuteAntiAim(ref pitch, _Usercmd, ref _pitch, ref _yaw, ref _moveforward, ref _moveright, ref _buttons, ref flag2);
				bool flag3;
				if (SendUserCommandSystem.Record != null)
				{
					flag3 = SendUserCommandSystem.Record.IsSelfMove();
				}
				else
				{
					flag3 = true;
				}
				bool flag4 = flag3;
				LinkedListNode<UserCmd> linkedListNode = linkedList_0.First;
				UserCmd value2 = linkedListNode.Value;
				binaryDataWriter_0.Reset();
				if (bool_1)
				{
					binaryDataWriter_0.WriteByte((byte)31);
				}
				int num6 = snapshotsComponent_0.ReceiveSnapshotLatency;
				int num7 = num6;
				if (num7 > 255)
				{
					num6 = 255;
				}
				binaryDataWriter_0.WriteByte((byte)num6);
				binaryDataWriter_0.WriteInt(value2.Seq);
				binaryDataWriter_0.WriteInt(value2.RenderTime);
				binaryDataWriter_0.WriteInt(snapshotsComponent_0.LatestSnapshotSeqId);
				int num9 = 15 | 32 | 16 | 128;
				binaryDataWriter_0.WriteByte((byte)num9);
				int num10 = value2.FrameInterval;
				binaryDataWriter_0.WriteByte((byte)num10);
				int num11;
				if (flag4)
				{
					num11 = (int)_moveforward;
				}
				else
				{
					num11 = 0;
				}
				int num12 = num11;
				int num13;
				if (flag4)
				{
					num13 = (int)_moveright;
				}
				else
				{
					num13 = 0;
				}
				int num14 = num13;
				binaryDataWriter_0.WriteByte((byte)num12);
				binaryDataWriter_0.WriteByte((byte)num14);
				binaryDataWriter_0.WriteInt(_buttons);
				int num15 = 0 | value2.BagId;
				num15 <<= 4;
				num15 |= value2.Weapon;
				binaryDataWriter_0.WriteByte((byte)num15);
				binaryDataWriter_0.WriteShort((short)(_yaw * 100f));
				BinaryDataWriter binaryDataWriter = binaryDataWriter_0;
				float num16 = _pitch;
				binaryDataWriter.WriteShort((short)(num16 * 100f));
				linkedListNode = linkedListNode.Next;
				for (;;)
				{
					if (linkedListNode == null)
					{
						break;
					}
					UserCmd value3 = linkedListNode.Value;
					Main.instance._misc.bhop(Main.instance.myPlayer, ref value3);
					Rage_AntiAim.ExecuteAntiAim(ref pitch, value3, ref _pitch, ref _yaw, ref _moveforward, ref _moveright, ref _buttons, ref flag2);
					int position = binaryDataWriter_0.Position;
					binaryDataWriter_0.WriteByte(0);
                    num10 = value3.FrameInterval;
					binaryDataWriter_0.WriteByte((byte)num10);
					num12 = (int)_moveforward;
					num14 = (int)_moveright;
					binaryDataWriter_0.WriteByte((byte)num12);
					binaryDataWriter_0.WriteByte((byte)num14);
					binaryDataWriter_0.WriteInt(_buttons);
					num15 = 0 | value3.BagId;
					num15 <<= 4;
					num15 |= value3.Weapon;
					binaryDataWriter_0.WriteByte((byte)num15);
					num9 = 15 | 16;
					binaryDataWriter_0.WriteShort((short)(_yaw * 100f));
					num9 |= 32;
					binaryDataWriter_0.WriteShort((short)(_pitch * 100f));
					int position2 = binaryDataWriter_0.Position;
					binaryDataWriter_0.Position = position;
					binaryDataWriter_0.WriteByte((byte)num9);
					binaryDataWriter_0.Position = position2;
					linkedListNode = linkedListNode.Next;
				}
				byte[] orCreateNormalByte = NetByteFactory.Instance.GetOrCreateNormalByte(binaryDataWriter_0.Length, true);
				binaryDataWriter_0.SetBytes(orCreateNormalByte);
				int_1 = orCreateNormalByte.Length;
				array = orCreateNormalByte;
			}
			else
			{
				array = null;
			}
		}
		return array;
	}

	// Note: this type is marked as 'beforefieldinit'.
	static GlobalHooker()
	{
		list_0 = new List<Class27>();
		bindingFlags_0 = (BindingFlags)60;
		pitch = 0f;
		int_0 = 0;
		bool_0 = false;
		random_0 = new System.Random();
		class29_0 = null;
		list_1 = new List<UdpPacket>();
		binaryDataWriter_0 = new BinaryDataWriter();
	}

	static List<Class27> list_0;

	internal static BindingFlags bindingFlags_0;

	internal static float pitch;

	static int int_0;

	static bool bool_0;

	internal static System.Random random_0;

	internal static Class28.Class29 class29_0;

	internal static List<UdpPacket> list_1;

	static BinaryDataWriter binaryDataWriter_0;

	class Class27
	{
		public IDetour idetour_0 = null;
	}

	public delegate GameBootConfig Delegate4(Func<TplManager, GameBootConfig> orig, TplManager self);

	public delegate void Delegate5(Action<AssembleSystem, SnapshotsComponent, ISnapshot> orig, AssembleSystem self, SnapshotsComponent comp, ISnapshot snapshot);

	public delegate PlayerEntity Delegate6(Func<PlayerEntityCreateSystem, int, PlayerEntity> orig, PlayerEntityCreateSystem self, int entityId);

	public delegate void DoSelectStartupLanguageDelegate();

	public delegate void Delegate7(Action<HitPlayerHandler, GameServerSetupData> orig, HitPlayerHandler self, GameServerSetupData data);

	public delegate void Delegate8(Action<BattleServer, int, byte[]> orig, BattleServer self, int methodId, byte[] data = null);

	public delegate int Delegate9(Func<IPyPlayerMove, IPyUserCmd, int> orig, IPyPlayerMove player, IPyUserCmd cmd);

	public delegate void DoUpdateScreen3Delegate(Action<WindowHdcCaptureSnapshot> orig, WindowHdcCaptureSnapshot self);

	public delegate void DoUpdateScreen2Delegate(Action<WindowCaptureSnapshot> orig, WindowCaptureSnapshot self);

	public delegate void DoUpdateScreen1Delegate(Action<ExclusiveCaptureSnapshot> orig, ExclusiveCaptureSnapshot self);

	public delegate IEnumerator Delegate10(Func<CaptureCameraManager, IEnumerator> orig, CaptureCameraManager self);

	public delegate void Delegate11(Action<AbstractCaptureSnapshot> orig, AbstractCaptureSnapshot self);

	public delegate void Delegate12(Action<PostProcessUserCommandSystem, UserCmd> orig, PostProcessUserCommandSystem self, UserCmd userCmd);

	public delegate void Delegate13(Action<CameraLogicToTransformSystem> orig, CameraLogicToTransformSystem self);

	public delegate short Delegate14(Func<CommandsComponent, short> orig, CommandsComponent self);

	public delegate short Delegate15(Func<CommandsComponent, short> orig, CommandsComponent self);

	public delegate void Delegate16(Action<ComputeUserCommandSystem, UserCmd, PlayerEntity> orig, ComputeUserCommandSystem self, UserCmd cmd, PlayerEntity myPlayer);

	public delegate void Delegate17(Action<PlayerOrientationPlabackSystem> orig, PlayerOrientationPlabackSystem self);

	public delegate void Delegate18(Action<PlayerOrientationPredicationSystem, PlayerEntity, IUserCmd> orig, PlayerOrientationPredicationSystem self, PlayerEntity myPlayer, IUserCmd cmd);

	public delegate void Delegate19(Action<PlayerOrientationPredicationSystem, PlayerEntity, IUserCmd> orig, PlayerOrientationPredicationSystem self, PlayerEntity myPlayer, IUserCmd cmd);

	public delegate float Delegate20(Func<float> orig);

	public delegate float Delegate21(Func<float> orig);

	public delegate float Delegate22(Func<ICameraLogic, float> orig, ICameraLogic cameraLogic);

	public delegate float Delegate23(Func<ICameraLogic, float> orig, ICameraLogic cameraLogic);

	public delegate void DoTpsCameraLogicUpdateDelegate(Action<TpsCameraLogic> orig, TpsCameraLogic self);

	public delegate bool Delegate24(Func<TpsCameraLogic, bool> orig, TpsCameraLogic self);

	public delegate byte[] Delegate25(Delegate26 orig, SendUserCommandSystem self, LinkedList<UserCmd> sendCmdList, SnapshotsComponent snapshots, out int datalen, bool isTcp);

	public delegate byte[] Delegate26(SendUserCommandSystem self, LinkedList<UserCmd> sendCmdList, SnapshotsComponent snapshots, out int datalen, bool isTcp);
}
