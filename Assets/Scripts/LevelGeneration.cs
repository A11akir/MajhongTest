using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    private List<Vector2> tilesPositions = new List<Vector2>();
    
    private List<GameObject> rows = new List<GameObject>();
    
    [SerializeField] private GameObject tilePrefab;
    
    private float tileWidth = .9f; 
    private float tileLength = 1.28f;

    private void Start()
    {
        GenerateAndSpawn(3, 3, 2);
        
    }
    
    private void GenerateAndSpawn(int width, int length, int countRows)
    {
        foreach (var row in rows)
            Destroy(row);
        rows.Clear();Ы

        for (int i = 0; i < countRows; i++)
        {
            GameObject rowParent = new GameObject($"Raw{i}");
            rowParent.transform.SetParent(transform);
            rowParent.transform.localPosition = Vector3.zero;
            rowParent.transform.localRotation = Quaternion.identity;
            rowParent.transform.localScale = Vector3.one;

            rows.Add(rowParent);
            
            for (int z = 0; z < length; z++)
            {
                for (int x = 0; x < width; x++)
                {
                    Vector2 position = new Vector2(x * tileWidth + ((tileWidth/2)*i), z * tileLength + (-(tileLength/2)*i));
                    Instantiate(tilePrefab, position, Quaternion.identity, rowParent.transform);
                }
            }
        }
    }
}
