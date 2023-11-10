using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
	/// <summary>
	/// MiniScene : BlackSmith, Potion, Inn
	/// </summary>
	internal class ShopScene : BaseScene
	{
		BlackSmith blackSmith = new BlackSmith();
		public override void EnterScene()
		{
			while (true)
			{
				SceneUtility.WriteTitle("상점가");

				Console.WriteLine("스파르타 마을의 상점가입니다.");
				SceneUtility.SetCursor();
				Console.WriteLine("바로 앞 굴뚝에서 연기가 나오는 건물은 연금술사의 물약 상점이, 맞은편에는 대장간이 보입니다.");
				SceneUtility.SetCursor();
				Console.WriteLine("상점가에서 조금 떨어져 있는 곳에는 여관이 보입니다.");
				SceneUtility.SetCursor();
				Console.WriteLine("어디로 가시겠습니까?\n");
				SceneUtility.SetCursor();

				Console.WriteLine("1: 여관으로");
				SceneUtility.SetCursor();
				Console.WriteLine("2: 대장간으로");
				SceneUtility.SetCursor();
				Console.WriteLine("3: 물약 상점으로");
				SceneUtility.SetCursor();
				Console.WriteLine("0: 뒤로 가기");
				SceneUtility.SetCursor();

				Console.Write(">> ");
				string? input = Console.ReadLine();
				int num;
				if (int.TryParse(input, out num))
				{
					if (num == 1)
					{
						InnScene();
						break;
					}
					else if (num == 2)
					{
						BlackSmithMainScene();
						break;
					}
					else if (num == 3)
					{
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

		private void BlackSmithMainScene()
		{
			while (true)
			{
				SceneUtility.WriteTitle("대장간");

				Console.WriteLine("대장간에 발을 들이자, 대장간 특유의 열기와 쇳물 냄새가 당신을 반깁니다.");
				SceneUtility.SetCursor();
				Console.WriteLine("수염이 덥수룩한 노인은 당신이 온 것을 아는지 모르는지, 작업에 열중하고 있습니다.");
				SceneUtility.SetCursor();
				Console.WriteLine("하지만 손님을 냉대하진 않겠지요. 먼저 말을 걸면 될 겁니다.");
				SceneUtility.SetCursor();
				Console.WriteLine("어떻게 하시겠습니까?\n");
				SceneUtility.SetCursor();

				Console.WriteLine("1: 장비를 구매한다.");
				SceneUtility.SetCursor();
				Console.WriteLine("2: 장비를 판매한다.");
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
						// 장비 구매씬으로
						BlackSmithBuyScene();
						break;
					}
					else if (num == 2)
					{
						// 장비 판매씬으로
						BlackSmithSellScene();
						break;
					}
					else if (num == 0)
					{
						EnterScene();
						break;
					}
				}
			}
		}

		private void BlackSmithBuyScene()
		{
			BlackSmithBuyInit();
			while (true)
			{
				SceneUtility.WriteTitle("장비 구매");
				blackSmith.SaleScene();

				SceneUtility.SetCursor();
				Console.WriteLine("0: 돌아가기");
				SceneUtility.SetCursor();
				Console.WriteLine($"현재 소지금 : {Player.GetMoney()}");
				SceneUtility.SetCursor();
				Console.WriteLine("장비를 구매하시려면 목록에 해당하는 숫자를 입력해주세요.");
				SceneUtility.SetCursor();
				Console.Write(">> ");
				string? input = Console.ReadLine();
				int num;
				if (int.TryParse(input, out num))
				{
					// 0을 제외한 숫자가 "유효할 시" 판매 리스트의 Count를 받아서 연결
					if (num == 0)
					{
						BlackSmithMainScene();
						break;
					}
					else if(num <= blackSmith.GetListCount())
					{
						blackSmith.SellItem(num);
						continue;
					}
				}
			}
		}
		private void BlackSmithSellScene()
		{
			BlackSmithSellInit();
			while (true)
			{
				SceneUtility.WriteTitle("장비 판매");

				Inventory.WriteSellList();

				SceneUtility.SetCursor();
				Console.WriteLine("0: 돌아가기");
				SceneUtility.SetCursor();
				Console.WriteLine($"현재 소지금 : {Player.GetMoney()}");
				SceneUtility.SetCursor();
				Console.WriteLine("장비를 판매하시려면 목록에 해당하는 숫자를 입력해주세요.");
				SceneUtility.SetCursor();
				Console.Write(">> ");
				string? input = Console.ReadLine();
				int num;
				if (int.TryParse(input, out num))
				{
					// 0을 제외한 숫자가 "유효할 시" 판매 리스트의 Count를 받아서 연결
					if (num == 0)
					{
						BlackSmithMainScene();
						break;
					}
					else if (num <= Inventory.GetListCount())
					{
						blackSmith.BuyItem(num);
						continue;
					}
				}
			}
		}

		private void InnScene()
		{
			while (true)
			{
				SceneUtility.WriteTitle("여관");

				Console.WriteLine("여관의 문을 열자, 묽은 스튜 냄새와 함께 훈훈한 열기가 당신을 맞이합니다.");
				SceneUtility.SetCursor();
				Console.WriteLine("당신이 카운터쪽을 향해 걸어가자, 젊은 종업원 한 명이 여관에 대해 설명해 줍니다.");
				SceneUtility.SetCursor();
				Console.WriteLine("가장 중요한 건 가격이겠지요. 하루 숙박에 200골드라고 합니다.");
				SceneUtility.SetCursor();
				Console.WriteLine("어떻게 하시겠습니까? (휴식을 취하면 체력이 모두 회복됩니다.)\n");
				SceneUtility.SetCursor();

				Console.WriteLine("1: 휴식하기");
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
						if(Player.GetMoney() >= 200)
						{
							Player.SetMoney(-200);
							RestScene();
						}
						else
						{
							SceneUtility.SetCursor();
							Console.Write("돈이 없습니다.");
							Thread.Sleep(1000);
							continue;
						}
						break;
					}
					else if (num == 0)
					{
						EnterScene();
						break;
					}
				}
			}
		}

		private void RestScene()
		{
			SceneUtility.WriteTitle("여관 방 안");

			Console.WriteLine();
			SceneUtility.SetCursor();
			Console.Write("휴식을 취합니다");
			Thread.Sleep(800);
			Console.Write('.');
			Thread.Sleep(800);
			Console.Write('.');
			Thread.Sleep(800);
			Console.Write('.');
			Thread.Sleep(800);

			Console.WriteLine();
			SceneUtility.SetCursor();
			Console.Write("온 몸이 개운하네요! 당신은 여관에서 주는 아침 식사를 먹고 여관을 나왔습니다.");
			Thread.Sleep(1500);

			Player.Recovery(9999f);
			EnterScene();
		}

		private void BlackSmithBuyInit()
		{
			SceneUtility.WriteTitle("장비 구매");
			Console.WriteLine("노인에게 물건을 보여달라고 하자, 그가 망치를 내려놓고 말합니다.");
			SceneUtility.SetCursor();
			Console.WriteLine("\"농기구가 필요한 건 아닌 것 같으니, 이 쪽으로 오게.\"");
			SceneUtility.SetCursor();
			Console.Write("그는 당신을 무기들이 진열된 곳으로 안내합니다");
			Thread.Sleep(400);
			Console.Write('.');
			Thread.Sleep(400);
			Console.Write('.');
			Thread.Sleep(400);
			Console.Write('.');
			Thread.Sleep(400);
			Console.Write('.');
			Thread.Sleep(400);
		}
		private void BlackSmithSellInit()
		{
			SceneUtility.WriteTitle("장비 판매");
			Console.WriteLine("당신이 무기를 팔겠다고 하자, 노인은 심드렁한 표정으로 입을 열었습니다.");
			SceneUtility.SetCursor();
			Console.WriteLine("\"무기와 방어구는 받겠네. 하지만 값은 기대하지 말게.\"");
			SceneUtility.SetCursor();
			Console.Write("곧 노인은 당신이 꺼낸 장비들을 평가합니다");
			Thread.Sleep(400);
			Console.Write('.');
			Thread.Sleep(400);
			Console.Write('.');
			Thread.Sleep(400);
			Console.Write('.');
			Thread.Sleep(400);
			Console.Write('.');
			Thread.Sleep(400);
		}

	}

	internal class BlackSmith
	{
		private List<BaseItem> SaleList = new List<BaseItem>();

		public BlackSmith()
		{
			SaleList.Add(new OldArmor());
			SaleList.Add(new RustySword());
		}

		public void SaleScene()
		{
			SceneUtility.SetCursor();
			SceneUtility.MakeTradeList(SaleList);
		}

		public void SellItem(int num)
		{
			int Value = SaleList[num - 1].ItemValue;
			if( Player.GetMoney() >= Value)
			{
				BaseItem item = SaleList[num - 1];
				Inventory.AddItem(item);
				Player.SetMoney(SaleList[num - 1].ItemValue * -1);
			}
			else
			{
				SceneUtility.SetCursor();
				Console.Write("비용이 부족합니다.");
				Thread.Sleep(1000);
			}
		}
		public void BuyItem(int num)
		{
			int Value = Inventory.GetItemValue(num-1);
			Inventory.RemoveItem(num-1);
			Player.SetMoney(Value/2);
		}

		public int GetListCount()
		{
			return SaleList.Count;
		}
	}
}
