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

public interface IOperations
{
	void MechanicLogIn();
	void GetCarById();
	void GetVisitById();
	void GetVisitsAt();
	void UpdateVisit();
	void LoadCarsList();
	void LoadVisitsList();
}