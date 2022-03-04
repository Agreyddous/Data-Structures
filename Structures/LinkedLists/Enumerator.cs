using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Structures.LinkedLists
{
	public class Enumerator<TValue> : IEnumerator<TValue>
	{
		private Node<TValue> _start;
		private Node<TValue> _current;

		public Enumerator(LinkedList<TValue> list)
		{
			_start = list.First;
			_current = _start;
		}

		public TValue Current => _current.Value;
		object IEnumerator.Current => Current;

		public bool MoveNext()
		{
			bool hasNext = false;

			if (_current.Next != null)
			{
				hasNext = true;
				_current = _current.Next;
			}

			return hasNext;
		}

		public void Reset() => _current = _start;

		public void Dispose() { }
	}
}