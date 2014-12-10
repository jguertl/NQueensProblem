using System;
using System.Collections.Generic;

namespace NQueensProblem
{
	public class SolutionCollection : List<Solution>
	{
		public int this[int solution, int column]
		{
			get
			{
				return this[solution][column];
			}
		}
	}
}

