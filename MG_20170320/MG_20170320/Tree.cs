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
		public HeapNode last;

		public Heap()
		{
			root = null;
			last = null;
		}

		public HeapNode GetRoot()
		{
			return root;
		}

		// Index없이 패턴으로 하는 방법
		public void Insert(int _key)
		{
			HeapNode hn = new HeapNode();
			hn.key = _key;

			// root조차 없는 경우
			if (root == null)
				root = hn;
			else
			{
				// root만 있는 경우, 마지막 Insert 위치를 last가 가리키게 함
				if (root.leftchild == null && last == null)
				{
					root.leftchild = hn;
					hn.parent = root;
					last = root.leftchild;
				}
				// root와 root의 leftchild만 있는 경우, rightchild를 넣어주면 됨
				else if (root.rightchild == null && last != null)
				{
					root.rightchild = hn;
					hn.parent = root;
					last = root.rightchild;
				}
				else
				{
					HeapNode i;
					for (i = last; i != root && i == i.parent.rightchild; i = i.parent) ;

					// i가 root일땐 root.parent도 없으므로 그 경우를 제외하고 i를 parent로 옮김
					if (i != root)
					{
						i = i.parent;
						if (i.rightchild != null)
						// rightchild가 이미 있다면 이를 기준으로 가장 왼쪽에 넣어야 함
						// 이는 last가 어떤 parent의 rightchild에 있을 경우에 해당됨
						{
							i = i.rightchild;

							for (; i.leftchild != null; i = i.leftchild) ;

							i.leftchild = hn;
							hn.parent = i;
							last = i.leftchild;
						}
						else
						// rightchild가 비어있다면 그 자리에 새 Node를 넣어주고 걔를 last가 가리키게 함
						// 이는 last가 어떤 parent의 leftchild에 있을 경우에 해당됨
						{
							i.rightchild = hn;
							hn.parent = i;
							last = i.rightchild;
						}
					}
					else // i == root
					// 그냥 root에서 leftchild 계속 내려가서 맨 왼쪽에 달면 됨
					{
						for (; i.leftchild != null; i = i.leftchild) ;

						i.leftchild = hn;
						hn.parent = i;
						last = i.leftchild;
					}
				}
			}
		}

		public void Delete()
		{
			//root조차 없는 경우
			if (root == null)
			{
				Console.WriteLine("머리가 텅 빔");
			}
			else
			{
				// root만 있는 경우
				if (root.leftchild == null)
				{
					root = null;
					last = null;
				}
				// root와 root의 leftchild만 있는 경우, leftchild를 빼면 됨
				else if (root.rightchild == null && last != null)
				{
					root.leftchild.parent = null;
					root.leftchild = null;
					last = root;
				}
				else
				{
					// 빼려고 하는게 어떤 parent의 rightchild라면
					// 빼고나서 last를 leftchild로 옮겨줌
					if (last == last.parent.rightchild)
					{
						last = last.parent.leftchild;
						last.parent.rightchild = null;
					}
					// 빼려고 하는게 어떤 parent의 leftchild라면 두가지 경우를 고려
					// 하나는 맨 밑의 왼쪽을 빼서 last가 바로 위 레벨의 맨 오른쪽으로 갈때
					// 다른 하나는 방향 바뀔때까지 올라가서 last 설정
					else
					{
						HeapNode i = last.parent;
						last.parent.leftchild = null;
						for (; i != root && i == i.parent.leftchild; i = i.parent) ;

						if (i != root)
						{
							i = i.parent;
							i = i.leftchild;
						}
						
						for (; i.rightchild != null; i = i.rightchild) ;

						last = i;
					}
				}
			}
		}

		public void PreOrder(HeapNode root)
		{
			// root 먼저 들렀다가
			Console.WriteLine(root.key);
			// left
			if (root.leftchild != null)
				PreOrder(root.leftchild);
			// right 순
			if (root.rightchild != null)
				PreOrder(root.rightchild);
		}

		public void InOrder(HeapNode root)
		{
			// left 먼저 들렀다가
			if (root.leftchild != null)
				InOrder(root.leftchild);
			// root
			Console.WriteLine(root.key);
			// right 순
			if (root.rightchild != null)
				InOrder(root.rightchild);
		}

		public void PostOrder(HeapNode root)
		{
			// left 먼저 들렀다가
			if (root.leftchild != null)
				PostOrder(root.leftchild);
			// right
			if (root.rightchild != null)
				PostOrder(root.rightchild);
			// root 순
			Console.WriteLine(root.key);
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
