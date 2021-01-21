using GameFramework.Resource;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Akari
{
    public class NormalGame : GameBase
    {
        private GameData gameData;//游戏数据
        private int playerCount;

        private GameMap gameMap;//游戏地图
        private int maxStepCount;//最大步数

        private List<GameObject> players;//玩家对象
        private int curPlayerId = 0;

        public override GameMode GameMode
        {
            get
            {
                return gameData.gameMode;
            }
        }

        public override void Initialize()
        {
            base.Initialize();

            gameData = new GameData(GameMode.Normal);
            gameData.AddPlayer(new PlayerData(0, "akl", 0));
            gameData.AddPlayer(new PlayerData(1, "sxt", 0));
            playerCount = gameData.playerDatas.Count;

            gameMap = Object.FindObjectOfType<GameMap>();
            maxStepCount = gameMap.posArray.Length;

            //生成角色对象
            for (int i = 0; i < playerCount; i++)
            {
                var assetName = gameData.playerDatas[i].assetName;
                GameEntry.Resource.LoadAsset(AssetUtility.GetEntityAsset(assetName), typeof(GameObject), new LoadAssetCallbacks(
                        (assetName, asset, duration, userData) =>
                        {
                            var go = GameObject.Instantiate(asset as GameObject);
                            go.transform.SetParent(gameMap.posArray[0]);
                            go.transform.localPosition = Vector3.zero;
                            go.transform.localRotation = Quaternion.identity;
                            players.Add(go);
                        }));
            }
        }

        public override void Shutdown()
        {
            base.Shutdown();
            gameData = null;
        }

        public override void SaveGame()
        {
            base.SaveGame();
            GameEntry.Setting.SaveGame(gameData);
        }

        public override void Update(float elapseSeconds, float realElapseSeconds)
        {
            base.Update(elapseSeconds, realElapseSeconds);
        }

        private void PlayerMove(int index)
        {
            //骰子
            var StepCount = Random.Range(0, 6);


            var playerData = gameData.playerDatas[index];

            playerData.pos += StepCount;
            if(playerData.pos >= maxStepCount - 1)
            {
                playerData.pos = maxStepCount - 1;
            }
        }
    }
}
