/****************************************************************************
 * 2019.6 DESKTOP-FKR85NK
 ****************************************************************************/

namespace QFramework.Example
{
	using UnityEngine;
	using UnityEngine.UI;

	public partial class UI_Knowledge
	{
		public const string NAME = "UI_Knowledge";
		[SerializeField] public Button myBack;

		protected override void ClearUIComponents()
		{
			myBack = null;
		}
	}
}
