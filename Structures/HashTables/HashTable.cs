namespace DataStructures.Structures.HashTables
{
	public class HashTable<TValue>
	{
		private TValue[] _data;

		public HashTable(int size)
		{
			size = _resolveSize();

			_data = new TValue[size];
		}

		private int _resolveSize(int size)
		{

		}

		private bool _isPrimeNumber(int number)
		{
			bool result = true;

			if (number <= 1) result = false;
			if (number <= 3) result = true;

			if (number % 2 == 0 || number % 3 == 0)
				result = false;

			for (int index = 5; index * index <= number; index += 6)
				if (number % index == 0 || number % (index + 2) == 0)
					result = false;

			return result;
		}
	}
}