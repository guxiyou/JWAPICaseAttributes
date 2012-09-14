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
	}
}
