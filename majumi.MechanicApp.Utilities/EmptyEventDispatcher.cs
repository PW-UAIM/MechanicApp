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

namespace majumi.MechanicApp.Utilities;

using System;

public class EmptyEventDispatcher : IEventDispatcher
{
	#region IEventDispatcher

	public void Dispatch(Action eventAction)
	{
	}
	#endregion
}
