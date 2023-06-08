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
using System.ComponentModel;

public class PropertyContainerBase : INotifyPropertyChanged
{
	#region INotifyPropertyChanged

	public event PropertyChangedEventHandler PropertyChanged;

	#endregion

	protected readonly IEventDispatcher dispatcher;

	protected PropertyContainerBase(IEventDispatcher dispatcher)
	{
		this.dispatcher = dispatcher;
	}

	protected void RaisePropertyChanged(string propertyName)
	{
		PropertyChangedEventHandler handler = PropertyChanged;

		if (handler != null)
		{
			PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);

			/* AT
			handler( this, args );
			*/
			Action action = () => handler(this, args);

			dispatcher.Dispatch(action);
		}
	}
}
