using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


namespace Akari
{
    /// <summary>
    /// 场景切换模块
    /// 知识点
    /// 1.场景异步加载
    /// 2.协程
    /// 3.委托
    /// </summary>
    public class ScenesMgr : Singleton<ScenesMgr>
    {
        /// <summary>
        /// 切换场景 同步
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fun"></param>
        //public void LoadScene(string name, UnityAction fun, LoadSceneMode mode = LoadSceneMode.Additive)
        //{
        //    //场景同步加载
        //    SceneManager.LoadScene(name, mode);
        //    //加载完成后 才回去执行fun
        //    fun();
        //}

        /// <summary>
        /// 提供给外部的 异步加载的接口方法
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fun"></param>
        public void LoadSceneAsyn(string name, UnityAction fun, LoadSceneMode mode = LoadSceneMode.Additive)
        {
            MonoMgr.GetInstance().StartCoroutine(ReallyLoadSceneAsync(name, fun, mode));
        }

        /// <summary>
        /// 协程异步加载场景
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fun"></param>
        /// <returns></returns>
        private IEnumerator ReallyLoadSceneAsync(string name, UnityAction fun, LoadSceneMode mode)
        {
            Scene lastActiveScene = SceneManager.GetActiveScene();
            if(lastActiveScene != null && lastActiveScene.name != "GameStart")
            {
                SceneManager.UnloadSceneAsync(lastActiveScene);
            }

            AsyncOperation ao = SceneManager.LoadSceneAsync(name, mode);
            //可以得到场景加载的一个进度
            while (!ao.isDone)
            {
                //事件中心 向外分发 进度情况 外面想用就用
                EventCenter.GetInstance().EventTrigger(EventType.ProgressBarUpdate, ao.progress);
                //这里更新进度条
                yield return ao.progress;//ao.progress 0到1
            }

            //设置新界面活动性
            var activeScene = SceneManager.GetSceneByName(name);
            if (lastActiveScene != activeScene)
            {
                SceneManager.SetActiveScene(activeScene);
            }

            //加载完成过后 才去执行fun
            fun();
        }

        public void SetActiveScene(string sceneName)
        {
            var scene = SceneManager.GetSceneByName(sceneName);
            if (scene != null)
            {
                SceneManager.SetActiveScene(scene);
            }
            else
            {
                Debug.Log($"Scene {sceneName} 不存在！");
            }
        }
    }
}
