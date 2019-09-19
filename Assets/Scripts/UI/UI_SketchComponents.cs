/****************************************************************************
 * 2019.6 DESKTOP-FKR85NK
 ****************************************************************************/

namespace QFramework.Example
{
	using UnityEngine;
	using UnityEngine.UI;

	public partial class UI_Sketch
	{
		public const string NAME = "UI_Sketch";
		[SerializeField] public Button nextPage;
		[SerializeField] public Button myBack;

		protected override void ClearUIComponents()
		{
			nextPage = null;
			myBack = null;
		}
	}
}
