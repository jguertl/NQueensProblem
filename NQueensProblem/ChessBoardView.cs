using System;
using Xamarin.Forms;

namespace NQueensProblem
{
	public class ChessBoardView:ContentView
	{
		public ChessBoardView(byte[] ranks)
		{
			AbsoluteLayout absoluteLayout = new AbsoluteLayout();

			for (int i = 0; i < ranks.Length; i++)
			{
				int j = ranks[i];
				for (int k = 1; k <= ranks.Length; k++) 
				{
					if(k == j)
						absoluteLayout.Children.Add(new BoxView(){WidthRequest = 25, HeightRequest = 25,Color = Color.Red},new Point(i*30,k*30));
					else
						absoluteLayout.Children.Add(new BoxView(){WidthRequest = 25, HeightRequest = 25,Color = Color.Gray},new Point(i*30,k*30));
				}
			}

			Content = absoluteLayout;
		}
	}
}

