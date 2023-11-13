using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
	internal static class Player
	{
		static int level;
		static string? name;
		static string? job;
		static float baseAttack;
		static float baseDefense;
		static float baseHealth;
		static int gold;
		static float equipAttack = 0f;
		static float equipDefense = 0f;
		static float equipHealth = 0f;
		static float currentHealth = 0f;
		static Dictionary<ItemType, bool> equipState = new Dictionary<ItemType, bool>();


		public static void InitCharacter(string myName)
		{
			level = 1;
			name = myName;
			job = "전사";
			baseAttack = 10;
			baseDefense = 5;
			baseHealth = 100;
			currentHealth = baseHealth;
			gold = 0;
			equipState.Add(ItemType.None, true);
			equipState.Add(ItemType.Ring, false);
			equipState.Add(ItemType.Weapon, false);
			equipState.Add(ItemType.Armor, false);
		}

		public static void WriteMyStatus()
		{
			SceneUtility.WriteTitle("상태창");

			Console.WriteLine("Lv.\t: {0}", level);
			SceneUtility.SetCursor();
			Console.WriteLine("이름\t: {0}", name);
			SceneUtility.SetCursor();
			Console.WriteLine("직업\t: {0}", job);
			SceneUtility.SetCursor();

			// 현재 음수에 대한 입력은 고려 안함
			Console.Write($"공격력\t: {baseAttack + equipAttack, -4}");
			if(equipAttack != 0)
			{
				Console.WriteLine("(+{0})", equipAttack);
				SceneUtility.SetCursor();
			}
			else
			{
				Console.WriteLine();
				SceneUtility.SetCursor();
			}
				

			Console.Write($"방어력\t: {baseDefense + equipDefense, -4}");
			if(equipDefense != 0)
			{
				Console.WriteLine("(+{0})", equipDefense);
				SceneUtility.SetCursor();
			}	
			else
			{
				Console.WriteLine();
				SceneUtility.SetCursor();
			}

			Console.WriteLine($"체력\t: {currentHealth} / {baseHealth+equipHealth}");
			SceneUtility.SetCursor();

			Console.WriteLine("소지금\t: {0} Gold", gold);
			SceneUtility.SetCursor();
			Console.WriteLine();
			SceneUtility.SetCursor();
		}

		public static void SetMoney(int money)
		{
			gold += money;
		}
		public static int GetMoney()
		{
			return gold;
		}

		// 장착 해제할 때는 value를 -로!
		public static void AddStatus(Status status, float value)
		{
			switch(status)
			{
				case Status.Attack:
					{
						equipAttack += value;
						break;
					}
				case Status.Defense:
					{
						equipDefense += value;
						break;
					}
				case Status.Health:
					{
						equipHealth += value;
						break;
					}
				default:
					{
						Console.WriteLine("잘못된 접근입니다.");
						SceneUtility.SetCursor();
						break;
					}
			}
		}

		public static void Recovery(float value)
		{
			if(value + currentHealth > baseHealth + equipHealth)
			{
				currentHealth = baseHealth + equipHealth;
			}
			else
			{
				currentHealth += value;
			}
		}

		public static bool IsEquiped(ItemType itemType)
		{
			if (equipState[itemType])
				return true;
			return false;
		}

		public static void ChangeEquipState(ItemType itemType , bool state)
		{
			equipState[itemType] = state;
		}

		public static void UseItem(Status Status, float value)
		{
			switch (Status)
			{
				case Status.Attack:
					{
						baseAttack += value;
						break;
					}
				case Status.Defense:
					{
						baseDefense += value;
						break;
					}
				case Status.Health:
					{
						if (value + currentHealth > baseHealth + equipHealth)
						{
							currentHealth = baseHealth + equipHealth;
						}
						else
						{
							currentHealth += value;
						}
						break;
					}
				default:
					{
						Console.WriteLine("잘못된 접근입니다.");
						SceneUtility.SetCursor();
						break;
					}
			}
		}

		public static float GetStatus(Status status)
		{
			switch (status)
			{
				case Status.Attack:
					return baseAttack + equipAttack;
				case Status.Defense:
					return baseDefense + equipDefense;
				case Status.Health:
					return currentHealth;
			}
			return 0f;
		}
	}
}
