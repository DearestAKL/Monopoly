using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Akari
{
    public class UIMainMenuForm : UIMainMenuFormSign
    {
        private ScenesMgr ScenesManager;

        public override void Init()
        {
            base.Init();
            InitUIData();

            ScenesManager = GameEntry.Scenes;

            btnStart.onClick.AddListener(OnStart);
            btnContinue.onClick.AddListener(OnContinue);
            btnMod.onClick.AddListener(OnMod);
            btnSetting.onClick.AddListener(OnSetting);
        }

        public override void Open()
        {
            base.Open();
        }

        public override void Close()
        {
            base.Close();
        }

        #region Event
        private void OnStart()
        {
            GameEntry.UI.OpenPanel<UILoadingForm>("UILoadingForm", E_UI_Layer.Top);
            ScenesManager.LoadSceneAsyn("Game", LoadSuccess);
        }

        private void OnContinue()
        {

        }

        private void OnMod()
        {

        }

        private void OnSetting()
        {

        }
        #endregion

        private void LoadSuccess()
        {
            Debug.Log("Game Scene加载成功");
            //UI.OpenPanel<UIMainMenuForm>("UIMainMenuForm");
        }
    }
}
