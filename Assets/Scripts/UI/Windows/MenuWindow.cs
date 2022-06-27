using Player;
using UI.Base;

namespace UI.Windows
{
	public class MenuWindow : UiWindow
	{
		private PlayerManager _playerManager;
	
		void Start()
		{
			_playerManager = PlayerManager.Instance;
		}
   
		public override void Show()
		{
			base.Show();
		}

		public void StartGame()
		{
			GameManager.Instance.StartGame();
		}

	}
}
