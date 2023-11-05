using System;

namespace Veh
{
	public struct ImVec2
	{
		public ImVec2(float float_0, float float_1)
		{
			this.x = float_0;
			this.y = float_1;
		}

		public static ImVec2 operator +(ImVec2 a, ImVec2 b)
		{
			return new ImVec2(a.x + b.x, a.y + b.y);
		}

		public static ImVec2 operator -(ImVec2 a, ImVec2 b)
		{
			return new ImVec2(a.x - b.x, a.y - b.y);
		}

		public float x;

		public float y;
	}
}
