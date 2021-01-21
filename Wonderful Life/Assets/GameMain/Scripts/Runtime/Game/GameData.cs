using System.Collections.Generic;

namespace Akari
{
    public class GameData
    {
        //游戏唯一id
        public int gameId;
        public GameMode gameMode;
        public List<PlayerData> playerDatas = new List<PlayerData>();

        public GameData(GameMode gameMode)
        {
            this.gameMode = gameMode;
        }

        public void AddPlayer(PlayerData playerData)
        {
            for (int i = 0; i < playerDatas.Count; i++)
            {
                if (playerDatas[i].id == playerData.id)
                {
                    //已经存在 该游戏玩家
                    return;
                }
            }

            playerDatas.Add(playerData);
        }
    }
}
