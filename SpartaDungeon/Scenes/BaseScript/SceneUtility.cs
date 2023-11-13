using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
	/// <summary>
	/// Scene의 기본적인 세팅을 담당하는 전역 클래스입니다.
	/// </summary>
	internal static class SceneUtility
	{
		public static void MakeBorder()
		{
			Console.Clear();
			// x축 첫줄
			for(int i = 0; i < 60; i++)
			{
				Console.Write('ㅡ');
			}
			// y축 첫줄
			for(int i = 1; i < 29; i++)
			{
				Console.SetCursorPosition(0, i);
				Console.Write('|');
				Console.SetCursorPosition(119, i);
				Console.Write('|');
			}
			// x축 마지막 줄
			Console.SetCursorPosition(0, 29);
			for (int i = 0; i < 60; i++)
			{
				Console.Write('ㅡ');
			}
			// x축 중간 줄
			Console.SetCursorPosition(0, 20);
			for (int i = 0; i < 60; i++)
			{
				Console.Write('ㅡ');
			}
			for (int i = 21; i < 29; i++)
			{
				Console.SetCursorPosition(60, i);
				Console.Write('|');
			}
			Console.SetCursorPosition(1, 1);
		}

		public static void SetCursor()
		{
			int x, y;
			(x, y) = Console.GetCursorPosition();
			if (x <= 0)
				Console.SetCursorPosition(1, y);
		}
		public static void WriteTitle(string title)
		{
			// 장소의 이름 출력이 필요할 때, 기초적인 프레임을 만들어주는 기능입니다.
			MakeBorder();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine($"[{title}]");
			Console.ResetColor();
			SetCursor();
		}

		public static void MakeTradeList(List<BaseItem> list, float Valuebias = 1)
		{
			Console.SetCursorPosition(20, 2);
			for(int i=0; i <50; i++)
			{
				Console.Write('■');
			}
			Console.WriteLine();
			SetCursor();

			for(int i = 0; i < list.Count; i++)
			{
				int CurrentY = Console.GetCursorPosition().Top;
				Console.SetCursorPosition(20, CurrentY);
				Console.Write('■');
				Console.SetCursorPosition(69, CurrentY);
				Console.Write('■');
				Console.SetCursorPosition(22,CurrentY);
				Console.Write($"{i+1, -2}. {list[i].Name, -8}\t |{list[i].Effect}|{list[i].ItemValue * Valuebias, 10} Gold");
				Console.WriteLine();
				SetCursor();
			}

			int y = Console.GetCursorPosition().Top;
			Console.SetCursorPosition(20, y);
			for (int i = 0; i < 50; i++)
			{
				Console.Write('■');
			}
			Console.WriteLine();
			SetCursor();
		}
	}
}
