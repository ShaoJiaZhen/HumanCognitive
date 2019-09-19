/****************************************************************************
 * 2019.6 DESKTOP-FKR85NK
 ****************************************************************************/

namespace QFramework.Example
{
	using UnityEngine;
	using UnityEngine.UI;

	public partial class Scene_G
	{
		public const string NAME = "Scene_G";
		[SerializeField] public Button myBack;

		protected override void ClearUIComponents()
		{
			myBack = null;
		}
	}
}
