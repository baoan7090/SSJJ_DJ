using System;
using UnityEngine;

namespace Veh.Hs
{
	public struct AimbotConfig
	{
		public bool enable;

		public string aimPos;

		public int aimType;

		public KeyCode aimKey;

		public int aimRange;

		public float smooth;

		public bool aimTeam;

		public float maxMoveAngle;

		public bool onKeyAim;

		public bool bodyAim;

		public bool hitScan;

		public bool silentAim;

		public bool pSilent;

		public bool noRecoil;
	}
}
