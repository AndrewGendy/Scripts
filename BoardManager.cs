using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

    [SerializeField]
    public class Count {
        public int minimum;
        public int maximum;

        public Count(int min, int max) {
            minimum = min;
            maximum = max;
        }
    }

    public int columns = 8;
    public int rows = 8;
    public Count obstacles = new Count(10, 20);
    public GameObject bottomLeftCorner;
    public GameObject bottomRightCorner;
    public GameObject topLeftCorner;
    public GameObject topRightCorner;
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject[] floorTiles;
    public GameObject[] bottomWallTiles;
    public GameObject[] topWallTiles;
    public GameObject[] obstacleTiles;

    private Transform boardHolder;
    private List<Vector3> gridPos = new List<Vector3>();

    void InitilizeList() {
        gridPos.Clear();

        for (int x = 1; x < columns - 1; x++) {
            for (int y = 1; y < rows - 1; y++) {
                gridPos.Add(new Vector3(x, y, 0f));
            }

        }
    }

    void BoardSetup() {
        boardHolder = new GameObject("Board").transform;

        for (int x = -1; x < columns + 1; x++) {
            for (int y = -1; y < rows + 1; y++) {
                GameObject toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];
                //if (x == -1 || x == columns || y == -1 || y == rows)
                //    toInstantiate = topWallTiles[Random.Range(0, topWallTiles.Length)];

                if (x == -1 && y == -1)
                    toInstantiate = bottomLeftCorner;
                else if (x == columns && y == -1)
                    toInstantiate = bottomRightCorner;
                else if (x == -1 && y == rows)
                    toInstantiate = topLeftCorner;
                else if (x == columns && y == rows)
                    toInstantiate = topRightCorner;
                else if (y == -1 && (x > -1 && x < columns))
                    toInstantiate = bottomWallTiles[Random.Range(0, bottomWallTiles.Length)];
                else if (y == rows && (x > -1 && x < columns))
                    toInstantiate = topWallTiles[Random.Range(0, topWallTiles.Length)];
                else if (x == -1 && y > -1 && y < rows)
                    toInstantiate = leftWall;
                else if (x == columns && y > -1 && y < rows)
                    toInstantiate = rightWall;


                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(boardHolder);
            }
        }
        BoxCollider2D bc = (BoxCollider2D)boardHolder.gameObject.AddComponent(typeof(BoxCollider2D));
        //bc. = Vector3.zero;
        //boardHolder.gameObject.AddComponent<BoxCollider2D>();
    }

    Vector3 RandomPosition() {
        int randomIndex = Random.Range(0, gridPos.Count);
        Vector3 randomPosition = gridPos[randomIndex];
        gridPos.RemoveAt(randomIndex);
        return randomPosition;
    }

    void LayoutObstaclesAtRandom(GameObject[] tileArray, int minimum, int maximum) {
        int objCount = Random.Range(minimum, maximum + 1);

        for (int i = 0; i < objCount; i++) {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            GameObject instance = Instantiate(tileChoice, new Vector3(randomPosition.x, randomPosition.y, -1.0f), Quaternion.identity);
            instance.transform.SetParent(boardHolder);
        }
    }

    public void SetupScene(/*int level (can put level here)*/) {
        BoardSetup();
        InitilizeList();
        LayoutObstaclesAtRandom(obstacleTiles, obstacles.minimum, obstacles.maximum);

    }
}