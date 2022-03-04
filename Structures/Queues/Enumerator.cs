using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Structures.Queues
{
	public class Enumerator<TValue> : IEnumerator<TValue>
	{
		private Queue<TValue> _Queue;
		private Queue<TValue> _resetQueue;
		private TValue _current;

		public Enumerator(Queue<TValue> Queue)
		{
			_Queue = Queue;
			_resetQueue = new Queue<TValue>(_Queue.Size);
		}

		public TValue Current => _current;
		object IEnumerator.Current => Current;

		public bool MoveNext()
		{
			bool hasNext = false;

			if (!_Queue.IsEmpty)
			{
				_current = _Queue.Dequeue();
				_resetQueue.Enqueue(_current);

				hasNext = true;
			}

			return hasNext;
		}

		public void Reset()
		{
			while (!_resetQueue.IsEmpty)
				_Queue.Enqueue(_resetQueue.Dequeue());
		}

		public void Dispose() { }
	}
}