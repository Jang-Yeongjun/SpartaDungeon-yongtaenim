using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
	public enum EquipType
	{
		None,
		Weapon,
		Armor,
		Ring
	}
	internal abstract class EquipableItem : BaseItem
	{
		protected EquipType equipType;

		protected abstract void InitEquipValue();
		private void EquipItem()
		{
			if (!Player.IsEquiped(equipType))
			{
				isEquiped = true;
				Player.AddStatus(itemOption, itemEffect);
				Player.ChangeEquipState(equipType, true);
			}
		}
		private void DetachItem()
		{
			isEquiped = false;
			Player.AddStatus(itemOption, itemEffect * -1);
			Player.ChangeEquipState(equipType, false);
		}

		public override void ChangeEquipStatus()
		{
			if (isEquiped)
				DetachItem();
			else
				EquipItem();
		}

		public override void DeleteEffect()
		{
			if(isEquiped)
			{
				isEquiped = false;
				Player.ChangeEquipState(equipType, false);
				Player.AddStatus(itemOption, itemEffect * -1);
			}
		}
	}
}
