using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace Akari
{
    /// <summary>
    /// 面板基类
    /// </summary>
    public class BasePanel : MonoBehaviour
    {
        protected GameObject rootGo
        {
            get
            {
                return this.gameObject;
            }
        }

        void Awake()
        {

        }

        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Init()
        {

        }

        /// <summary>
        /// 显示
        /// </summary>
        public virtual void Open()
        {

        }

        /// <summary>
        /// 隐藏
        /// </summary>
        public virtual void Close()
        {

        }
    }
}
