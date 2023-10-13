using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManeger : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLenght = 26;
    public int numberOfTiles = 5;
    public Transform playerTransform;
    private List<GameObject> activeTiles = new List<GameObject>();
    public int index;
    public GameObject carholder;


    // Start is called before the first frame update
    void Start()
    {
        SpawnBeginTile(43);
        for (int i = 0; i < numberOfTiles; i++)
        {
            SpawnTile(42);
            SpawnTile(Random.Range(0, tilePrefabs.Length - 2));

        }
    }
    // Update is called once per frame
    void Update()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");
        playerTransform = carholder.transform.GetChild(index);
        if (playerTransform.position.z - tileLenght + 5 > zSpawn - 150 - (numberOfTiles * tileLenght))
        {
            SpawnTile(42);
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }

    }
    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLenght;
    }  
    public void SpawnBeginTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        zSpawn += tileLenght;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
