using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
	// 내가 가지고있는 아이템을 관리하는 클래스
	// 일단 장비 기능부터 구현 -> 기능별 구분(소비탭, 장비탭)
	internal static class Inventory
	{
		private static List<BaseItem> ItemList = new List<BaseItem>();
		public static void AddItem(BaseItem item)
		{
			ItemList.Add(item);
		}
		public static void RemoveItem(int index)
		{
			ItemList.RemoveAt(index);
		}
		public static void WriteItemList(bool mode)
		{
			// 일반 인벤토리는 false, 장착 모드는 true
			for(int i = 0; i < ItemList.Count; i++)
			{
				if (!mode)
					Console.Write("- ");
				else
					Console.Write("{0} ", i+1);
				ItemList[i].PrintItem();
			}
			Console.WriteLine();
			SceneUtility.SetCursor();
		}

		public static void EquipItem(int count)
		{
			ItemList[count-1].ChangeEquipStatus();
		}

		public static int GetListCount()
		{
			return ItemList.Count;
		}

		public static void WriteSellList()
		{
			SceneUtility.MakeTradeList(ItemList, 0.5f) ;
		}
		public static int GetItemValue(int index)
		{
			return ItemList[index].ItemValue;
		}
	}
}
