using System;

namespace NQueensProblem
{
	public class NQueenProblemSolver
	{
		public  delegate void SolutionFoundDelegate(object Sender, NQueenProblemEventArgs e);
		public event SolutionFoundDelegate OnSolutionFound;

		private int _dimension = 7;
		private PascalBoolArray _mainDiagonalOccupation;
		private PascalBoolArray _secondaryDiagonalOccupation;
		private PascalBoolArray _rankOccupation;
		private PascalByteArray _rankAtColumn;
		private SolutionCollection _solutions = new SolutionCollection();

		private Solution saveSolution()
		{
			Solution solution = new Solution(_dimension);
			for (int i = 1; i <= _dimension; i++)
			{
				solution[i] = (byte)_rankAtColumn[i];
			}
			_solutions.Add(solution);
			return solution;
		}
			
		private void Notify(Solution solution)
		{
			if (OnSolutionFound != null)
				OnSolutionFound(this, new NQueenProblemEventArgs() { TheSolution = solution });
		}
			
		private void Next(int file)
		{
			for (byte rank = 1; rank <= _dimension; rank++)
			{
				if (!(_rankOccupation[rank]) && !(_secondaryDiagonalOccupation[file + rank]) && !(_mainDiagonalOccupation[file - rank]))
				{ 
					_rankAtColumn[file] = rank;
					_rankOccupation[rank] = true;
					_secondaryDiagonalOccupation[file + rank] = true;
					_mainDiagonalOccupation[file - rank] = true;
					if (file < _dimension)
					{
						Next(file + 1);
					}
					else
					{ 
						Solution solution = saveSolution();
						Notify(solution);
					}
					_rankOccupation[rank] = false;
					_secondaryDiagonalOccupation[file + rank] = false;
					_mainDiagonalOccupation[file - rank] = false;
				}
			}
		}
			
		public SolutionCollection Solutions
		{
			get { return this._solutions; }
		}
		public int N
		{
			get
			{
				return _dimension;
			}
		}
		public void Solve(int n)
		{
			this._dimension = n;
			_mainDiagonalOccupation = new PascalBoolArray(-_dimension + 1, _dimension - 1);
			_secondaryDiagonalOccupation = new PascalBoolArray(2, 2 * _dimension);
			_rankOccupation = new PascalBoolArray(1, _dimension);
			_rankAtColumn = new PascalByteArray(1, _dimension);
			Next(1);
		}
	}

}

