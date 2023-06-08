//===============================================================================
//
// PlaZa System Platform
//
//===============================================================================
//
// Warsaw University of Technology
// Computer Networks and Services Division
// Copyright © 2020 PlaZa Creators
// All rights reserved.
//
//===============================================================================

using System;

namespace majumi.MechanicApp.Model;

public static class NetworkClientFactory
{
	public static IClient GetNetworkClient()
	{
		if(!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("MECHANICAPPSERVICE_SERVICE_HOST"))) 
		{
			return new NetworkClient(Environment.GetEnvironmentVariable("MECHANICAPPSERVICE_SERVICE_HOST"), int.Parse(Environment.GetEnvironmentVariable("MECHANICAPPSERVICE_SERVICE_PORT")));
		}	
		else if (Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true")
		{
			return new NetworkClient("mechanicappservice", 5011);
		}
		else
		{
			return new FakeNetworkClient();
		}
	}
}
