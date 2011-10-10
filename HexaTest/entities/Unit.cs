using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HexaTest.entities
{
	class Unit
	{
		int _moveRange;
		int _viewDistance;
		int _currentFuel;
		int _maxFuel;

		//TODO: maxfuel setzen
		public Unit(int CurrentFuel)
		{
			this._currentFuel = CurrentFuel; 

			
		}
	}
}
