using System;
namespace AdventOfCode.DayFive
{
	public class Move
	{
		private readonly int _stackToMove;
		private readonly int _moveStackTo;
		private readonly int _quantity;

		public Move(int stackToMove, int moveStackTo, int quantity)
		{
			this._stackToMove = stackToMove - 1;
			this._moveStackTo = moveStackTo - 1;
			this._quantity = quantity; // Array index start at 0
		}

		public int StackToMove { get => this._stackToMove; }
		public int MoveStackTo { get => this._moveStackTo; }
		public int Quantity { get => this._quantity; }
	}
}

