using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWAPICaseAttributes.JustWareApi;

namespace JWAPICaseAttributes.Models
{
	public class CaseModel : INotifyPropertyChanged
	{
		private string _status;
		public string QueryCaseID { get; set; }
		public string CaseTitle
		{
			get { return CurrentCase != null ? CurrentCase.CaseTitle : String.Empty; }
		}
		public string Status
		{
			get { return _status; }
			set
			{
				_status = value;
				OnPropertyChanged("Status");
			}
		}

		public Case CurrentCase { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string name)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(name));
			}
		}
	}
}
