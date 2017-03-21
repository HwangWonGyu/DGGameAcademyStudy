using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG_20170320
{
	class MainProgram
	{
		static void Main(string[] args)
		{
			////BinaryTree, Node 생성
			//BinaryTree binarytree = new BinaryTree();
			//BinaryTreeNode[] binarytreenode = new BinaryTreeNode[11];
			//for(int i = 0; i < binarytreenode.Length; i++)
			//{
			//	binarytreenode[i] = new BinaryTreeNode();
			//	binarytreenode[i].val = i;
			//}

			////Tree를 만들기 위해 Node 간의 관계를 임의로 설정
			//for (int i = 0; i < binarytreenode.Length / 2; i++)
			//{
			////이렇게 하면 Full and Completely Binary Tree가 됨
			//	binarytreenode[i].leftchild = binarytreenode[i * 2 + 1];
			//	if(binarytreenode.Length % 2 == 1)
			//		binarytreenode[i].rightchild = binarytreenode[i * 2 + 2];
			//}

			////Root 설정
			//binarytree.SetRoot(binarytreenode[0]);

			////각 Order 방식으로 Console에 출력
			//binarytree.PreOrder(binarytree.root);
			//binarytree.InOrder(binarytree.root);
			//binarytree.PostOrder(binarytree.root);



			////수식 입력
			//String tmp;
			//tmp = Console.ReadLine();

			////Tree를 만들기 위해 Node 간의 관계 설정
			////자동으로 돼야함
			////아래는 올바른 Class 객체 생성 방법
			////결국 생성자를 호출해주지 않으면 아직 null
			//Calculator[] cal = new Calculator[tmp.Length];
			//for (int i = 0; i < cal.Length; i++)
			//	cal[i] = new Calculator();
			////아래처럼 푸는게 아니다...
			//for (int i = 0; i < cal.Length / 2; i++)
			//{
			//	cal[i].leftchild = cal[i * 2 + 1];
			//	cal[i].rightchild = cal[i * 2 + 2];
			//}
			//// Infix를 Postfix로 바꾼 다음 Tree에 넣어야됨, Stack 2개 이용(In, Post)



			// Heap, Node 생성
			Heap heap = new Heap();
			

			// Node 간의 관계 설정
			

			// Insert는 각 Node들을 저장해둔 배열의 Index를 이용?
			// Insert할 위치의 (Index - 1) / 2 하면 부모 Index 나옴
		}
	}
}
