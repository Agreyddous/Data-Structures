using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Structures.Stacks
{
	public class Enumerator<TValue> : IEnumerator<TValue>
	{
		private Stack<TValue> _stack;
		private Stack<TValue> _resetStack;
		private TValue _current;

		public Enumerator(Stack<TValue> stack)
		{
			_stack = stack;
			_resetStack = new Stack<TValue>(_stack.Size);
		}

		public TValue Current => _current;
		object IEnumerator.Current => Current;

		public bool MoveNext()
		{
			bool hasNext = false;

			if (!_stack.IsEmpty)
			{
				_current = _stack.Pop();
				_resetStack.Push(_current);

				hasNext = true;
			}

			return hasNext;
		}

		public void Reset()
		{
			while (!_resetStack.IsEmpty)
				_stack.Push(_resetStack.Pop());
		}

		public void Dispose() { }
	}
}