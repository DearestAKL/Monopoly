using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Akari {
    public class MapManager : MonoBehaviour
    {
        [SerializeField]
        private Transform StartPos;

        private ResMgr resources;

        private GameObject[] Cells = new GameObject[50];

        /// <summary>
        /// 最大列
        /// </summary>
        private const int Columns = 10;
        /// <summary>
        /// 最大列
        /// </summary>
        private const int Rows = 10;


        void Start()
        {
            resources = GameEntry.Res;

            GenerateMap();
        }

        void Update()
        {

        }

        private void GenerateMap()
        {
            resources.LoadAsync<GameObject>(AssetUtility.GetPrefabAsset("MapCell"), GenerateCell);
        }

        private void GenerateCell(GameObject obj)
        {
            obj.transform.SetParent(this.transform);
            obj.transform.localPosition = StartPos.localPosition;
            obj.transform.localScale = Vector3.one;
            Cells[0] = obj;

            for (int i = 1; i < Cells.Length; i++)
            {
                var cell = Instantiate(Cells[i-1]);
                cell.transform.SetParent(this.transform);
                cell.transform.localPosition += new Vector3(1.25F, 0, 0); 

            }
        }
    } 
}
