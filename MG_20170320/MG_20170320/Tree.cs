using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG_20170320
{
	class BinaryTreeNode
	{
		public int val;
		public BinaryTreeNode leftchild;
		public BinaryTreeNode rightchild;
	}

	class BinaryTree
	{
		public BinaryTreeNode root;

		public BinaryTree()
		{
			root = null;
		}

		public void SetRoot(BinaryTreeNode temp)
		{
			root = temp;
		}

		public void PreOrder(BinaryTreeNode root)
		{
			// root 먼저 들렀다가
			Console.WriteLine(root.val);
			// left
			if (root.leftchild != null)
				PreOrder(root.leftchild);
			// right 순
			if (root.rightchild != null)
				PreOrder(root.rightchild);
		}

		public void InOrder(BinaryTreeNode root)
		{
			// left 먼저 들렀다가
			if (root.leftchild != null)
				InOrder(root.leftchild);
			// root
			Console.WriteLine(root.val);
			// right 순
			if (root.rightchild != null)
				InOrder(root.rightchild);
		}

		public void PostOrder(BinaryTreeNode root)
		{
			// left 먼저 들렀다가
			if (root.leftchild != null)
				PostOrder(root.leftchild);
			// right
			if (root.rightchild != null)
				PostOrder(root.rightchild);
			// root 순
			Console.WriteLine(root.val);
		}
	}

	// 클래스 추가하거나 구조를 바꿔야 할 수도 있음
	class Calculator
	{
		public string key;
		public Calculator leftchild;
		public Calculator rightchild;

		public Calculator()
		{
			key = null;
			leftchild = null;
			rightchild = null;
		}

		// 정말 필요한 생성자 인가?
		public Calculator(string _key)
		{
			key = _key;
			leftchild = null;
			rightchild = null;
		}

		public void PostOrderInsert(Calculator root, string str)
		{
			// InOrder 방식으로 Insert 하는 것 같다

			// left 먼저 들렀다가
			if (root.rightchild != null && root.leftchild.key == null)
			{
				PostOrderInsert(root.leftchild, str);
			}
			// root
			root.key = str;
			// right 순
			if (root.rightchild != null && root.rightchild.key == null)
			{
				PostOrderInsert(root.rightchild, str);
			}
		}

		public void PostOrder(Calculator root)
		{
			// left 먼저 들렀다가
			if (root.leftchild != null)
			{
				Console.Write("left ");
				PostOrder(root.leftchild);
			}
			// right
			if (root.rightchild != null)
			{
				Console.Write("right ");
				PostOrder(root.rightchild);
			}
			// root 순
			Console.WriteLine(root.key);
			if (root.leftchild != null && root.rightchild != null)
			{
				int temp = 0;

				if (root.key == "*")
					temp = Convert.ToInt32(root.leftchild.key) * Convert.ToInt32(root.rightchild.key);
				else if (root.key == "/") // 나눗셈이니까 double로 할까?
					temp = Convert.ToInt32(root.leftchild.key) / Convert.ToInt32(root.rightchild.key);
				else if (root.key == "+")
					temp = Convert.ToInt32(root.leftchild.key) + Convert.ToInt32(root.rightchild.key);
				else if (root.key == "-")
					temp = Convert.ToInt32(root.leftchild.key) - Convert.ToInt32(root.rightchild.key);

				Console.WriteLine("=" + temp);
				root.key = Convert.ToString(temp);
				//Console.WriteLine("=" + root.key);
			}
		}
	}

	class Heap
	{
		public HeapNode root;
		public HeapNode dummy;

		public Heap()
		{
			root = null;
			dummy = null;
		}

		// Index없이 패턴으로 하는 방법
		public void Insert(int _key)
		{
			HeapNode hn = new HeapNode();
			hn.key = _key;

			// Root조차 없는 경우
			if (root == null)
				root = hn;
			else
			{
				// Root만 있는 경우, 마지막 Insert 위치를 dummy가 가리키게 함
				if (root.leftchild == null && dummy == null)
				{
					root.leftchild = hn;
					root.leftchild.parent = root;
					dummy = root.leftchild;
				}
				// dummy가 무언가를 가리키고 있을 때 (이는 Root 이외의 노드가 있다는 말)
				else if(dummy != null)
				{
					HeapNode i;
					for (i = dummy; i == i.parent.rightchild; i = i.parent);

					i = i.parent;
					if (i.rightchild != null)
					// rightchild가 이미 있다면 이를 기준으로 가장 왼쪽에 넣어야 함
					{
						i = i.rightchild;

						for (; i.leftchild != null; i = i.leftchild) ;

						i.leftchild = hn;
						hn.parent = i.leftchild;
						dummy = i.leftchild;
					}
					else
					// rightchild가 비어있다면 그 자리에 새 Node를 넣어주고 걔를 dummy가 가리키게 함
					{
						i.rightchild = hn;
						hn.parent = i;
						dummy = i.rightchild;
					}
				}
			}
		}

		public void Delete()
		{

		}
	}

	class HeapNode
	{
		public int key;
		public HeapNode parent;
		public HeapNode leftchild;
		public HeapNode rightchild;

		public HeapNode()
		{
			parent = null;
			leftchild = null;
			rightchild = null;
		}
	}
}
