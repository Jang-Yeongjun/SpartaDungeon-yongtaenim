using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpartaDungeon
{
	internal class RustySword : EquipableItem
	{
		public RustySword()
		{
			name = "녹슨 검";
			description = "어딘가에 버려져 있어도 이상하지 않은 검입니다.";
			effect = "공격력 +3";
			itemValue = 400;
			itemType = ItemType.Weapon;
			Status = Status.Attack;
			itemEffect = 3f;
		}

		public override BaseItem DeepCopy()
		{
			return new RustySword();
		}
	}

	internal class SteelSword : EquipableItem
	{
		public SteelSword()
		{
			name = "철검";
			description = "잘 만들어진 철검입니다.";
			effect = "공격력 +6";
			itemValue = 800;
			itemType = ItemType.Weapon;
			Status = Status.Attack;
			itemEffect = 6f;
		}

		public override BaseItem DeepCopy()
		{
			return new SteelSword();
		}
	}

	internal class SpartaSword : EquipableItem
	{
		public SpartaSword()
		{
			name = "스파르타 검";
			description = "엄청난 기운이 느껴지는 검입니다.";
			effect = "공격력 +20";
			itemValue = 5000;
			itemType = ItemType.Weapon;
			Status = Status.Attack;
			itemEffect = 20f;
		}

		public override BaseItem DeepCopy()
		{
			return new SpartaSword();
		}
	}
}
