using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace Trinity.Hotfix {
    public static class UIEventHelper
    {
        private static float outResetStartTime;
        private static bool bClick = true;
        public delegate void ButtonClickBoolAction();
        public delegate void ButtonClickBoolAction<T>(T value);

        //同步执行事件 按钮
        public static void Add(this Button.ButtonClickedEvent buttonClickedEvent, ButtonClickBoolAction action)
        {
            buttonClickedEvent.AddListener(() => {
                try
                {
                    if (bClick)
                    {
                        bClick = false;
                        action.Invoke();
                        bClick = true;
                    }
                }
                catch (Exception e)
                {
                    bClick = true;
                    Log.Warning($"EventHelper 2 ---> {e}");
                }
            });
        }
    }
}