using SpartaDungeon;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
	enum Difficulty
	{
		None,
		Easy,
		Normal,
		Hard
	}
	internal class DungeonScene : BaseScene
	{
		Random random = new Random();
		float recommendDefense = 0f;
		int reward = 0;
		float currentAttack = 0f;
		float currentDefense = 0f;
		float currentHealth = 0f;
		Difficulty currentDifficulty;

		public override void EnterScene()
		{
			InitCurrentStatus();

			while (true)
			{
				SceneUtility.WriteTitle("던전 입구");

				Console.WriteLine("경비병들을 지나 던전의 입구에 도착하자, 으스스한 기운이 당신을 감쌉니다.");
				SceneUtility.SetCursor();
				Console.WriteLine("입구는 세 개가 있으며, 문의 크기가 클수록 어려운 곳이라고 합니다 ");
				SceneUtility.SetCursor();
				Console.WriteLine("어디로 가시겠습니까?\n");
				SceneUtility.SetCursor();

				Console.WriteLine("1: 쉬운 던전으로 (권장 방어력 : 5)");
				SceneUtility.SetCursor();
				Console.WriteLine("2: 보통 던전으로 (권장 방어력 : 10)");
				SceneUtility.SetCursor();
				Console.WriteLine("3: 어려운 던전으로 (권장 방어력 : 20");
				SceneUtility.SetCursor();
				Console.WriteLine("0: 돌아가기");
				SceneUtility.SetCursor();

				Console.Write(">> ");
				string? input = Console.ReadLine();
				int num;
				if (int.TryParse(input, out num))
				{
					if (num == 1)
					{
						currentDifficulty = Difficulty.Easy;
						SetDifficulty(currentDifficulty);
						EnterDungeon();
						break;
					}
					else if (num == 2)
					{
						currentDifficulty = Difficulty.Normal;
						SetDifficulty(currentDifficulty);
						EnterDungeon();
						break;
					}
					else if (num == 3)
					{
						currentDifficulty = Difficulty.Hard;
						SetDifficulty(currentDifficulty);
						EnterDungeon();
						break;
					}
					else if (num == 0)
					{
						nextState = beforeState;
						break;
					}
				}
			}
		}

		public override State ExitScene()
		{
			return nextState;
		}

		private void EnterDungeon()
		{
			PrintDungeonMessage(currentDifficulty);

			// 권장 방어력 미만 실패 계산
			if (currentDefense < recommendDefense)
			{
				if(random.Next(0,10) < 4)
				{
					Fail();
					return;
				}
			}
			float minDamage = 20 - (currentDefense - recommendDefense);
			float maxDamage = 35 - (currentDefense - recommendDefense);
			float damage = random.Next((int)minDamage, (int)maxDamage);
			// 체력 0 이하로 인한 사망 계산
			if (currentHealth < damage)
			{
				Die();
				return;
			}
			// 던전 클리어
			PrintClearMessage(currentDifficulty, damage);
			// 보상 정산 후 던전 입구로 돌아가기
			WriteProgress("잠시 후, 던전 입구로 돌아갑니다.");
			WriteProgress("");
			WriteProgress("");
			EnterScene();
		}

		private void SetDifficulty(Difficulty difficulty)
		{
			switch(difficulty)
			{
				case Difficulty.Easy:
					{
						recommendDefense = 5;
						reward = 1000;
						break;
					}
				case Difficulty.Normal:
					{
						recommendDefense = 10;
						reward = 1700;
						break;
					}
				case Difficulty.Hard:
					{
						recommendDefense = 20;
						reward = 2500;
						break;
					}
			}
		}

		private void InitCurrentStatus()
		{
			currentAttack = Player.GetStatus(Status.Attack);
			currentHealth = Player.GetStatus(Status.Health);
			currentDefense = Player.GetStatus(Status.Defense);
		}

		private void Fail()
		{
			Console.WriteLine("당신은 강한 몬스터를 잡지 못하고 도망쳤습니다.");
			SceneUtility.SetCursor();
			Console.WriteLine("몬스터와의 싸움에서 상처를 입어, 체력이 감소했습니다.");
			SceneUtility.SetCursor();
			Console.WriteLine("잠시 후, 던전 입구로 돌아갑니다.");
			SceneUtility.SetCursor();
			Thread.Sleep(2000);
			Player.Recovery(currentHealth / -2);
			EnterScene();
		}

		void PrintDungeonMessage(Difficulty difficulty)
		{
			string title = "";
			switch(difficulty)
			{
				case Difficulty.Easy:
					title = "쉬운 던전";
					break;
				case Difficulty.Normal:
					title = "보통 던전";
					break;
				case Difficulty.Hard:
					title = "어려운 던전";
					break;
			}

			SceneUtility.WriteTitle(title);

			Console.WriteLine($"당신은 {title}에 입장했습니다.");
			SceneUtility.SetCursor();
			WriteProgress("던전 안쪽을 향해 걸어가는 중");
			WriteProgress("몬스터와 조우해서 싸우는 중");
		}

		void WriteProgress(string action)
		{
			Console.Write(action);
			for(int i =0; i < 5; i++)
			{
				Console.Write('.');
				Thread.Sleep(100);
			}
			Console.WriteLine();
			SceneUtility.SetCursor();
		}

		void Die()
		{
			Console.WriteLine("당신은 죽었습니다.");
			SceneUtility.SetCursor();
			Console.WriteLine("잠시 후, 게임이 종료됩니다.");
			SceneUtility.SetCursor();
			Thread.Sleep(2000);
			nextState = State.None;
		}

		void PrintClearMessage(Difficulty difficulty, float damage)
		{
			string title = "";
			switch (difficulty)
			{
				case Difficulty.Easy:
					title = "쉬운 던전";
					break;
				case Difficulty.Normal:
					title = "보통 던전";
					break;
				case Difficulty.Hard:
					title = " 어려운 던전";
					break;
			}

			SceneUtility.WriteTitle("쉬운 던전");

			Console.WriteLine($"당신은 {title}의 모든 몬스터를 사냥했습니다.");
			SceneUtility.SetCursor();
			WriteProgress("보물이 있는 방으로 가는 중");
			WriteProgress("보물 상자를 확인하는 중");

			SceneUtility.WriteTitle("던전 클리어");
			Console.WriteLine($"축하합니다! 당신은 {title}을 클리어했습니다.\n");
			SceneUtility.SetCursor();

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("[탐험 결과]");
			SceneUtility.SetCursor();
			Console.ResetColor();

			Console.WriteLine($"체력 : {currentHealth} -> {currentHealth - damage}");
			SceneUtility.SetCursor();
			Player.Recovery(-1 * damage);

			int bonus = random.Next((int)currentAttack, (int)(currentAttack * 2));
			int currentReward = reward / 100 * (100 + bonus);
			Console.WriteLine($"Gold : {Player.GetMoney()} G -> {Player.GetMoney() + currentReward} G");
			SceneUtility.SetCursor();
			Player.SetMoney(currentReward);
		}
	}
}
