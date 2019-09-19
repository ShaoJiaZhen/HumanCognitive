/****************************************************************************
 * 2019.6 DESKTOP-FKR85NK
 ****************************************************************************/

namespace QFramework.Example
{
	using UnityEngine;
	using UnityEngine.UI;

	public partial class UI_Game
	{
		public const string NAME = "UI_Game";
		[SerializeField] public Button myBack;

		protected override void ClearUIComponents()
		{
			myBack = null;
		}
	}
}
