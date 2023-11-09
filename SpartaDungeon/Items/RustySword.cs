using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpartaDungeon
{
	internal class RustySword : BaseItem
	{
		public RustySword()
		{
			name = "녹슨 검";
			description = "어딘가에 버려져 있어도 이상하지 않은 검입니다.";
			effect = "공격력 +3";
			InitEquipValue();
		}
		protected override void InitEquipValue()
		{
			itemOption = ItemOption.Attack;
			itemEffect = 3f;
		}
	}
}
