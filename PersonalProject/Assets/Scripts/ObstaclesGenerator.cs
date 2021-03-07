using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGenerator : MonoBehaviour
{
    public GameObject obstacle;
    private float spawnRate = 2.0f;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateObstacles()
    {
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (gameManager.isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            float y_size = Random.Range(2, 4);
            Vector3 scale = obstacle.transform.localScale;
            scale.y = y_size;
            obstacle.transform.localScale = scale;
            Vector3 pos = obstacle.transform.position;
            pos.y = 5 - y_size/2;
            obstacle.transform.position = pos;
            Instantiate(obstacle);
            y_size = Random.Range(2, 4);
            scale = obstacle.transform.localScale;
            scale.y = y_size;
            obstacle.transform.localScale = scale;
            pos = obstacle.transform.position;
            pos.y = -5 + y_size / 2;
            obstacle.transform.position = pos;
            Instantiate(obstacle);
        }
    }
}
