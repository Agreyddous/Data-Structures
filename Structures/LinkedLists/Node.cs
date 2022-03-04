namespace DataStructures.Structures.LinkedLists
{
	public class Node<TValue>
	{
		public Node(TValue value, Node<TValue> next = null, Node<TValue> previous = null)
		{
			Value = value;
			Next = next;
			Previous = previous;
		}

		public TValue Value { get; set; }

		public Node<TValue> Next { get; private set; }
		public Node<TValue> Previous { get; private set; }

		public void Update(Node<TValue> next, Node<TValue> previous)
		{
			UpdateNext(next);
			UpdatePrevious(previous);
		}

		public void UpdateNext(Node<TValue> next) => Next = next;
		public void UpdatePrevious(Node<TValue> previous) => Previous = previous;
	}
}