/****************************************************************************
 * 2019.6 DESKTOP-FKR85NK
 ****************************************************************************/

namespace QFramework.Example
{
	using UnityEngine;
	using UnityEngine.UI;

	public partial class UI_Indro
	{
		public const string NAME = "UI_Indro";
		[SerializeField] public Button Confir;

		protected override void ClearUIComponents()
		{
			Confir = null;
		}
	}
}
