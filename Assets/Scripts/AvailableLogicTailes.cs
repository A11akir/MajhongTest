using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class AvailableLogicTailes : MonoBehaviour
{
    [SerializeField] TileManager tileManager;
    [SerializeField] CoordinateTailes coordinateTailes;

    public bool CheckObstruction(GameObject tile)
    {
        TileTag tileTag = tile.GetComponent<TileTag>();
        Vector3 currentCoord = tileTag.coordinate;

        List<Vector3> allCoordinates = coordinateTailes.coordinates;

        bool hasLeft = false;
        bool hasRight = false;
        bool hasUp = false;

        foreach (Vector3 other in allCoordinates)
        {
            // Соседи слева и справа (на том же уровне z)
            if (currentCoord.z == other.z)
            {
                if (currentCoord.x == other.x + 1 && currentCoord.y == other.y)
                    hasLeft = true;

                if (currentCoord.x == other.x - 1 && currentCoord.y == other.y)
                    hasRight = true;
            }

            // Плитки выше — на z+1
            if (currentCoord.z + 1 == other.z)
            {
                // Проверка: если верхняя плитка перекрывает текущую
                float dx = Mathf.Abs(currentCoord.x - other.x);
                float dy = Mathf.Abs(currentCoord.y - other.y);

                if (dx <= 0.5f && dy <= 0.5f)  // перекрывает по площади 3x3
                {
                    hasUp = true;
                }
            }

            // Если перекрыта сверху или зажата по бокам
            if (hasUp || (hasLeft && hasRight))
                return false;
        }

        return true;
    }
}

