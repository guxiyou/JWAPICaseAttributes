using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWAPICaseAttributes.JustWareApi;
using JWAPICaseAttributes.Models;

namespace JWAPICaseAttributes
{
	public class APICommunicator
	{
		private JustWareApiClient _apiClient;

		public APICommunicator()
		{
			_apiClient = new JustWareApiClient();
			_apiClient.ClientCredentials.UserName.UserName = "NDT\\apiuser";
			_apiClient.ClientCredentials.UserName.Password = "NewDawn2012";
		}

		public Case GetCase(string caseId)
		{
			return _apiClient.GetCase(caseId, null);
		}

		public List<CaseAttributeType> GetCaseAttributeTypes()
		{
			return _apiClient.FindCaseAttributeTypes("1=1", null);
		}

		public List<CaseAttributeCodeListType> GetCaseAttributeCodeListTypes()
		{
			return _apiClient.FindCaseAttributeCodeListTypes("1=1", null);
		}

		public List<CaseAttributeCodeListType> GetFilteredAttributeCodeList(string attributeType)
		{
			return _apiClient.FindCaseAttributeCodeListTypes(String.Format("CaseAttributeCode = \"{0}\"", attributeType), null);
		}

		public CaseAttribute GetCaseAttribute(string caseID, string attributeType)
		{
			string query = String.Format("CaseID = \"{0}\" && TypeCode =\"{1}\"", caseID, attributeType);
			List<CaseAttribute> attributes = _apiClient.FindCaseAttributes(query);
			return attributes.FirstOrDefault();
		}

		public string UpdateCaseAttribute(CaseAttribute caseAttribute, string codeListValue)
		{
			caseAttribute.Operation = OperationType.Update;
			caseAttribute.ListValueCode = codeListValue;
			caseAttribute.ListValueCodeIsChanged = true;

			try
			{
				List<Key> keys = _apiClient.Submit(caseAttribute);
				return "Submit Successful.";
			}
			catch (Exception e)
			{
				return "Submit failed: " + e.Message;
			}
		}

		public string InsertCaseAttribute(string caseID, string caseAttribute, string codeListValue)
		{
			CaseAttribute ca = new CaseAttribute();
			ca.Operation = OperationType.Insert;
			ca.CaseID = caseID;
			ca.TypeCode = caseAttribute;
			ca.ListValueCode = codeListValue;

			try
			{
				List<Key> keys = _apiClient.Submit(ca);
				return "Successfully submitted CaseAttribute with ID: " + keys.First().NewID;
			}
			catch (Exception e)
			{
				return "Submit failed: " + e.Message;
			}

		}
	}
}
