using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    private List<GameObject> rows = new List<GameObject>();
    public List<GameObject> tilesGO = new List<GameObject>();
    
    [SerializeField] private TileManager tileManager;
    
    [SerializeField] private GameObject[] tilesPrefabs;
    
    [SerializeField] private CoordinateTailes coordinateTailes;
    [SerializeField] private TileVisualScript tileVisualScript;
    private float tileWidth = .9f; 
    private float tileLength = 1.28f;

    private void Start()
    {
        GenerateAndSpawn(8, 8, 6);
    }
    
    private void GenerateAndSpawn(int width, int length, int countRows)
    {
        rows.Clear();
        
        for (int i = 0; i < countRows; i++)
        {
            GameObject rowParent = new GameObject($"Raw{i}");
            rowParent.transform.SetParent(transform);
            rowParent.transform.localPosition = Vector3.zero;
            rowParent.transform.localRotation = Quaternion.identity;
            rowParent.transform.localScale = Vector3.one;

            rows.Add(rowParent);
            
            for (int z = 0; z < length - i; z++)
            {
                for (int x = 0; x < width - i; x++)
                {
                    if (length - i <= 1 || width - i <= 1) break;
                    
                    Vector2 position = new Vector2(x * tileWidth + ((tileWidth/2)*i), z * tileLength + ((tileLength/2)*i));
                    GameObject tile = Instantiate(tilesPrefabs[Random.Range(0, tilesPrefabs.Length)], position, Quaternion.identity, rowParent.transform);
                    tilesGO.Add(tile);
                    
                    var tileTag = tile.GetComponent<TileTag>();

                    
                    
                    tileTag.coordinate = new Vector3(x + 1 + (i * 0.5f), z + 1 + (i * 0.5f), i + 1);
                    coordinateTailes.coordinates.Add(new Vector3(x+1 + (i * 0.5f), z+1 + (i * 0.5f), i+1));
                    
                    tileTag.SetManager(tileManager);
                    tileVisualScript.TilesAvailableVisual();

                }
            }
        }
        
        transform.localPosition = new Vector2(-width * tileWidth/2 * 100, -length * tileLength/2 * 100);
    }
}
