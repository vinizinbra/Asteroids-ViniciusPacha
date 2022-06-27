using UI.Base;

namespace UI.Windows
{
	public class GameOverWindow : UiWindow
	{
   
		public override void Show()
		{
			base.Show();
	   
		}

		public void Update()
		{
		}
    
		public void Restart()
		{
			GameManager.Instance.Restart();
			UiWindow.Show<MenuWindow>();
		}
	}
}
