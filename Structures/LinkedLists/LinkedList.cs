using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Structures.LinkedLists
{
	public class LinkedList<TValue> : IEnumerable<TValue>
	{
		public LinkedList() { }
		public LinkedList(TValue firstValue)
		{
			First = new Node<TValue>(firstValue);
			Last = First;
			Length = 1;
		}

		public Node<TValue> First { get; private set; }
		public Node<TValue> Last { get; private set; }

		public int Length { get; private set; }

		public LinkedList<TValue> AddItem(TValue value) => AddItem(new Node<TValue>(value));

		public LinkedList<TValue> AddItem(Node<TValue> newItem)
		{
			newItem.UpdatePrevious(Last);
			Last.UpdateNext(newItem);

			Last = newItem;
			Length++;

			return this;
		}

		public LinkedList<TValue> InsertAt(Node<TValue> newItem, int index)
		{
			Node<TValue> currentAtPosition = _iterate(First, index);

			currentAtPosition.Previous.UpdateNext(newItem);
			newItem.Update(currentAtPosition, currentAtPosition.Previous);
			currentAtPosition.UpdatePrevious(newItem);

			Length++;

			return this;
		}

		public Node<TValue> PopItem()
		{
			Node<TValue> poppedNode = First;
			First = First.Next;
			Length--;

			return poppedNode;
		}

		public Node<TValue> PopAt(int index)
		{
			Node<TValue> poppedNode = _iterate(First, index);

			poppedNode.Previous.UpdateNext(poppedNode.Next);
			poppedNode.Next.UpdatePrevious(poppedNode.Previous);

			poppedNode.Update(null, null);

			return poppedNode;
		}

		public IEnumerator<TValue> GetEnumerator() => new Enumerator<TValue>(this);
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		private Node<TValue> _iterate(Node<TValue> start, int count)
		{
			if (count > 0)
				start = _iterate(start.Next, --count);

			return start;
		}
	}
}