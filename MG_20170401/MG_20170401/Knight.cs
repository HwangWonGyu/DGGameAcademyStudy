using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG_20170401
{

	// Unit의 Base Class로 User가 필요한가?
	// 특정 카드 보유 현황, 경험치, 골드 보유 현황 등 때문에?
	class User
	{
		public int knightCard { get; set; }
		// 후에 47종류의 카드가 이런 식으로 하나씩 추가돼야하나...
		public int curExp { get; set; }
		// 경험치 보상 원리가 뭐지?
		public int curGold { get; set; }
		// 골드 보상 원리가 뭐지?
		public int curProduceCost { get; set; }
		// 시간이 지날수록 자동으로 증가해야됨

		public User()
		{

		}
	}

	class Knight
	{
		public int produceCost { get; set; }        // 생산비용
		public string rareness { get; set; }        // 희귀도
		public int[] levelUpCard;                   // 업그레이드 가능한 최소 카드 개수
													// 희귀도와 레벨에 따라 다름
		public int[] levelUpCost;                   // 업그레이드 비용
													// 희귀도와 레벨에 따라 다름
		public int level { get; set; }              // 레벨
		public int hp { get; set; }                 // HP
		public int dps { get; set; }                // Damage Per Second(초당 피해량)
		public int damage { get; set; }             // 피해량
		public double attackSpeed { get; set; }     // 공격속도
		public string ableAttackTarget { get; set; }// 공격대상
		public string moveSpeed { get; set; }       // 속도
		public double range { get; set; }           // 사정거리
		public int coolTime { get; set; }           // 배치시간
		public int positionX { get; set; }			// 위치 : x좌표
		public int positionY { get; set; }			// 위치 : y좌표
		public bool upGrade { get; set; }			// 업그레이드 가능 여부

		public Knight() : base()
		{
			level = 1;
			produceCost = 3;
			curProduceCost -= produceCost;
			rareness = "일반";
			hp = 960;
			dps = 109;
			damage = 120;
			attackSpeed = 1.1;
			ableAttackTarget = "지상";
			moveSpeed = "보통";
			range = 0;
			coolTime = 1;
			knightCard++;
			setUpgradeInfo();
		}

		private void setUpgradeInfo()
		{
			// -1 은 N/A
			if (rareness == "일반")
			{
				levelUpCard = new int[12] { 1, 2, 4, 10, 20, 50, 100, 200, 400, 800, 2000, 5000 };
				levelUpCost = new int[12] { -1, 5, 20, 50, 150, 400, 1000, 2000, 4000, 8000, 20000, 50000 };
			}
			else if (rareness == "희귀")
			{
				levelUpCard = new int[12] { 1, 2, 4, 10, 20, 50, 100, 200, 500, 1000, -1, -1 };
				levelUpCost = new int[12] { -1, 50, 150, 400, 1000, 2000, 4000, 8000, 20000, 50000, -1, -1 };
			}
			else if (rareness == "영웅")
			{
				levelUpCard = new int[12] { 1, 2, 4, 10, 20, 50, 100, 300, -1, -1, -1, -1 };
				levelUpCost = new int[12] { -1, 400, 1000, 2000, 4000, 8000, 20000, 50000, -1, -1, -1, -1 };
			}
			else if (rareness == "전설")
			{
				levelUpCard = new int[12] { 1, 2, 4, 10, 20, 50, -1, -1, -1, -1, -1, -1 };
				levelUpCost = new int[12] { -1, 5000, 20000, 50000, 100000, 250000, -1, -1, -1, -1, -1, -1 };
			}
		}

		public void Attack()
		{
			Console.WriteLine("기사가 공격했습니다. ({0})", damage);
		}

		public void Damaged(int damaged)
		{
			this.hp -= damaged;
			Console.WriteLine("데미지를 입었습니다. (-{0})", damaged);

			if (hp <= 0)
				Console.WriteLine("기사가 죽었습니다.");
		}

		public void Move(int x, int y)
		{
			this.positionX = x;
			this.positionY = y;
			Console.WriteLine("이동했습니다. " + this.positionX + ", " + this.positionY);
		}

		public void Upgrade()
		{
			// User의 Knight 카드 개수가 level에 따른 levelUpCard 이상일 경우와
			// User의 Gold가 level에 따른 levelUpCost 이상일 경우
			// upGrade를 true로 바꾼다
			if (base.knightCard >= levelUpCard[this.level - 1] &&
				base.curGold >= levelUpCost[this.level - 1])
				upGrade = true;

			if (upGrade)
			{
				this.level++;
				base.knightCard -= levelUpCard[this.level - 1];
				base.curGold -= levelUpCost[this.level - 1];
				upGrade = false;
				Console.WriteLine("업그레이드 완료.");
			}
			else
				Console.WriteLine("업그레이드 조건을 만족하지 못합니다.");
		}

		public void AddExp()
		{

		}

		public void AddGold()
		{

		}

	}
}
