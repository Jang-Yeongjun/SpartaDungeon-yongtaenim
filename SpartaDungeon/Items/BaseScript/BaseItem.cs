using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
	enum ItemOption
	{
		None,
		Attack,
		Defense,
		Health
	}
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

		public abstract BaseItem DeepCopy();
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

		public abstract void ChangeEquipStatus();
		public abstract void DeleteEffect();
	}
}
