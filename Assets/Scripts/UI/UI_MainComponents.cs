/****************************************************************************
 * 2019.6 DESKTOP-FKR85NK
 ****************************************************************************/

namespace QFramework.Example
{
	using UnityEngine;
	using UnityEngine.UI;

	public partial class UI_Main
	{
		public const string NAME = "UI_Main";
		[SerializeField] public Button Icon1;
		[SerializeField] public Button Icon2;
		[SerializeField] public Button Icon3;
		[SerializeField] public Button Icon4;
		[SerializeField] public Button Icon5;
		[SerializeField] public Button Icon6;
		[SerializeField] public Button Icon7;
		[SerializeField] public Button Exit;

		protected override void ClearUIComponents()
		{
			Icon1 = null;
			Icon2 = null;
			Icon3 = null;
			Icon4 = null;
			Icon5 = null;
			Icon6 = null;
			Icon7 = null;
			Exit = null;
		}
	}
}
