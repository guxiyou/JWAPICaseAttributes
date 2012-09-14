using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWAPICaseAttributes.JustWareApi;
using JWAPICaseAttributes.Models;

namespace JWAPICaseAttributes
{
	public class CaseViewModel
	{
		private CaseModel _caseModel;
		private APICommunicator _apiCommunicator;
		public CaseViewModel(CaseModel caseModel)
		{
			_caseModel = caseModel;
			_apiCommunicator = new APICommunicator();
		}

		public void GetCase()
		{
			Case c = _apiCommunicator.GetCase(_caseModel.QueryCaseID);
			_caseModel.Status = "Retrieved " + c.CaseTitle;
		}
	}
}
