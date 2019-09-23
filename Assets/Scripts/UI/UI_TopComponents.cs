/****************************************************************************
 * 2019.6 DESKTOP-FKR85NK
 ****************************************************************************/

namespace QFramework.Example
{
	using UnityEngine;
	using UnityEngine.UI;

	public partial class UI_Top
	{
		public const string NAME = "UI_Top";
		[SerializeField] public Button myBtn;

		protected override void ClearUIComponents()
		{
			myBtn = null;
		}
	}
}
