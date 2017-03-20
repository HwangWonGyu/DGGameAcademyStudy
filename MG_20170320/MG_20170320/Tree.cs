using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG_20170320
{
	class BinaryTree
	{
		public int val;
		public BinaryTree leftchild;
		public BinaryTree rightchild;

		public BinaryTree()
		{
			leftchild = null;
			rightchild = null;
		}

		// 정말 필요한 생성자 인가?
		public BinaryTree(int _val)
		{
			val = _val;
			leftchild = null;
			rightchild = null;
			//Console.Write("{0} ",_val);
		}

		public void PreOrder(BinaryTree root)
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

		public void InOrder(BinaryTree root)
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

		public void PostOrder(BinaryTree root)
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
}
