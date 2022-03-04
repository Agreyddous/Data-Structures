using System;

namespace DataStructures.Structures.Trees
{
	public class Node<TValue>
	{
		public Node(TValue value, Node<TValue> left = null, Node<TValue> right = null)
		{
			Value = value;
			Left = left;
			Right = right;
		}

		public TValue Value { get; private set; }

		public Node<TValue> Left { get; private set; }
		public Node<TValue> Right { get; private set; }

		public int NodesCount => _nodesCount();
		public int Depth => _depth();

		public bool IsFull => _isFull();
		public bool IsComplete => _isComplete(this, 0, NodesCount);
		public bool IsPerfect => _isPerfect(this, Depth, 0);
		public bool IsBalanced { get { int height = 0; return _isBalanced(this, ref height); } }
		public bool IsDegenerate => _isDegenerate();

		public bool IsLeaf => Left == null && Right == null;

		public void Update(Node<TValue> left, Node<TValue> right)
		{
			UpdateLeft(left);
			UpdateRight(right);
		}

		public void UpdateLeft(Node<TValue> left) => Left = left;
		public void UpdateRight(Node<TValue> right) => Right = right;

		private int _nodesCount() => 1 + (Left?.NodesCount ?? 0) + (Right?.NodesCount ?? 0);

		private int _depth() => 1 + Math.Max(Left?.Depth ?? 0, Right?.Depth ?? 0);

		private bool _isFull()
		{
			bool full = false;

			if (IsLeaf)
				full = true;

			else if (Left != null && Right != null)
				full = Left.IsFull && Right.IsFull;

			return full;
		}

		private bool _isComplete(Node<TValue> head, int index, int nodesCount)
		{
			bool complete = false;

			if (head == null)
				complete = true;

			else if (index < nodesCount)
				complete = _isComplete(Left, 2 * index + 1, nodesCount) && _isComplete(Right, 2 * index + 2, nodesCount);

			return complete;
		}

		private bool _isPerfect(Node<TValue> head, int depth, int level)
		{
			bool perfect = false;

			if (head == null)
				perfect = true;

			if (IsLeaf)
				perfect = depth == level + 1;

			else if (Left != null && Right != null)
				perfect = _isPerfect(Left, depth, level + 1) && _isPerfect(Right, depth, level + 1);

			return perfect;
		}

		private bool _isBalanced(Node<TValue> head, ref int height)
		{
			bool balanced = false;

			if (head == null)
			{
				height = 0;
				balanced = true;
			}

			else
			{
				int leftHeight = 0;
				int rightHeight = 0;

				bool leftBalanced = _isBalanced(head.Left, ref leftHeight);
				bool rightBalanced = _isBalanced(head.Right, ref rightHeight);

				height = (leftHeight > rightHeight ? leftHeight : rightHeight) + 1;

				if (Math.Abs(leftHeight - rightHeight) < 2)
					balanced = leftBalanced && rightBalanced;
			}

			return balanced;
		}

		private bool _isDegenerate()
		{
			bool degenerate = false;

			if (IsLeaf)
				degenerate = true;

			else if (Left == null && Right != null)
				degenerate = Right.IsDegenerate;

			else if (Left != null && Right == null)
				degenerate = Left.IsDegenerate;

			return degenerate;
		}
	}
}