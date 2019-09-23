/****************************************************************************
 * 2019.6 DESKTOP-FKR85NK
 ****************************************************************************/

namespace QFramework.Example
{
	using UnityEngine;
	using UnityEngine.UI;

	public partial class UI_Start
	{
		public const string NAME = "UI_Start";
		[SerializeField] public Button myStartBtn;

		protected override void ClearUIComponents()
		{
			myStartBtn = null;
		}
	}
}
