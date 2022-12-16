using System;
namespace AdventOfCode.DayFour
{
	public class AreaPair
	{
		private readonly AreaToClean _areaOne;
		private readonly AreaToClean _areaTwo;

        public AreaPair(AreaToClean areaOne, AreaToClean areaTwo)
		{
			this._areaOne = areaOne;
			this._areaTwo = areaTwo;
        }

		public AreaToClean AreaOne { get => this._areaOne; }
		public AreaToClean AreaTwo { get => this._areaTwo; }
	}
}

