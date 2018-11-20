using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RedRunner.UI
{
    public class PauseScreen : UIScreen
    {
        [SerializeField]
        protected Button ResumeButton = null;
        [SerializeField]
        protected Button SoundButton = null;
        [SerializeField]
        protected Button ExitButton = null;

        private void Start()
        {
            ResumeButton.SetButtonAction(() =>
            {
                var inGameScreen = UIManager.Singleton.UISCREENS.Find(el => el.ScreenInfo == UIScreenInfo.IN_GAME_SCREEN);
                UIManager.Singleton.OpenScreen(inGameScreen);
                GameManager.Singleton.StartGame();
            });

            ExitButton.SetButtonAction(() =>
            {
                GameManager.Singleton.Reset();
                var ingameScreen = UIManager.Singleton.GetUIScreen(UIScreenInfo.IN_GAME_SCREEN);
                UIManager.Singleton.OpenScreen(ingameScreen);
                Application.LoadLevel(3);
            });            
        }

        public override void UpdateScreenStatus(bool open)
        {
            base.UpdateScreenStatus(open);
        }
    }
}
