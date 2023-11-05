using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using UnityEngine;

namespace Veh
{
	public class Loader
	{
		private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
		{
			Assembly assembly;
			try
			{
				string text = "BobHSSJJ." + new AssemblyName(args.Name).Name + ".dll";
				Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(text);
				try
				{
					byte[] array = new byte[manifestResourceStream.Length];
					manifestResourceStream.Read(array, 0, array.Length);
					assembly = Assembly.Load(array);
				}
				finally
				{
					if (manifestResourceStream != null)
					{
						((IDisposable)manifestResourceStream).Dispose();
					}
				}
			}
			catch (ReflectionTypeLoadException ex)
			{
				ReflectionTypeLoadException ex2 = ex;
				Exception[] loaderExceptions = ex2.LoaderExceptions;
				int num = 0;
				for (;;)
				{
					if (num >= loaderExceptions.Length)
					{
						break;
					}
					Exception ex3 = loaderExceptions[num];
					MessageBox.Show("Error occurred(ReflectionTypeLoadException):" + ex3.Message);
					Environment.Exit(0);
					num++;
				}
				assembly = null;
			}
			catch (Exception ex4)
			{
				Exception ex5 = ex4;
				MessageBox.Show("An error occurred while loading assembly(GENERAL EXCEPTION):" + ex5.Message);
				Environment.Exit(0);
				assembly = null;
			}
			return assembly;
		}

        public static void newload()
        {
            Assembly.Load(Properties.Resources.Mono_Cecil);
            Assembly.Load(Properties.Resources.MonoMod_Utils);
            Assembly.Load(Properties.Resources.MonoMod_RuntimeDetour);
            Assembly.Load(Properties.Resources.Newtonsoft_Json);

            new Thread(Load) { IsBackground = true }.Start();
        }
        public static void Load()
        {

            //Class14.smethod_3();
            //RuntimeFieldHandle fieldhandle = typeof(Class39).GetField("struct23_0", BindingFlags.GetField | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public).FieldHandle;
			//RuntimeHelpers.InitializeArray(new byte[31], fieldhandle);
            /*
			AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
			Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("BobHSSJJ.CSImguiDll.dll");
			long length = manifestResourceStream.Length;
			byte[] array = new byte[manifestResourceStream.Length];
			manifestResourceStream.Read(array, 0, (int)manifestResourceStream.Length);
			manifestResourceStream.Close();
			FileInfo fileInfo = new FileInfo("C:\\1\\UI.dll");
			DirectoryInfo directory = fileInfo.Directory;
			//Class14.smethod_6();
			//Class14.smethod_5();
			if (!directory.Exists)
			{
				directory.Create();
			}
			if (!fileInfo.Exists)
			{
				try
				{
					FileStream fileStream = new FileStream("C:\\1\\UI.dll", FileMode.Create);
					fileStream.Write(array, 0, (int)length);
					fileStream.Close();
				}
				catch (Exception)
				{
				}
			}
			else
			{
				File.Delete("C:\\1\\UI.dll");
				try
				{
					FileStream fileStream2 = new FileStream("C:\\1\\UI.dll", FileMode.Create);
					fileStream2.Write(array, 0, (int)length);
					fileStream2.Close();
				}
				catch (Exception ex2)
				{
					//Debug.LogError(string.Format("NMSL {0}", ex2));
				}
			}
            */
			try
			{
                if (!File.Exists("C:\\UI.dll"))
                {
                    File.WriteAllBytes("C:\\UI.dll", Properties.Resources.BobHSSJJ_CSImguiDll);
                }
                GlobalHooker.Update();

                cheat_object = new GameObject();
                cheat_object.AddComponent<Main>();
                UnityEngine.Object.DontDestroyOnLoad(cheat_object);
            }
			catch (Exception ex4)
			{
                File.WriteAllText(@"D:\c\log.log", ex4.ToString());
				////Debug.LogError(string.Format("PatchFail {0}", ex4));
			}
		}

		public static void Unload()
		{
			GlobalHooker.smethod_0();
			UnityEngine.Object.Destroy(cheat_object);
			//Verify.smethod_2();
		}

		private static GameObject cheat_object;
	}
}
