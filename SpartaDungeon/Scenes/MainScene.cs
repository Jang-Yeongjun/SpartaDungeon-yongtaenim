using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
	// 메인화면
	internal class MainScene : BaseScene
	{
		public override void EnterScene()
		{
			while (true)
			{
				SceneUtility.MakeBorder();
				Console.WriteLine("스파르타 던전에 오신 것을 환영합니다.");
				SceneUtility.SetCursor();

				Console.Write("게임을 시작하시겠습니까? (1:시작, 2:종료) : ");
				string? input = Console.ReadLine();
				SceneUtility.SetCursor();
				if (input == "1")
				{
					nextState = State.Town;
					break;
				}
				else if (input == "2")
				{
					nextState = State.None;
					break;
				}
				else
				{
					Console.WriteLine("다시 입력해주세요.");
					SceneUtility.SetCursor();
				}
			}
		}
		public override State ExitScene()
		{
			if(nextState == State.Town)
			{

				ReceiveName();
				SceneUtility.MakeBorder();
				FirstSetUp();
				Console.WriteLine("게임을 시작합니다.");
				SceneUtility.SetCursor();
				Thread.Sleep(1000);
				return State.Town;
			}
			if(nextState == State.End)
			{
				Console.WriteLine("게임을 종료합니다.");
				SceneUtility.SetCursor();
				Thread.Sleep(1000);
				return State.None;
			}
			return State.None;
		}

		public void ReceiveName()
		{
			while(true)
			{
				Console.Write("이름을 입력해주세요 : ");
				string input = Console.ReadLine();
				SceneUtility.SetCursor();
				Console.Write("이 이름이 맞습니까? (Y/N) : ");
				string? YN = Console.ReadLine();
				SceneUtility.SetCursor();
				if (YN == "Y")
				{
					Player.InitCharacter(input);
					break;
				}
				else
				{
					continue;
				}
			}
		}

		public void FirstSetUp()
		{
			// 일단 초기설정 -> 업데이트 한다면 분기에 따른 설정
			Console.WriteLine("당신은 1000골드와 낡은 갑옷, 녹슨 검을 가지고 있습니다.");
			SceneUtility.SetCursor();
			Inventory.AddItem(new OldArmor());
			Inventory.AddItem(new RustySword());
			Player.SetMoney(1000);
		}
	}
}
