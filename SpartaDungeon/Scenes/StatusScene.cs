using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon.Scenes
{
	internal class StatusScene : BaseScene
	{
		public override void EnterScene()
		{
			Player.WriteMyStatus();
			while (true)
			{
				Console.WriteLine("뒤로 가기 : 0");
				SceneUtility.SetCursor();
				Console.Write(">> ");
				string? input = Console.ReadLine();
				SceneUtility.SetCursor();
				if (input == "0")
				{
					nextState = beforeState;
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
