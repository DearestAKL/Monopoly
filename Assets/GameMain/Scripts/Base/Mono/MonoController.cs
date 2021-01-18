using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Akari
{
    /// <summary>
    /// Mono的管理者
    /// </summary>
    public class MonoController : MonoBehaviour
    {
        private event UnityAction updataEvent;

        private void Start()
        {

        }

        private void Update()
        {
            if (updataEvent != null)
                updataEvent();
        }

        /// <summary>
        /// 给外部提供的 添加帧更新事件的函数
        /// </summary>
        /// <param name="fun"></param>
        public void AddUpdataListener(UnityAction fun)
        {
            updataEvent += fun;
        }

        /// <summary>
        /// 给外部提供 用于移除帧更新事件的函数
        /// </summary>
        /// <param name="fun"></param>
        public void RemoveUpdataListener(UnityAction fun)
        {
            updataEvent -= fun;
        }
    }
}
