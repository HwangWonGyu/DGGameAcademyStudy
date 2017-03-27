using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG_20170327
{
	class BinarySearchTreeNode
	{
		public int val;
		public BinarySearchTreeNode left;
		public BinarySearchTreeNode right;

		public BinarySearchTreeNode()
		{
			left = null;
			right = null;
		}

		public BinarySearchTreeNode(int _val)
		{
			val = _val;
			left = null;
			right = null;
		}
	}

	class BinarySearchTree
	{
		public BinarySearchTreeNode root;

		public BinarySearchTree()
		{
			root = null;
		}

		public void Insert(int n)
		{
			BinarySearchTreeNode temp = new BinarySearchTreeNode(n);

			if (root == null)
			{
				root = temp;
			}
			else // root != null
			{
				BinarySearchTreeNode search = root;
				while (true)
				{
					if (temp.val == search.val)
					{
						Console.WriteLine("이미 있는 값입니다.");
						break;
					}
					else if (temp.val < search.val)
					{
						if (search.left != null)
							search = search.left;
						else // search.left == null
						{
							search.left = temp;
							break;
						}
					}
					else if (search.val < temp.val)
					{
						if (search.right != null)
							search = search.right;
						else // search.right == null
						{
							search.right = temp;
							break;
						}
					}
				}
			}
		}

		public void Delete(int n)
		{
			BinarySearchTreeNode deleteParent;
			BinarySearchTreeNode maxChildParent;

			// Search로 #1 '삭제할 위치'를 찾고
			// 그 위치를 기준으로 왼쪽 자식들 중 가장 큰 자식을 올림
			// 만약 왼쪽 자식들이 없다면 오른쪽 자식들 중 가장 작은 자식을 올림
			// 자식을 올리려면 #2 '삭제할 위치의 부모의 위치'를 알아야 됨
			// 이후 #3-1 '왼쪽 자식들 중 가장 큰 자식의 부모의 위치'를 알고 있어야 하거나
			// 만약 왼쪽 자식들이 없다면 #3-2 '오른쪽 자식들 중 가장 작은 자식의 부모의 위치'를 알아야 됨

		}

		public void Search(int n)
		{
			if (root == null)
			{
				Console.WriteLine("못찾았습니다.");
			}
			else // root != null
			{
				BinarySearchTreeNode search = root;
				while (true)
				{
					if (n == search.val)
					{
						Console.WriteLine("찾았습니다.");
						break;
					}
					else if (n < search.val)
					{
						if (search.left != null)
							search = search.left;
						else // search.left == null
						{
							Console.WriteLine("못찾았습니다.");
							break;
						}
					}
					else if (search.val < n)
					{
						if (search.right != null)
							search = search.right;
						else // search.right == null
						{
							Console.WriteLine("못찾았습니다.");
							break;
						}
					}
				}
			}
		}
	}
}
