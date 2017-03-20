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
			////Node 생성
			//BinaryTree tmp1 = new BinaryTree(1); // root
			//BinaryTree tmp2 = new BinaryTree(2);
			//BinaryTree tmp3 = new BinaryTree(3);
			//BinaryTree tmp4 = new BinaryTree(4);
			//BinaryTree tmp5 = new BinaryTree(5);
			//BinaryTree tmp6 = new BinaryTree(6);
			//BinaryTree tmp7 = new BinaryTree(7);
			//BinaryTree tmp8 = new BinaryTree(8);
			//BinaryTree tmp9= new BinaryTree(9);
			//BinaryTree tmp10 = new BinaryTree(10);
			//BinaryTree tmp11 = new BinaryTree(11);

			////Tree를 만들기 위해 Node 간의 관계 설정
			//tmp1.leftchild = tmp2;
			//tmp1.rightchild = tmp3;
			//tmp2.leftchild = tmp4;
			//tmp2.rightchild = tmp5;
			//tmp3.leftchild = tmp6;
			//tmp3.rightchild = tmp7;
			//tmp4.leftchild = tmp8;
			//tmp4.rightchild = tmp9;
			//tmp5.leftchild = tmp10;
			//tmp5.rightchild = tmp11;

			////각 Order 방식으로 Console에 출력
			//tmp1.PreOrder(tmp1);
			//tmp1.InOrder(tmp1);
			//tmp1.PostOrder(tmp1);


			//수식 입력
			String tmp;
			tmp = Console.ReadLine();

			//Tree를 만들기 위해 Node 간의 관계 설정
			//자동으로 돼야함
			//아래는 올바른 Class 객체 생성 방법
			//결국 생성자를 호출해주지 않으면 아직 null
			Calculator[] cal = new Calculator[tmp.Length];
			for (int i = 0; i < cal.Length; i++)
				cal[i] = new Calculator();
			////아래처럼 푸는게 아니다...
			//for (int i = 0; i < cal.Length / 2; i++)
			//{
			//	cal[i].leftchild = cal[i * 2 + 1];
			//	cal[i].rightchild = cal[i * 2 + 2];
			//}
			//// Infix를 Postfix로 바꾼 다음 Tree에 넣어야됨

		}
	}
}
