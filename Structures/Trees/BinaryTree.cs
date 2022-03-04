using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Structures.Trees
{
	public class BinaryTree<TValue> : IEnumerable<TValue>
	{
		public BinaryTree(TValue headValue) => Head = new Node<TValue>(headValue);

		public Node<TValue> Head { get; private set; }

		public bool IsFull => Head.IsFull;

		public IEnumerator<TValue> GetEnumerator() => new Enumerator<TValue>(this);
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}