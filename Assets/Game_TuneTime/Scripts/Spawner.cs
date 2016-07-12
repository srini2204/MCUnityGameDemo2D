using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{

    public enum PieceType
    {
        NORMAL,
        ENEMY,
    };

    [System.Serializable]
    public struct PiecePrefab
    {
        public PieceType type;
        public GameObject prefab;
    };

    public PiecePrefab[] prefabs;
    private Dictionary<PieceType, GameObject> piecePrefabDict;

    public int amount = 20;

    private GameObject[] pieces;

    void Start()
    {

        piecePrefabDict = new Dictionary<PieceType, GameObject>();

        for (int i = 0; i < prefabs.Length; i++)
        {
            if (!piecePrefabDict.ContainsKey(prefabs[i].type))
            {
                piecePrefabDict.Add(prefabs[i].type, prefabs[i].prefab);
            }
        }
        pieces = new GameObject[amount];
        for (int x = 0; x < amount; x++)
        {

            pieces[x] = (GameObject)Instantiate(piecePrefabDict[PieceType.NORMAL], Vector3.zero, Quaternion.identity);
            pieces[x].name = "Piece(" + x + ")";
            pieces[x].transform.SetParent(transform, false);

        }
    }

}

