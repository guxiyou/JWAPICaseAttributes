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
		private string _submitStatus;
		private string _caseAttribute;
		private string _codeListValue;
		private CaseAttribute _currentCaseAttribute;
		private List<CaseAttributeCodeListType> _caseAttributeCodeListTypes;
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

		public string SubmitStatus
		{
			get { return _submitStatus; }
			set
			{
				_submitStatus = value;
				OnPropertyChanged("SubmitStatus");
			}
		}

		public string CaseAttribute
		{
			get { return _caseAttribute; }
			set
			{
				_caseAttribute = value;
				OnPropertyChanged("CaseAttribute");
			}
		}

		public string CodeListValue
		{
			get { return _codeListValue; }
			set
			{
				_codeListValue = value;
				OnPropertyChanged("CodeListValue");
			}
		}

		public List<CaseAttributeType> CaseAttributeTypes { get; set; }
		public List<CaseAttributeCodeListType> CaseAttributeCodeListTypes
		{
			get { return _caseAttributeCodeListTypes; }
			set
			{
				_caseAttributeCodeListTypes = value;
				OnPropertyChanged("CaseAttributeCodeListTypes");
			}
		}

		public Case CurrentCase { get; set; }
		public CaseAttribute CurrentCaseAttribute
		{
			get { return _currentCaseAttribute; }
			set
			{
				_currentCaseAttribute = value;
				//CaseAttribute = _currentCaseAttribute != null ? _currentCaseAttribute.TypeCode : String.Empty;
				CodeListValue = _currentCaseAttribute != null ? _currentCaseAttribute.ListValueCode : String.Empty;
			}
		}

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
