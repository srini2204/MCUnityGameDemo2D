using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ToyBox.TuneTime
{
    public class Spawner : MonoBehaviour
    {

        public PieceAttributes[] prefabs;
        private Dictionary<PieceType, GameObject> piecePrefabDict;

        void Start()
        {
            piecePrefabDict = new Dictionary<PieceType, GameObject>();

            for (int i = 0; i < prefabs.Length; i++)
            {
                if (!piecePrefabDict.ContainsKey(prefabs[i].type))
                {
                    //piecePrefabDict.Add(prefabs[i].type, prefabs[i]);
                }
            }
        }

    }
}