using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Structures.Queues
{
	public class Queue<TValue> : IEnumerable<TValue>
	{
		private TValue[] _data;

		private int _firstIndex;
		private int _lastIndex;
		private int _size;

		public Queue(int size)
		{
			_size = size + 1;

			_firstIndex = 0;
			_lastIndex = 0;

			_data = new TValue[_size];
		}

		public int Size => _size - 1;

		public int Length => _lastIndex + _firstIndex;
		public bool IsFull => (_lastIndex + 1) % _size == _firstIndex;
		public bool IsEmpty => _firstIndex == _lastIndex;

		public void Enqueue(TValue value)
		{
			_data[_lastIndex] = value;
			_lastIndex = _increaseIndex(_lastIndex);
		}

		public void EnqueueFirst(TValue value)
		{
			_firstIndex = _decreaseIndex(_firstIndex);
			_data[_firstIndex] = value;
		}

		public TValue Dequeue()
		{
			TValue value = _data[_firstIndex];
			_firstIndex = _increaseIndex(_firstIndex);

			return value;
		}

		public TValue DequeueLast()
		{
			_lastIndex = _decreaseIndex(_lastIndex);
			return _data[_lastIndex];
		}

		private int _increaseIndex(int index) => ++index % _size;
		private int _decreaseIndex(int index) => --index % _size;

		public IEnumerator<TValue> GetEnumerator() => new Enumerator<TValue>(this);
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}