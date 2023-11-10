using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
	// 추후에 :: 데이터를 받아서 작성 -> 더 되면 데이터를 로컬에 저장
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
		static Dictionary<EquipType, bool> equipState = new Dictionary<EquipType, bool>();


		public static void InitCharacter(string myName)
		{
			level = 1;
			name = myName;
			job = "전사";
			baseAttack = 10;
			baseDefense = 5;
			baseHealth = 100;
			currentHealth = 50;
			gold = 0;
			equipState.Add(EquipType.None, true);
			equipState.Add(EquipType.Ring, false);
			equipState.Add(EquipType.Weapon, false);
			equipState.Add(EquipType.Armor, false);
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
		public static void AddStatus(ItemOption option, float value)
		{
			switch(option)
			{
				case ItemOption.Attack:
					{
						equipAttack += value;
						break;
					}
				case ItemOption.Defense:
					{
						equipDefense += value;
						break;
					}
				case ItemOption.Health:
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

		public static bool IsEquiped(EquipType equipType)
		{
			if (equipState[equipType])
				return true;
			return false;
		}

		public static void ChangeEquipState(EquipType equipType , bool state)
		{
			equipState[equipType] = state;
		}
	}
}
