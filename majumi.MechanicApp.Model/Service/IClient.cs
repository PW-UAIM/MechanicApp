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

using majumi.CarService.MechanicsAppService.Rest.Model;
using System.Collections.Generic;

namespace majumi.MechanicApp.Model;

public interface IClient
{
	public MechanicLoginStatus MechanicLogIn(int mechanicID);
	public List<CarData> GetAllCars();
	public List<VisitData> GetMechanicsVisits(int mechanicID);
	public bool UpdateVisit(int visitID, int mechanicID, string newStatus, int cost);
	public List<VisitData> GetVisitsAt(int mechanicID, int year, int month, int day);
	public CarData GetCar(int carID);
	public VisitData GetVisit(int visitID);
}
