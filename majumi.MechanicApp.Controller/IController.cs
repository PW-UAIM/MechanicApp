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

namespace majumi.MechanicApp.Controller;

using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using majumi.MechanicApp.Model;

public interface IController : INotifyPropertyChanged
{
	IModel Model { get; }
	ApplicationState CurrentState { get; }

	ICommand MechanicLogInCommand { get; }
	Task MechanicLogInAsync();

	ICommand LoadCarsCommand { get; }
	Task LoadCarsAsync();

	ICommand LoadVisitsCommand { get; }
	Task LoadVisitsAsync();

	ICommand UpdateVisitCommand { get;  }
	Task UpdateVisitAsync();

	ICommand GetVisitAtCommand { get; }
	Task GetVisitAtAsync();
	
	ICommand GetCarCommand { get;  }
	Task GetCarAsync();

	ICommand GetVisitCommand { get; }
	Task GetVisitAsync();
}