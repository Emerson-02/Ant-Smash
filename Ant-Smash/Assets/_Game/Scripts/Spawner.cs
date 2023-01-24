using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    private float minX, maxX, nextSpawn;
    [SerializeField] private float minDistance, maxDistance, spawnTime;
    [SerializeField] private GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawn = Time.time;
        SetMinAndMaxX();
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    private void SetMinAndMaxX()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.safeArea.width, 0f, 0f)); //Largura da tela
        minX = -bounds.x + minDistance; // -bounds.x = valor lado esquerdo
        maxX = bounds.x + maxDistance; // bounds.x valor lado direito
    }

    private void Spawn()
    {
        if(Time.time > nextSpawn)
        {
            Vector2 position = new Vector2(Random.Range(minX, maxX), transform.position.y);
            Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector2(position.x, position.y), Quaternion.Euler(0f, 0f, 0));
            nextSpawn = Time.time + spawnTime;
        }
    }
}
