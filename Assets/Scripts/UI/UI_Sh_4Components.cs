/****************************************************************************
 * 2019.6 DESKTOP-FKR85NK
 ****************************************************************************/

namespace QFramework.Example
{
	using UnityEngine;
	using UnityEngine.UI;

	public partial class UI_Sh_4
	{
		public const string NAME = "UI_Sh_4";
		[SerializeField] public Button myBack;
		[SerializeField] public Button upPage;

		protected override void ClearUIComponents()
		{
			myBack = null;
			upPage = null;
		}
	}
}
