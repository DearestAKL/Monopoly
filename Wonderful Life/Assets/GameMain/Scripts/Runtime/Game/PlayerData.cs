namespace Akari
{
    public class PlayerData
    {
        public string assetName;

        public int id;
        public string name;
        public int pos;
        public PlayerData(int id,string name,int pos)
        {
            this.id = id;
            this.name = name;
            this.pos = pos;
        }
    }
}
