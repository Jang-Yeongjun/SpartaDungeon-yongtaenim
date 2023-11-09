using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
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

		public static void SetCorsor()
		{
			int x, y;
			(x, y) = Console.GetCursorPosition();
			if (x <= 0)
				Console.SetCursorPosition(1, y);
		}
	}
}
