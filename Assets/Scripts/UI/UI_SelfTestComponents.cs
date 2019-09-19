/****************************************************************************
 * 2019.6 DESKTOP-FKR85NK
 ****************************************************************************/

namespace QFramework.Example
{
	using UnityEngine;
	using UnityEngine.UI;

	public partial class UI_SelfTest
	{
		public const string NAME = "UI_SelfTest";
		[SerializeField] public Button myBack;
		[SerializeField] public Button switchBtn;

		protected override void ClearUIComponents()
		{
			myBack = null;
			switchBtn = null;
		}
	}
}
