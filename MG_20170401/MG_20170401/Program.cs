using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG_20170401
{

	class Program
	{
		static void Main(string[] args)
		{
			Knight knight1 = new Knight();

			knight1.Attack();
			// 초당 공격을 구현할 수 있지 않을까?
			knight1.Move(3, 5);
			knight1.Attack();
			knight1.Damaged(100);
			knight1.Upgrade();
			knight1.Upgrade();
			knight1.knightCard = 100;
			knight1.curGold = 5000;
			knight1.Upgrade();
		}
	}
}
