/****************************************************************************
 * 2019.6 DESKTOP-FKR85NK
 ****************************************************************************/

namespace QFramework.Example
{
	using UnityEngine;
	using UnityEngine.UI;

	public partial class UI_Sh_2
	{
		public const string NAME = "UI_Sh_2";
		[SerializeField] public Button myBack;
		[SerializeField] public Button upPage;
		[SerializeField] public Button nextPage;

		protected override void ClearUIComponents()
		{
			myBack = null;
			upPage = null;
			nextPage = null;
		}
	}
}
