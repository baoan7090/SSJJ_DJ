using System;

internal struct Struct24
{
	internal Struct24(uint seed)
	{
		seed = (this.uint_0 = seed * 557916961U);
		seed = (this.uint_1 = seed * 557916961U);
		seed = (this.uint_2 = seed * 557916961U);
		seed = (this.uint_3 = seed * 557916961U);
	}

	internal uint method_0(byte f, uint q)
	{
		if ((f & 128) != 0)
		{
			switch (f & 3)
			{
			case 0:
				this.uint_0 = q;
				break;
			case 1:
				this.uint_1 = q;
				break;
			case 2:
				this.uint_2 = q;
				break;
			case 3:
				this.uint_3 = q;
				break;
			}
		}
		else
		{
			switch (f & 3)
			{
			case 0:
				this.uint_0 ^= q;
				break;
			case 1:
				this.uint_1 += q;
				break;
			case 2:
				this.uint_2 ^= q;
				break;
			case 3:
				this.uint_3 -= q;
				break;
			}
		}
		switch ((f >> 2) & 3)
		{
		case 0:
			return this.uint_0;
		case 1:
			return this.uint_1;
		case 2:
			return this.uint_2;
		default:
			return this.uint_3;
		}
	}

	internal uint uint_0;

	internal uint uint_1;

	internal uint uint_2;

	internal uint uint_3;
}
