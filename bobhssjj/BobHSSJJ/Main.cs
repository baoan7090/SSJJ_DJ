using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Entitas;
using NetData;
using UnityEngine;

internal class Main : MonoBehaviour
{
	internal Main()
	{
		instance = this;
	}

	public void Start()
	{
		try
		{
			_esp = new Visual_ESP(this);
			_rage_aimbot = new Rage_Aimbot(this);
			class38_0 = new Visual(this);
			_menu_bar = new Menu_Bar(this);
			_misc = new Misc(this);
			_misc_config = new Misc_Config(this);
			struct22_0 = default(Struct22);
			Rage_SilentAim.initbone();
			finishLoad = true;
		}
		catch (Exception ex)
		{
			Log(string.Format("[CMStart]捕获到未处理异常：{0}\r\n异常信息：{1}\r\n异常堆栈：{2}", ex.GetType(), ex.Message, ex.StackTrace));
        }
	}

	internal void Log(string content)
	{
		//UnityEngine.//Debug.Log(DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + "   ---   " + content);
		try
		{
			readerWriterLockSlim_0.EnterWriteLock();
			string text = @"d:\ssjj\" + DateTime.Now.ToString("yyyyMM");
			string text2 = "ssjj_hack_log_" + DateTime.Now.ToString("dd") + ".log";
			text2 = text + @"\" + text2;
            if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			FileStream fileStream;
			if (File.Exists(text2))
			{
				fileStream = new FileStream(text2, FileMode.Append, FileAccess.Write);
			}
			else
			{
				fileStream = new FileStream(text2, FileMode.Create, FileAccess.Write);
			}
			StreamWriter streamWriter = new StreamWriter(fileStream);
			TextWriter textWriter = streamWriter;
			string text3 = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
			textWriter.WriteLine(text3 + "   ---   " + content);
			streamWriter.Close();
			fileStream.Close();
		}
		catch (Exception ex)
		{
		}
		finally
		{
			readerWriterLockSlim_0.ExitWriteLock();
		}
	}

	void UpdatePlayers()
	{
		EntityList = Contexts.sharedInstance.player.GetEntities();
		foreach (PlayerEntity entity in EntityList)
		{
			if (entity.IsMySelf())
			{
				myPlayer = entity;
				break;
			}
		}
	}

	public void Update()
	{
		if (finishLoad)
		{
			try
			{
				UpdatePlayers();
				_menu_bar.CheckMenuKey();
				//class23_0.HeartBeat();
				bool isnull;
				if (EntityList != null)
				{
					isnull = myPlayer == null;
				}
				else
				{
					isnull = true;
				}
				if (isnull)
				{
					return;
				}
				_esp.UpdateCamera();
				_rage_aimbot.Aiming(ref EntityList, ref myPlayer);
				//class38_0.method_4(ref EntityList, ref myPlayer);
				bool _thirdperson;
				if (Input.GetKeyDown(KeyCode.T))
				{
					_thirdperson = myPlayer != null;
				}
				else
				{
					_thirdperson = false;
				}
				if (_thirdperson)
				{
					ThirdPerson = !ThirdPerson;
				}
				if (Input.GetKeyDown(KeyCode.M))
				{
					Rage_SilentAim.bool_0 = !Rage_SilentAim.bool_0;
				}
				if (Input.GetKeyDown(KeyCode.Keypad0))
				{
					_misc.miscConfig_0.fakeLag = !_misc.miscConfig_0.fakeLag;
				}
				if (Input.GetKeyDown(KeyCode.UpArrow))
				{
                    _misc.miscConfig_0.fakeLagChokeFactor = _misc.miscConfig_0.fakeLagChokeFactor + 20;
				}
				if (Input.GetKeyDown(KeyCode.DownArrow))
				{
                    _misc.miscConfig_0.fakeLagChokeFactor = _misc.miscConfig_0.fakeLagChokeFactor - 10;
				}
				if (Input.GetKeyDown(KeyCode.P))
				{
					_rage_aimbot.aimbotConfig_0.onKeyAim = !_rage_aimbot.aimbotConfig_0.onKeyAim;
				}
				if (Input.GetKeyDown(KeyCode.L))
				{
					_rage_aimbot.aimbotConfig_0.bodyAim = !_rage_aimbot.aimbotConfig_0.bodyAim;
				}
				if (Input.GetKeyDown(KeyCode.K))
				{
					//Class25.bool_1 = !Class25.bool_1;
				}
				if (Input.GetKeyDown(KeyCode.KeypadPlus))
				{
					_rage_aimbot.aimbotConfig_0.bodyAim = false;
					_rage_aimbot.aimbotConfig_0.onKeyAim = false;
					_rage_aimbot.aimbotConfig_0.silentAim = true;
					_rage_aimbot.aimbotConfig_0.noRecoil = true;
					class38_0.visualsConfig_0.noVisualRecoil = true;
					_rage_aimbot.aimbotConfig_0.pSilent = true;
					_misc.miscConfig_0.fakeLag = true;
					GlobalHooker.pitch = -271f;
					instance._misc.miscConfig_0.antiAimTypeY = 2;
					instance._misc.miscConfig_0.antiAimEnabled = true;
				}
				if (Input.GetKeyDown(KeyCode.J))
				{
					//Class25.bool_2 = !Class25.bool_2;
				}
				if (Input.GetKey(KeyCode.F4))
				{
					Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(5, new TacticsSoundData
					{
						SoundId = UnityEngine.Random.Range(3, 18)
					});
				}
			}
			catch (Exception ex)
			{
				Log(string.Format("[CMUpdate]捕获到未处理异常：{0}\r\n异常信息：{1}\r\n异常堆栈：{2}", ex.GetType(), ex.Message, ex.StackTrace));
			}
		}
    }

	public void OnGUI()
	{
		if (finishLoad)
		{
            //GUI.color = Color.cyan;
            //GUI.Label(new Rect(50, 50, 100, 50), "Hi, im the cheat");
		}
	}

	public void method_2()
	{
        /*
		Class14.smethod_2();
		Environment.Exit(0);
		Process.GetCurrentProcess().Kill();
		struct22_0.method_2();
		class36_0 = null;
		class23_0 = null;
		class35_0 = null;
		class32_0 = null;
		class38_0 = null;
		class12_0 = null;
		finishLoad = false;
		GC.Collect();
        */
	}

	internal static Main instance = null;

	internal int error_counter = 0;

	static ReaderWriterLockSlim readerWriterLockSlim_0 = new ReaderWriterLockSlim();

	internal List<IEntity> EntityList;

	internal PlayerEntity myPlayer;

	internal Visual_ESP _esp;

	internal Rage_Aimbot _rage_aimbot;

	internal Visual class38_0;

	internal Menu_Bar _menu_bar;

	internal Misc _misc;

	internal Misc_Config _misc_config;

	internal Struct22 struct22_0;

    internal static bool ThirdPerson = true;

	internal bool finishLoad = false;
}
