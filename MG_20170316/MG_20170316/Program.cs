using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG_20170316
{
	class SinglyNode
	{
		public int val;
		public SinglyNode next;

		public SinglyNode(int _val)
		{
			val = _val;
			next = null;
		}
	}

	class SinglyLinkedListStack
	{

		SinglyNode head;
		SinglyNode top;
		SinglyNode cur;
			
		public SinglyLinkedListStack()
		{
			head = null;
			top = null;
			cur = null;
			// cur도 null로 해주는게 좋은건가?
		}

		public void Push(int val)
		{
			// 아직 아무값도 없으면 head, top이 그 노드를 가리키게 함
			if (head == null)
			{
				SinglyNode tmp = new SinglyNode(val);

				head = tmp;
				top = tmp;
			}
			// head에 값이 있다면 새 노드를 top.next에 연결하고 top이 새 노드를 가리킴
			else if (head != null)
			{
				SinglyNode tmp = new SinglyNode(val);

				top.next = tmp;
				top = tmp;
			}
		}

		public SinglyNode Pop()
		{
			// i) 아무것도 없으면 안뺌
			// ii) 하나만 있으면 걔를 빼고 head, top을 null로
			// iii) 둘 이상 있으면 top은 cur이 가리키는걸 가리키게 하고
			// cur.next가 top일때까지 찾아 그곳에 cur를 위치시킨 다음
			// top.next를 return해줌
			if (head == null)
			{
				Console.WriteLine("머리가 텅 빔");

				return null;
			}
			else
			{
				if(head == top)
				{
					SinglyNode tmp = new SinglyNode(top.val);

					head = null;
					top = null;
					return tmp;
				}
				else // (head != top)
				{
					SinglyNode tmp = top;
					for (SinglyNode i = head; i != top; i = i.next)
					{
						if (i.next == top)
							cur = i;
					}
					top = cur;
					return tmp;
				}
			}
		}

	}

	class DoublyNode
	{
		public int val;
		public DoublyNode prev;
		public DoublyNode next;

		public DoublyNode(int _val)
		{
			val = _val;
			prev = null;
			next = null;
		}
	}

	class DoublyLinkedListStack
	{

		DoublyNode head;
		DoublyNode top;

		public DoublyLinkedListStack()
		{
			head = null;
			top = null;
		}

		public void Push(int val)
		{
			if(head == null)
			{
				DoublyNode tmp = new DoublyNode(val);

				head = tmp;
				top = tmp;
			}
			else // head != null
			{
				if(top.prev == null && top.next == null)
				{
					DoublyNode tmp = new DoublyNode(val);

					top = tmp;
					head.next = top;
					top.prev = head;
				}
				else
				{
					DoublyNode tmp = new DoublyNode(val);

					top.next = tmp;
					tmp.prev = top;
					top = tmp;
				}
			}
		}

		public DoublyNode Pop()
		{
			if(head == null)
			{
				Console.WriteLine("머리가 텅 빔");

				return null;
			}
			else
			{
				if (head == top)
				{
					DoublyNode tmp = new DoublyNode(top.val);

					head = null;
					top = null;

					return tmp;
				}
				else // (head != top)
				{
					DoublyNode tmp = top;

					top = tmp.prev;
					tmp.prev = null;
					top.next = null;

					return tmp;
				}
			}
		}
	}

	class InsertionSortLinkedList
	{
		public SinglyNode head;
		public SinglyNode top;
		public SinglyNode cur;

		public InsertionSortLinkedList()
		{
			head = null;
			top = null;
			cur = null;
		}

		public void Push(int val)
		{
			if(head == null)
			{
				SinglyNode tmp = new SinglyNode(val);

				head = tmp;
				top = tmp;
			}
			else // head != null
			{
				if(head == top)
				{
					SinglyNode tmp = new SinglyNode(val);

					if (top.val < val)
					{
						top.next = tmp;
						top = tmp;
					}
					else
					{
						tmp.next = top;
						head = tmp;
					}
				}
				else // head != top
				{
					SinglyNode tmp = new SinglyNode(val);

					if (head.val >= val)
					{
						tmp.next = head;
						head = tmp;
					}
					else if (top.val <= val)
					{
						top.next = tmp;
						top = tmp;
					}
					else if (head.val < val && top.val > val)
					{
						SinglyNode i;
						for (i = head.next, cur = head; i != top.next; i = i.next)
						{
							if (i.val >= val)
							{
								tmp.next = i;
								cur.next = tmp;
								break;
							}
							cur = i;
						}
					}
				}
			}
		}

		public SinglyNode Pop()
		{
			if (head == null)
			{
				Console.WriteLine("머리가 텅 빔");

				return null;
			}
			else
			{
				if (head == top)
				{
					SinglyNode tmp = new SinglyNode(top.val);

					head = null;
					top = null;
					return tmp;
				}
				else // (head != top)
				{
					SinglyNode tmp = top;
					SinglyNode i;
					for (i = head; i.next != top; i = i.next) ;

					top = i;
					return tmp;
				}
			}
		}
	}
}
