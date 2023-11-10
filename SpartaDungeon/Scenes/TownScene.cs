using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
	internal class TownScene : BaseScene
	{
		public override void EnterScene()
		{
			while (true)
			{
				SceneUtility.MakeBorder();
				Console.WriteLine("당신은 스파르타 마을의 분수에 도착했습니다.");
				SceneUtility.SetCursor();
				Console.WriteLine("상점가에는 모험에 필요한 물건을 파는 상점과 여관같은 건물들이 보입니다.");
				SceneUtility.SetCursor();
				Console.WriteLine("저 먼 곳을 바라보니, 던전이 있는 커다란 산을 향해 가는 길도 희미하게 보입니다.\n");
				SceneUtility.SetCursor();

				Console.WriteLine("무엇을 하시겠습니까?");
				SceneUtility.SetCursor();
				Console.WriteLine("1. 상태창 보기");
				SceneUtility.SetCursor();
				Console.WriteLine("2. 인벤토리 확인");
				SceneUtility.SetCursor();
				Console.WriteLine("3. 상점가로 가기");
				SceneUtility.SetCursor();
				Console.WriteLine("4. 던전으로 가기");
				SceneUtility.SetCursor();
				Console.WriteLine("Q. 게임 종료");
				SceneUtility.SetCursor();

				Console.Write(">> ");
				string? input = Console.ReadLine();
				SceneUtility.SetCursor();
				if (input == "1")
				{
					nextState = State.Status;
					break;
				}
				else if (input == "2")
				{
					nextState = State.Inventory;
					break;
				}
				else if (input == "3")
				{
					nextState = State.Shop;
					break;
				}
				else if (input == "4")
				{
					break;
				}
				else if (input == "Q")
				{
					break;
				}
			}
		}
		public override State ExitScene()
		{
			return nextState;
		}
	}
}
