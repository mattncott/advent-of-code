using System;
namespace AdventOfCode.DayFour
{
	public class AreaToClean
	{
		private readonly int _startPos;
		private readonly int _endPos;

		public AreaToClean(int startPos, int endPos)
		{
			this._startPos = startPos;
			this._endPos = endPos;
		}

		public int First
		{
			get => this._startPos;
		}

		public int Last
		{
			get => this._endPos;
		}
	}
}

