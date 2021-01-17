using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Akari
{
    /// <summary>
    /// 单例基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> where T : new()
    {
        private static T instance;

        public static T GetInstance()
        {
            if (instance == null)
                instance = new T();
            return instance;
        }

        public virtual void Init()
        {
            return;
        }

        /// <summary>
        /// 释放
        /// </summary>
        public virtual void Release()
        {
            return;
        }
    }
}