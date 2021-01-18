using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Akari
{
    public class GameEntry : MonoBehaviour
    {
        public static Transform GameEntryTransform
        {
            get;
            private set;
        }

        #region Manager
        public static GameSaveSystem GameSave
        {
            get;
            private set;
        }

        public static EventCenter Event
        {
            get;
            private set;
        }

        public static MusicMgr Music
        {
            get;
            private set;
        }

        public static ScenesMgr Scenes
        {
            get;
            private set;
        }

        public static UIManager UI
        {
            get;
            private set;
        }

        #endregion

        void Start()
        {
            GameEntryTransform = transform;
            
            InitManager();

            Scenes.SetActiveScene("GameStart");
            Scenes.LoadSceneAsyn("Menu", LoadSuccess);
        }


        private void InitManager()
        {
            GameSave = GameSaveSystem.GetInstance();
            Event = EventCenter.GetInstance();
            Music = MusicMgr.GetInstance();
            Scenes = ScenesMgr.GetInstance();
            UI = UIManager.GetInstance();
        }

        private void LoadSuccess()
        {
            Debug.Log("Menu加载成功");
            UI.OpenPanel<UIMainMenuForm>("UIMainMenuForm");
        }
    }
}

