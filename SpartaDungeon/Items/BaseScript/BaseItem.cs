using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
	internal abstract class BaseItem
	{
		protected string name = "?";
		protected string description = "?";
		protected string effect = "?";
		protected bool isEquiped = false;
		protected ItemOption itemOption = ItemOption.None;
		protected float itemEffect = 0f;
		protected int itemValue = 0;

		public string Name { get { return name; } }
		public string Description { get { return description; } }
		public string Effect { get { return effect; } }
		public int ItemValue { get { return itemValue; } }

		public void PrintItem()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			if (isEquiped == true)
				Console.Write("[E]");
			Console.ResetColor();
			Console.Write($"{name, -10}\t|{effect,-6}|{description,-10}");
			Console.WriteLine();
			SceneUtility.SetCursor();
		}

		protected abstract void InitEquipValue();
		private void EquipItem()
		{
			isEquiped = true;
			Player.AddStatus(itemOption, itemEffect);
		}
		private void DetachItem()
		{
			isEquiped = false;
			Player.AddStatus(itemOption, itemEffect * -1);
		}

		public void ChangeEquipStatus()
		{
			if (isEquiped)
				DetachItem();
			else
				EquipItem();
		}

	}
}
