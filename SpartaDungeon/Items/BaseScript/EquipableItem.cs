using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{

	internal abstract class EquipableItem : BaseItem
	{
		private void EquipItem()
		{
			if (!Player.IsEquiped(itemType))
			{
				isEquiped = true;
				Player.AddStatus(Status, itemEffect);
				Player.ChangeEquipState(itemType, true);
			}
		}
		private void DetachItem()
		{
			isEquiped = false;
			Player.AddStatus(Status, itemEffect * -1);
			Player.ChangeEquipState(itemType, false);
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
				Player.ChangeEquipState(itemType, false);
				Player.AddStatus(Status, itemEffect * -1);
			}
		}
	}
}
