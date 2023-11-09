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
			SceneUtility.MakeBorder();
			Player.WriteMyStatus();
		}

		public override State ExitScene()
		{
			return nextState;
		}

		public override void ReceiveInput()
		{
			while (true)
			{
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
			}
		}
	}
}
