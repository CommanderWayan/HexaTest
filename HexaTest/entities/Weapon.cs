using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HexaTest.entities
{
	class Weapon
	{
		int _minFireRange;
		int _maxFireRange;
		int _actualAmmo;
		int _maxAmmo;

		//TODO: Maxammo setzen!
		public Weapon(int ActualAmmo)
		{
			this._actualAmmo = ActualAmmo;
		}
	}
}
