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
using System.Windows.Input;

public partial class Controller : IController
{
	public ApplicationState CurrentState
	{
		get { return this.currentState; }
		set
		{
			currentState = value;
			RaisePropertyChanged("CurrentState");
		}
	}
	private ApplicationState currentState = ApplicationState.List;

	public ICommand MechanicLogInCommand { get; private set; }
	private void MechanicLogIn()
	{
		Model.MechanicLogIn();
	}
	public async Task MechanicLogInAsync()
	{
		await Task.Run(() => MechanicLogIn());
	}

	public ICommand LoadCarsCommand { get; private set; }
	private void LoadCars()
	{
		Model.LoadCarsList();
	}
	public async Task LoadCarsAsync()
	{
		await Task.Run(() => LoadCars());
	}

	public ICommand LoadVisitsCommand { get; private set; }
	private void LoadVisits()
	{
		Model.LoadVisitsList();
	}
	public async Task LoadVisitsAsync()
	{
		await Task.Run(() => LoadVisits());
	}

	public ICommand UpdateVisitCommand { get; private set; }
	private void UpdateVisit()
	{
		Model.UpdateVisit();
	}
	public async Task UpdateVisitAsync()
	{
		await Task.Run(() => UpdateVisit());
	}

	public ICommand GetVisitAtCommand { get; private set; }
	private void GetVisitAt()
	{
		Model.GetVisitsAt();
	}
	public async Task GetVisitAtAsync()
	{
		await Task.Run(() => GetVisitAt());
	}

	public ICommand GetCarCommand { get; private set; }
	private void GetCar()
	{
		Model.GetCarById();
	}
	public async Task GetCarAsync()
	{
		await Task.Run(() => GetCar());
	}

	public ICommand GetVisitCommand { get; private set; }
	private void GetVisit()
	{
		Model.GetVisitById();
	}
	public async Task GetVisitAsync()
	{
		await Task.Run(() => GetVisit());
	}

}
