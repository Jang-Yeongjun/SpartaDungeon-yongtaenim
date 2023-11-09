using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
	internal class OldArmor : BaseItem
	{
		public OldArmor()
		{
			name = "낡은 갑옷";
			description = "모습은 좀 그렇지만 쓸만한 갑옷입니다.";
			effect = "방어력 +3";
			InitEquipValue();
		}
		protected override void InitEquipValue()
		{
			itemOption = ItemOption.Defense;
			itemEffect = 3f;
		}
	}
}
