using UI.Base;

namespace UI.Windows
{
	public class WinWindow : UiWindow
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
		}
	}
}
