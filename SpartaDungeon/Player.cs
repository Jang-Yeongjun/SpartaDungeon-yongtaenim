using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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


		public static void InitCharacter(string myName)
		{
			level = 1;
			name = myName;
			job = "전사";
			baseAttack = 10;
			baseDefense = 5;
			baseHealth = 100;
			gold = 0;
		}

		public static void WriteMyStatus()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("[상태창]");
			Console.ResetColor();

			SceneUtility.SetCorsor();
			Console.WriteLine("Lv.\t: {0}", level);
			SceneUtility.SetCorsor();
			Console.WriteLine("이름\t: {0}", name);
			SceneUtility.SetCorsor();
			Console.WriteLine("직업\t: {0}", job);
			SceneUtility.SetCorsor();

			// 현재 음수에 대한 입력은 고려 안함
			Console.Write("공격력\t: {0}", baseAttack + equipAttack);
			if(equipAttack != 0)
			{
				Console.WriteLine(" (+{0})", equipAttack);
				SceneUtility.SetCorsor();
			}
			else
			{
				Console.WriteLine();
				SceneUtility.SetCorsor();
			}
				

			Console.Write("방어력\t: {0}", baseDefense + equipDefense);
			if(equipDefense != 0)
			{
				Console.WriteLine(" (+{0})", equipDefense);
				SceneUtility.SetCorsor();
			}	
			else
			{
				Console.WriteLine();
				SceneUtility.SetCorsor();
			}
			Console.Write("체력\t: {0}", baseHealth + equipHealth);
			if (equipHealth != 0)
			{
				Console.WriteLine(" (+{0})", equipHealth);
				SceneUtility.SetCorsor();
			}
			else
			{
				Console.WriteLine();
				SceneUtility.SetCorsor();
			}
			Console.WriteLine("소지금\t: {0} Gold", gold);
			SceneUtility.SetCorsor();
			Console.WriteLine();
			SceneUtility.SetCorsor();
		}

		public static void GetMoney(int money)
		{
			gold += money;
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
						SceneUtility.SetCorsor();
						break;
					}
			}
		}
	}
}
