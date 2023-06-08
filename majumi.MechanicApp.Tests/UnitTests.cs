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

namespace majumi.MechanicApp.Tests;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using majumi.MechanicApp.Model;
using majumi.MechanicApp.Utilities;
using majumi.CarService.MechanicsAppService.Rest.Model;
using System;

[TestClass]
public class UnitTests
{
	IModel model;
	int mechanicID;
	[TestInitialize]
	public void t_00_TestInitialize()
	{
		model = new Model(new EmptyEventDispatcher());
		mechanicID = 1;
		model.MechanicID = mechanicID;
		model.MechanicLogIn();
	}

	[TestMethod]
	public void t_01_LogInAsClient_SuccesfullLogIn()
	{
		mechanicID = 1;
		model.MechanicID = mechanicID;
		model.MechanicLogIn();
		bool expectedConfirmation = true;
		bool actualConfirmation = model.LoginConfirmation;
		Assert.AreEqual(expectedConfirmation, actualConfirmation, "Mechanic with given id exists, expeted {0} got {1}", expectedConfirmation, actualConfirmation);
	}

	[TestMethod]
	public void t_02_LogInAsClient_ThereIsNoClientWithProvidedID()
	{
		mechanicID = 10000;
		model.MechanicID = mechanicID;
		model.MechanicLogIn();
		bool expectedConfirmation = false;
		bool actualConfirmation = model.LoginConfirmation;
		Assert.AreEqual(expectedConfirmation, actualConfirmation, "Mechanic with given id does not exist, expeted {0} got {1}", expectedConfirmation, actualConfirmation);
	}

	[TestMethod]
	public void t_03_GetCarById_ThisCarExists()
	{
		model.SearchedCarID = 1;
		model.GetCarById();

		Assert.IsNotNull(model.SelectedCar, "Car is null");
	}

	[TestMethod]
	public void t_04_GetVisitById_SuchVisitExists()
	{
		model.SearchedVisitID = 1;
		model.GetVisitById();

		Assert.IsNotNull(model.SelectedVisit, "Car is null");
	}


	[TestMethod]
	public void t_05_LoadCarList_ReadFromFakeClient_ThereIsOneClientsCar()
	{
		model.LoadCarsList();
		int expectedCount = 1;
		int actualCount = model.CarList.Count;

		Assert.AreEqual(expectedCount, actualCount, "Car count should be {0} and not {1}", expectedCount, actualCount);
	}

	[TestMethod]
	public void t_06_LoadVisitList_ReadFromFakeClient_ThereIsOneClientsVisit()
	{
		model.LoadVisitsList();
		int expectedCount = 1;
		int actualCount = model.VisitList.Count;

		Assert.AreEqual(expectedCount, actualCount, "Visit count should be {0} and not {1}", expectedCount, actualCount);
	}

	[TestMethod]
	public void t_07_GetVisitsAt()
	{
		model.SelectedDate = new DateOnly(2023, 6, 1);
		model.GetVisitsAt();
		int expectedCount = 1;
		int actualCount = model.VisitList.Count;

		Assert.AreEqual(expectedCount, actualCount, "Visit count should be {0} and not {1}", expectedCount, actualCount);
	}

	[TestMethod]
	public void t_08_UpdateVisitStaus()
	{
		int newCost = 100;
		string newStatus = "TEST_STATUS";
		model.SearchedVisitID = 1;
		model.NewCost = newCost;
		model.NewStatus = newStatus;

		model.UpdateVisit();

		model.GetVisitById();
		Assert.AreEqual(model.SelectedVisit.ServiceCost, newCost, "Got Wrong Cost, expeted {0} got {1}", newCost, model.SelectedVisit.ServiceCost);
		Assert.AreEqual(model.SelectedVisit.ServiceStatus, newStatus, "Got Wrong Status, expeted {0} got {1}", newStatus, model.SelectedVisit.ServiceStatus);
	}
}
