using System;

namespace NQueensProblem
{
	public class PascalBoolArray : PascalArray<bool>
	{
		public PascalBoolArray(int lowerbound, int upperbound)
			: base(lowerbound, upperbound)
		{
			for (int i = lowerbound; i <= upperbound; i++)
				this[i] = false;
		}
	}
}

