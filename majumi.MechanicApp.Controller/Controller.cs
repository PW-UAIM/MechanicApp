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

using majumi.MechanicApp.Utilities;
using majumi.MechanicApp.Model;

public partial class Controller : PropertyContainerBase, IController
{
	public IModel Model { get; private set; }

	public Controller(IEventDispatcher dispatcher, IModel model) : base(dispatcher)
	{
		Model = model;
		MechanicLogInCommand    = new ControllerCommand(this.MechanicLogIn);
		LoadCarsCommand    = new ControllerCommand(this.LoadCars);
		LoadVisitsCommand  = new ControllerCommand(this.LoadVisits);
		UpdateVisitCommand      = new ControllerCommand(this.UpdateVisit);
		GetVisitAtCommand    = new ControllerCommand(this.GetVisitAt);
		GetCarCommand      = new ControllerCommand(this.GetCar);
		GetVisitCommand    = new ControllerCommand(this.GetVisit);
	}

}
