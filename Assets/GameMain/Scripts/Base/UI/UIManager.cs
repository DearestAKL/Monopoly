﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Akari
{
    /// <summary>
    /// UI层级
    /// </summary>
    public enum E_UI_Layer
    {
        Bot,
        Mid,
        Top,
        System
    }

    /// <summary>
    /// UI管理器
    /// 1.管理所有显示的面板
    /// 2.提供给外部 显示和隐藏
    /// </summary>
    public class UIManager : Singleton<UIManager>
    {
        public Dictionary<string, BasePanel> panelDic = new Dictionary<string, BasePanel>();

        private Transform bot;
        private Transform mid;
        private Transform top;
        private Transform system;

        public UIManager()
        {
            // 创建Canvas 让其过场景的时候 不被移除
            GameObject obj = ResMgr.GetInstance().Load<GameObject>("UI/Canvas");
            Transform canvas = obj.transform;
            GameObject.DontDestroyOnLoad(obj);

            //找到各层
            bot = canvas.Find("Bot");
            mid = canvas.Find("Mid");
            top = canvas.Find("Top");
            system = canvas.Find("System");

            // EventSystem 让其过场景的时候 不被移除
            obj = ResMgr.GetInstance().Load<GameObject>("UI/EventSystem");
            GameObject.DontDestroyOnLoad(obj);
        }


        /// <summary>
        /// 显示面板
        /// </summary>
        /// <typeparam name="T">面板脚本类型</typeparam>
        /// <param name="panelName">面板名</param>
        /// <param name="layer">显示在哪一层</param>
        /// <param name="callBack">当面板预设体创建成功后 你想做的事</param>
        public void OpenPanel<T>(string panelName, E_UI_Layer layer = E_UI_Layer.Mid, UnityAction<T> callBack = null) where T : BasePanel
        {
            if (panelDic.ContainsKey(panelName))
            {
                //处理面板创建完成后的逻辑
                if (callBack != null)
                    callBack(panelDic[panelName] as T);
            }

            ResMgr.GetInstance().LoadAsync<GameObject>("UI/" + panelName, (obj) =>
             {
             //把他作为Canvas的子对象
             //并且 要设置它的相对位置
             //找到父对象 你到底显示再哪一层
             Transform father = bot;
                 switch (layer)
                 {
                     case E_UI_Layer.Mid:
                         father = mid;
                         break;
                     case E_UI_Layer.Top:
                         father = top;
                         break;
                     case E_UI_Layer.System:
                         father = system;
                         break;
                 }
             //设置父对象
             obj.transform.SetParent(father);

                 obj.transform.localPosition = Vector3.zero;
                 obj.transform.localScale = Vector3.one;

                 (obj.transform as RectTransform).offsetMax = Vector2.zero;
                 (obj.transform as RectTransform).offsetMin = Vector2.zero;

             //得到预设体身上的面板脚本
             T panel = obj.GetComponent<T>();
             //处理面板创建后的逻辑
             if (callBack != null)
                     callBack(panel);

             //把面板存起来
             panelDic.Add(panelName, panel);
             });
        }

        /// <summary>
        /// 隐藏面板
        /// </summary>
        /// <param name="panelName"></param>
        public void ClosePanel(string panelName)
        {
            if (panelDic.ContainsKey(panelName))
            {
                GameObject.Destroy(panelDic[panelName].gameObject);
                panelDic.Remove(panelName);
            }
        }
    }
}
