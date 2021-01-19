using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akari
{
    public static class AssetUtility
    {
        public static string GetUIAsset(string assetName)
        {
            return string.Format("UI/{0}", assetName);
        }

        public static string GetImageAsset(string assetName)
        {
            return string.Format("Image/{0}", assetName);
        }

        public static string GetPrefabAsset(string assetName)
        {
            return string.Format("Prefab/{0}", assetName);
        }
    }
}
