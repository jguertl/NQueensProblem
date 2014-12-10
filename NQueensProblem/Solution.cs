using System;
using System.Text;

namespace NQueensProblem
{
	public class Solution
	{
		private byte[] _ranks;

		public Solution(int dimension)
		{
			_ranks = new byte[dimension];
		}

		public byte[] Ranks
		{
			get
			{
				return this._ranks;
			}
		}

		public byte this [int index] {
			get {
				return _ranks [index - 1];
			}
			set {
				_ranks [index - 1] = value;
			}
		}
	}
}

