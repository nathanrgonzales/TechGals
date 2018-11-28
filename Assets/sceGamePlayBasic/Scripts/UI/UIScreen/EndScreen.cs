using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RedRunner.UI
{
    public class EndScreen : UIScreen
    {
        [SerializeField]
        protected Button ResetButton = null;
        [SerializeField]
        protected Button ExitButton = null;

        private void Start()
        {
            ResetButton.SetButtonAction(() =>
            {
                Application.LoadLevel(Application.loadedLevel);
                //GameManager.Singleton.Reset();
                //var ingameScreen = UIManager.Singleton.GetUIScreen(UIScreenInfo.IN_GAME_SCREEN);
                //UIManager.Singleton.OpenScreen(ingameScreen);
                
            });
        }

        public override void UpdateScreenStatus(bool open)
        {
            base.UpdateScreenStatus(open);
        }
    }

}