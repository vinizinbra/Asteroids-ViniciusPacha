using Ship;
using TMPro;
using UI.Base;
using UI.InGame;

namespace UI.Windows
{
	public class InGameWindow : UiWindow
	{
		public TMP_Text level;
		public LifeWidget[] livesWidgets;
    
		private ShipManager _shipManager;
		public override void Show()
		{
			base.Show();
			level.text = string.Format("Level {0}",GameManager.Instance.Level);
		}

		private void Start()
		{
			_shipManager = ShipManager.Instance;
		}

		public void GameOver()
		{
			GameManager.Instance.GameOver();
		}

		private void Update()
		{
			for (int i = 0; i < _shipManager.ships.Length; i++)
			{
				livesWidgets[i].gameObject.SetActive(_shipManager.ships[i].owner.isConnected);

				if (_shipManager.ships[i].owner.isConnected)
				{
					livesWidgets[i].Setup(_shipManager.ships[i].currentLife);
				}
				else
				{
					livesWidgets[i].Setup(0);
				}
			}
		    
		}
	}
}
