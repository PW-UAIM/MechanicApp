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
using System.Collections.Generic;

public partial class Model : IData
{
	private int mechanicID;
	public int MechanicID
	{
		get { return mechanicID; }
		set
		{
			mechanicID = value;
			RaisePropertyChanged(nameof(MechanicID));
		}
	}

	private int searchedCarID;
	public int SearchedCarID
	{
		get { return searchedCarID; }
		set
		{
			searchedCarID = value;
			RaisePropertyChanged(nameof(SearchedCarID));
		}
	}

	private int searchedVisitID;
	public int SearchedVisitID
	{
		get { return searchedVisitID; }
		set
		{
			searchedVisitID = value;
			RaisePropertyChanged(nameof(SearchedVisitID));
		}
	}
	private int newCost;
	public int NewCost
	{
		get { return newCost; }
		set
		{
			newCost = value;
			RaisePropertyChanged(nameof(NewCost));
		}
	}
	private string newStatus;
	public string NewStatus
	{
		get { return newStatus; }
		set
		{
			newStatus = value;
			RaisePropertyChanged(nameof(NewStatus));
		}
	}

	private bool loginConfirmation;
	public bool LoginConfirmation
	{
		get { return loginConfirmation; }
		private set
		{
			loginConfirmation = value;
			RaisePropertyChanged(nameof(LoginConfirmation));
		}
	}

	private List<CarData> carList = new List<CarData>();
	public List<CarData> CarList
	{
		get { return carList; }
		private set
		{
			carList = value;
			RaisePropertyChanged(nameof(CarList));
		}
	}
	private List<VisitData> visitList = new List<VisitData>();
	public List<VisitData> VisitList
	{
		get { return visitList; }
		private set
		{
			visitList = value;
			RaisePropertyChanged(nameof(VisitList));
		}
	}
	private CarData selectedCar;
	public CarData SelectedCar
	{
		get { return selectedCar; }
		set
		{
			selectedCar = value;
			RaisePropertyChanged(nameof(SelectedCar));
		}
	}
	private VisitData selecetedVisit;
	public VisitData SelectedVisit
	{
		get { return selecetedVisit; }
		set
		{
			selecetedVisit = value;
			RaisePropertyChanged(nameof(SelectedVisit));
		}
	}
	private DateOnly selectedDate;
	public DateOnly SelectedDate
	{
		get { return selectedDate; }
		set
		{
			selectedDate = value;
			RaisePropertyChanged(nameof(SelectedDate));
		}
	}

	private MechanicData loggedMechanic;
	public MechanicData LoggedMechanic
	{
		get { return loggedMechanic;}
		set
		{
			loggedMechanic = value;
			RaisePropertyChanged(nameof(LoggedMechanic));
		}
	}
}
