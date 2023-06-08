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
using System.ComponentModel;

public interface IData : INotifyPropertyChanged
{
	int MechanicID { get; set; }
	int SearchedCarID { get; set; }
	int SearchedVisitID { get; set; }
	bool LoginConfirmation { get; }
	int NewCost { get; set; }
	string NewStatus { get; set; }
	List<CarData> CarList { get; }
	List<VisitData> VisitList{ get; }
	CarData SelectedCar { get; set; }
	VisitData SelectedVisit { get; set;}
	DateOnly SelectedDate { get; set; }
}
