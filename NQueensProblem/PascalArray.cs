using System;

namespace NQueensProblem
{
	public class PascalArray<T>
	{
		private T[] m_array;
		private int m_lowerbound;
		private int m_upperbound;

		public PascalArray(int lowerbound, int upperbound)
		{
			this.m_lowerbound = lowerbound;
			this.m_upperbound = upperbound;
			m_array = new T[upperbound - lowerbound + 1];
		}

		public virtual T this[int index]
		{
			get
			{
				return m_array[index - m_lowerbound];
			}
			set
			{
				m_array[index - m_lowerbound] = value;
			}
		}
	}
}

