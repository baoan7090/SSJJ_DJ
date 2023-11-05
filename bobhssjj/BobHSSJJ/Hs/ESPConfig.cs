using System;

namespace Veh.Hs
{
	public struct ESPConfig
	{
		public bool showTeammate;

		public bool showEnemy;

		public bool showName;

		public bool showTranceline;

		public bool showBone;

		public bool showHealth;

		public bool showDistance;

		public ImVec4 teamBoxCol;

		public ImVec4 enemyBoxCol;

		public ImVec4 TracelineCol;

		public float BoxThickness;

		public float TracelineThickness;

		public float BoneThickness;
	}
}
