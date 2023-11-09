using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
	internal class InventoryScene : BaseScene
	{
		public override void EnterScene()
		{
			// 미니 페이지 특성상 어쩔 수 없이...
		}

		public override State ExitScene()
		{
			return nextState;
		}

		public override void ReceiveInput()
		{
			while(true)
			{
				SceneUtility.MakeBorder();
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("[인벤토리]");
				Console.ResetColor();
				SceneUtility.SetCorsor();
				Inventory.WriteItemList(false);
				Console.WriteLine("장착 관리 : 1");
				SceneUtility.SetCorsor();
				Console.WriteLine("뒤로 가기 : 0");
				SceneUtility.SetCorsor();
				Console.Write(">> ");
				string? input = Console.ReadLine();
				SceneUtility.SetCorsor();
				if (input == "0")
				{
					nextState = beforeState;
					break;
				}
				else if(input == "1")
				{
					// 해당 함수에서 다시 ReceiveInput을 호출하는 방향으로
					EquipScene();
					break;
				}
				else
				{
					continue;
				}
			}

		}

		public void EquipScene()
		{
			while (true)
			{
				SceneUtility.MakeBorder();
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("[인벤토리]");
				Console.ResetColor();
				SceneUtility.SetCorsor();
				Inventory.WriteItemList(true);
				Console.WriteLine("아이템 숫자를 누르면 아이템이 장착 혹은 해제됩니다.");
				SceneUtility.SetCorsor();
				Console.WriteLine("뒤로 가기 : 0");
				SceneUtility.SetCorsor();
				Console.Write(">> ");
				string? input = Console.ReadLine();
				SceneUtility.SetCorsor();
				int num;
				if (int.TryParse(input, out num) && num <= Inventory.GetListCount())
				{
					if (num == 0)
					{
						ReceiveInput();
						break;
					}
					else
					{
						Inventory.EquipItem(num);
					}
				}
				else
				{
					Console.WriteLine("다시 입력해주세요.");
					SceneUtility.SetCorsor();
					continue;
				}
					
			}

		}
	}
}
