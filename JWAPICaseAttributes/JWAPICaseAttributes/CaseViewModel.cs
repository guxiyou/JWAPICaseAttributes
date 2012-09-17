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
			_caseModel.CaseAttributeTypes = _apiCommunicator.GetCaseAttributeTypes();
			_caseModel.CaseAttributeCodeListTypes = _apiCommunicator.GetCaseAttributeCodeListTypes();
		}

		public void GetCase()
		{
			Case c = _apiCommunicator.GetCase(_caseModel.QueryCaseID);
			if (c != null)
			{
				_caseModel.CurrentCase = c;
				_caseModel.Status = "Retrieved " + c.CaseTitle;
			}
			else
			{
				_caseModel.Status = _caseModel.QueryCaseID + " not found.";
			}
		}

		public void AttributeChanged()
		{
			string selectedAttribute = _caseModel.CaseAttribute;
			_caseModel.CaseAttributeCodeListTypes = _apiCommunicator.GetFilteredAttributeCodeList(selectedAttribute);
			
			CaseAttribute existingAttribute = _apiCommunicator.GetCaseAttribute(_caseModel.CurrentCase.ID, selectedAttribute);
			_caseModel.CurrentCaseAttribute = existingAttribute;
		}

		public void SaveCaseAttribute()
		{
			string submitMessage;
			if(_caseModel.CurrentCaseAttribute != null)//Update
			{
				submitMessage = _apiCommunicator.UpdateCaseAttribute(_caseModel.CurrentCaseAttribute, _caseModel.CodeListValue);
			}
			else//Insert
			{
				submitMessage = _apiCommunicator.InsertCaseAttribute(_caseModel.CurrentCase.ID, _caseModel.CaseAttribute, _caseModel.CodeListValue);
			}
			_caseModel.SubmitStatus = submitMessage;
		}
	}
}
