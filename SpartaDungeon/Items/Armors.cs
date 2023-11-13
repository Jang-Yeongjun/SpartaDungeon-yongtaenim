using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
	internal class OldArmor : EquipableItem
	{
		public OldArmor()
		{
			name = "낡은 갑옷";
			description = "모습은 좀 그렇지만 쓸만한 갑옷입니다.";
			effect = "방어력 +3";
			itemValue = 500;
			itemType = ItemType.Armor;
			Status = Status.Defense;
			itemEffect = 3f;
		}

		public override BaseItem DeepCopy()
		{
			return new OldArmor();
		}
	}

	internal class SteelArmor : EquipableItem
	{
		public SteelArmor()
		{
			name = "철갑옷";
			description = "잘 만들어진 갑옷입니다.";
			effect = "방어력 +6";
			itemValue = 1000;
			itemType = ItemType.Armor;
			Status = Status.Defense;
			itemEffect = 6f;
		}

		public override BaseItem DeepCopy()
		{
			return new SteelArmor();
		}
	}

	internal class SpartaArmor : EquipableItem
	{
		public SpartaArmor()
		{
			name = "슈퍼 아머";
			description = "엄청난 기운이 샘솟는 방어구입니다.";
			effect = "방어력 +20";
			itemValue = 5000;
			itemType = ItemType.Armor;
			Status = Status.Defense;
			itemEffect = 20f;
		}

		public override BaseItem DeepCopy()
		{
			return new SpartaArmor();
		}
	}
}
