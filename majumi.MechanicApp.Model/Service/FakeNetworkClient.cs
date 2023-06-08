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

public class FakeNetworkClient : IClient
{
	private static List<CarData> cars = new List<CarData> { 
		new CarData() { 
			CarID = 1, 
			Make = "Ford", 
			Model = "Mustang",
			EngineSize = "2.3V",
			LicensePlate = "WPL 23300",
			ClientID = 1, 
			Mileage = 300000, 
			VIN = "98ZCC798ZSD",
			Year = 2023
		} 
	};
	private static List<MechanicData> mechanics = new List<MechanicData> { 
		new MechanicData() { 
			MechanicID = 1, 
			Name = "Kamil", 
			Surname = "Slimak", 
			BirthDate = DateTime.Now, 
			HireDate = DateTime.Now,
			Specialty = "Screwdriver",
			Address = "Warszawa", 
			Phone = "123456789", 
			Email = "kamil.slimak@smail.com", 
		} 
	};
	private static List<VisitData> visits = new List<VisitData> { 
		new VisitData() {
			VisitID = 1,
			CarID = 1, 
			ClientID = 1, 
			MechanicID = 1, 
			Notes = "", 
			ServiceCost = 230, 
			ServiceDate = new DateTime(2023, 6, 1, 12, 0, 0),
            ServiceStatus = "W trakcie", 
			ServiceType = "Wymiana plynu w wycieraczkach"
		} 
	};

	public MechanicLoginStatus MechanicLogIn(int mechanicID)
	{
		MechanicData mechanic = mechanics.Find((mechanic) => mechanic.MechanicID == mechanicID);

		if (mechanic != null)
		{
			return new MechanicLoginStatus(true, mechanic);
		}

		return new MechanicLoginStatus(false, null);
	}
	public List<CarData> GetAllCars()
	{
		return cars;
	}
	public List<VisitData> GetMechanicsVisits(int mechanicID)
	{
		return visits.FindAll((visit) => visit.MechanicID == mechanicID);
	}
	public bool UpdateVisit(int visitID, int mechanicID, string newStatus, int cost)
	{
		int i = visits.FindIndex((visit) => visit.VisitID == visitID);
		visits[i].MechanicID = mechanicID;
		visits[i].ServiceStatus = newStatus;
		visits[i].ServiceCost = cost;
		return true;
	}
	public List<VisitData> GetVisitsAt(int mechanicID, int year, int month, int day)
	{
		List<VisitData> mechanicsVisits = visits.FindAll((visit) => visit.MechanicID == mechanicID);
		return mechanicsVisits.FindAll((visit) => visit.ServiceDate.Year == year && visit.ServiceDate.Month == month && visit.ServiceDate.Day == day);
	}

	public CarData GetCar(int carID)
	{
		return cars.Find((car) => car.CarID == carID);
	}
	public VisitData GetVisit(int visitID)
	{
		return visits.Find((visit) => visit.VisitID == visitID);
	}
}
