using System;

namespace NQueensProblem
{
	public class PascalByteArray : PascalArray<byte>
	{
		public PascalByteArray(int lowerbound, int upperbound)
			: base(lowerbound, upperbound)
		{
			for (int i = lowerbound; i <= upperbound; i++)
				this[i] = 0;
		}
	}
}

