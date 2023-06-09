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
using System;

public partial class Model : IOperations
{
	private void MechanicLogInTask()
	{
		IClient networkClient = NetworkClientFactory.GetNetworkClient();

		try
		{
			MechanicLoginStatus confirmation = networkClient.MechanicLogIn(MechanicID);
			if (!confirmation.IsSuccesfull)
			{
				MechanicID = 0;
			}
			else
			{
				LoggedMechanic = confirmation.Mechanic;
			}
			LoginConfirmation = confirmation.IsSuccesfull;
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}

	}
	public void MechanicLogIn()
	{
		MechanicLogInTask();
	}

	private void GetCarByIdTask()
	{
		IClient networkClient = NetworkClientFactory.GetNetworkClient();
		try
		{
			CarData car = networkClient.GetCar(searchedCarID);
			if (car != null)
			{
				SelectedCar = car;
			}
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
	public void GetCarById()
	{
		GetCarByIdTask();
	}

	private void GetVisitByIdTask()
	{
		IClient networkClient = NetworkClientFactory.GetNetworkClient();
		
		try
		{
			VisitData visit = networkClient.GetVisit(searchedVisitID);
			if (visit != null)
			{
				SelectedVisit = visit;
			}
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
	public void GetVisitById()
	{
		GetVisitByIdTask();
	}
	private void GetVisitsAtTask()
	{
		IClient networkClient = NetworkClientFactory.GetNetworkClient();

		try {
			VisitList = networkClient.GetVisitsAt(MechanicID, SelectedDate.Year, SelectedDate.Month, SelectedDate.Day);
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
	public void GetVisitsAt()
	{
		GetVisitsAtTask();
	}
	private void UpdateVisitTask()
	{
		IClient networkClient = NetworkClientFactory.GetNetworkClient();

		try
		{
			networkClient.UpdateVisit(SearchedVisitID, MechanicID, NewStatus, NewCost);
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
	public void UpdateVisit()
	{
		UpdateVisitTask();
	}

	private void LoadVisitsTask()
	{
		IClient networkClient = NetworkClientFactory.GetNetworkClient();

		try
		{
			VisitList = networkClient.GetMechanicsVisits(MechanicID);
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
	public void LoadVisitsList()
	{
		LoadVisitsTask();
	}

	private void LoadCarTask()
	{
		IClient networkClient = NetworkClientFactory.GetNetworkClient();

		try
		{
			CarList = networkClient.GetAllCars();
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
	public void LoadCarsList()
	{
		LoadCarTask();
	}
}
