using System;
using Xamarin.Forms;

namespace NQueensProblem
{
	public class HomePage:ContentPage
	{
		private StackLayout _solutionsLayout;
		private NQueenProblemSolver _nqs;

		public HomePage()
		{
			_nqs = new NQueenProblemSolver();
			_nqs.OnSolutionFound += displaySolution;

			_solutionsLayout = new StackLayout(){VerticalOptions = LayoutOptions.Start, HorizontalOptions = LayoutOptions.CenterAndExpand};

			StackLayout stackLayout = new StackLayout(){Padding = new Thickness(20)};

			Label label = new Label(){Text = "N Queens Problem \n Enter Dimension: ",VerticalOptions = LayoutOptions.Start, HorizontalOptions = LayoutOptions.CenterAndExpand};
			stackLayout.Children.Add (label);

			Entry entry = new Entry(){Placeholder = "Dimension", VerticalOptions = LayoutOptions.Start, HorizontalOptions = LayoutOptions.CenterAndExpand};
			stackLayout.Children.Add (entry);

			Button button = new Button (){Text = "Generate Solution(s)", VerticalOptions = LayoutOptions.Start, HorizontalOptions = LayoutOptions.FillAndExpand};
			button.Clicked += delegate(object sender, EventArgs e) {
				solveProblem(Convert.ToInt32(entry.Text));
			};
			stackLayout.Children.Add (button);

			ScrollView srollView = new ScrollView (){VerticalOptions = LayoutOptions.Start, HorizontalOptions = LayoutOptions.CenterAndExpand};

			srollView.Content = _solutionsLayout;
			stackLayout.Children.Add(srollView);
			Content = stackLayout;
		}

		private void solveProblem(int dimension)
		{
			_solutionsLayout.Children.Clear ();
			_nqs.Solve(dimension);
		}

		private void displaySolution(object sender, NQueenProblemEventArgs e)
		{
			ChessBoardView cbv = new ChessBoardView (e.TheSolution.Ranks);
			_solutionsLayout.Children.Add (cbv);
		}
	}
}

