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

namespace majumi.MechanicApp.Model;

using majumi.CarService.MechanicsAppService.Rest.Model;
using System.Collections.Generic;
using System;

public class NetworkClient : IClient
{
	private readonly ServiceClient serviceClient;

	public NetworkClient(string serviceHost, int servicePort)
	{
		this.serviceClient = new ServiceClient(serviceHost, servicePort);
	}

	public List<VisitData> GetVisitsAt(int mechanicID, int year, int month, int day)
	{
		string callUri = String.Format("/getAllVisitsByMechanicInDay/{0}/{1}/{2}/{3}", mechanicID, year, month, day);

		List<VisitData> result = this.serviceClient.CallWebService<List<VisitData>>(callUri);

		return result;
	}
	public bool UpdateVisit(int visitID, int mechanicID, string newStatus, int cost)
	{
		string callUri = String.Format("updateVisitStatus/{0}/{1}/{2}/{4}", visitID, mechanicID, newStatus, cost);

		bool result = this.serviceClient.CallWebService<bool>(callUri);

		return result;
	}
	public MechanicLoginStatus MechanicLogIn(int mechanicID)
	{
		string callUri = String.Format("login/{0}", mechanicID);

		MechanicLoginStatus loginStatus = this.serviceClient.CallWebService<MechanicLoginStatus>(callUri);

		return loginStatus;
	}
	public List<CarData> GetAllCars()
	{
		string callUri = String.Format("getAllCars");

		List<CarData> cars = this.serviceClient.CallWebService<List<CarData>>(callUri);

		return cars;
	}
	public List<VisitData> GetMechanicsVisits(int mechanicID)
	{
		string callUri = String.Format("getAllVisitsByMechanic/{0}", mechanicID);

		List<VisitData> visits = this.serviceClient.CallWebService<List<VisitData>>(callUri);

		return visits;
	}
	public CarData GetCar(int clientID)
	{
		string callUri = String.Format("getCar/{0}", clientID);

		CarData car = this.serviceClient.CallWebService<CarData>(callUri);

		return car;
	}
	public VisitData GetVisit(int clientID)
	{
		string callUri = String.Format("getVisit/{0}", clientID);

		VisitData visit = this.serviceClient.CallWebService<VisitData>(callUri);

		return visit;
	}
}
