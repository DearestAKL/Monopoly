﻿//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using UnityEngine;

namespace Akari
{
    /// <summary>
    /// 游戏入口。
    /// </summary>
    public partial class GameEntry : MonoBehaviour
    {
        private void Start()
        {
            InitBuiltinComponents();
            InitCustomComponents();

            AtlasHelper = new AtlasHelperComponent();
            AtlasHelper.Initialize();
        }

        /// <summary>
        /// 图集图片管理组件
        /// </summary>
        public static AtlasHelperComponent AtlasHelper
        {
            get;
            private set;
        }
    }
}
