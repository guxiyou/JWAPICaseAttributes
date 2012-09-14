using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using JWAPICaseAttributes.Models;

namespace JWAPICaseAttributes
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private CaseModel _model;
		private CaseViewModel _viewModel;
		public MainWindow()
		{
			InitializeComponent();
			_model = new CaseModel();
			_viewModel = new CaseViewModel(_model);
			this.DataContext = _model;
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			_viewModel.GetCase();
		}
	}
}
