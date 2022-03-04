using System.Collections;

namespace DataStructures.Structures
{
	public class ArrayStructure : IEnumerable
	{
		private int[] _data;

		public ArrayStructure(int size) => _data = new int[size];

		public int Length => _data.Length;

		public IEnumerator GetEnumerator() => _data.GetEnumerator();

		public int this[int index]
		{
			get => _data[index];
			set => _data[index] = value;
		}
	}
}