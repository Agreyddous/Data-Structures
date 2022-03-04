using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Structures.Stacks
{
	public class Stack<TValue> : IEnumerable<TValue>
	{
		private TValue[] _data;

		private int _bottomIndex;
		private int _topIndex;
		private int _size;

		public Stack(int size)
		{
			_size = size + 1;
			_bottomIndex = 0;
			_topIndex = 0;

			_data = new TValue[_size];
		}

		public int Size => _size - 1;

		public int Length => _topIndex + _bottomIndex;
		public bool IsFull => (_topIndex + 1) % _size == _bottomIndex;
		public bool IsEmpty => _bottomIndex == _topIndex;

		public void Push(TValue value)
		{
			_data[_topIndex] = value;
			_topIndex = _increaseIndex(_topIndex);
		}

		public void PushBottom(TValue value)
		{
			_bottomIndex = _decreaseIndex(_bottomIndex);
			_data[_bottomIndex] = value;
		}

		public TValue Pop()
		{
			_topIndex = _decreaseIndex(_topIndex);
			return _data[_topIndex];
		}

		public TValue PopBottom()
		{
			TValue value = _data[_bottomIndex];

			_bottomIndex = _increaseIndex(_bottomIndex);

			return value;
		}

		private int _increaseIndex(int index) => ++index % _size;
		private int _decreaseIndex(int index) => --index % _size;

		public IEnumerator<TValue> GetEnumerator() => new Enumerator<TValue>(this);

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}