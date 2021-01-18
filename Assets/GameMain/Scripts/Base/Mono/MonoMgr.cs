using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

namespace Akari
{
    public class MonoMgr : Singleton<MonoMgr>
    {
        private MonoController controller;

        public MonoMgr()
        {
            //保证了MonoController对象的唯一性
            GameObject obj = new GameObject("MonoController");
            obj.transform.SetParent(GameEntry.GameEntryTransform);
            controller = obj.AddComponent<MonoController>();
        }

        /// <summary>
        /// 给外部提供 添加帧更新事件的函数
        /// </summary>
        /// <param name="fun"></param>
        public void AddUpdateListener(UnityAction fun)
        {
            controller.AddUpdataListener(fun);
        }

        public void RemoveUpdataListner(UnityAction fun)
        {
            controller.RemoveUpdataListener(fun);
        }

        public Coroutine StartCoroutine(string methodName)
        {
            return controller.StartCoroutine(methodName);
        }

        public Coroutine StartCoroutine(IEnumerator routine)
        {
            return controller.StartCoroutine(routine);
        }

        public Coroutine StartCoroutine_Auto(IEnumerator routine)
        {
            return controller.StartCoroutine(routine);
        }

        public Coroutine StartCoroutine(string methodName, [DefaultValue("null")] object value)
        {
            return controller.StartCoroutine(methodName, value);
        }
    }
}
