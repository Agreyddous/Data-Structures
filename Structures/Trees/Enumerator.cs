using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Structures.Trees
{
	public class Enumerator<TValue> : IEnumerator<TValue>
	{
		public Enumerator(BinaryTree<TValue> binaryTree)
		{

		}

		public TValue Current => throw new System.NotImplementedException();

		object IEnumerator.Current => throw new System.NotImplementedException();

		public void Dispose()
		{
			throw new System.NotImplementedException();
		}

		public bool MoveNext()
		{
			throw new System.NotImplementedException();
		}

		public void Reset()
		{
			throw new System.NotImplementedException();
		}
	}
}