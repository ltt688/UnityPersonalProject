using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public GameObject bird;

    //ui variables
    public GameObject titleScreen;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public Button restartButton;
    public Button fireButton;
    public GameObject projectilePrefab;
    public List<GameObject> itemPrefabs;

    private ObstaclesGenerator obstaclesGenerator;
    private int score;
    private float time;
    private float spawnInterval = 4.5f;

    // Start is called before the first frame update
    void Start()
    {
        obstaclesGenerator = GameObject.Find("ObstaclesGenerator").GetComponent<ObstaclesGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateTimeScore();
        if (isGameActive)
        {
            UpdateTimeScore();

            if (bird.transform.position.y < -5.5 || bird.transform.position.y > 5.5)
            {
                GameOver();
                Debug.Log("GameOver:out of range");
            }
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

        isGameActive = false;
        Destroy(bird);
        Debug.Log("Game Over");
    }

    
    //start game, remove title screen, spawn obstacles, start moving obstacles
    public void StartGame()
    {
        titleScreen.gameObject.SetActive(false);
        isGameActive = true;
        fireButton.gameObject.SetActive(true);
        score = 0;
        time = 0;
        //breaks game i'm not sure why
        //UpdateScore(0);
        obstaclesGenerator.GenerateObstacles();
        StartCoroutine(SpawnItemRoutine());
        bird.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(false);
        //in this order UpdateScore works
        UpdateScore(0);
    }


    IEnumerator SpawnItemRoutine()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnInterval);
            Vector3 spawnLocation = new Vector3(Random.Range(0, 8), Random.Range(-4, 4), 0);
            int index = Random.Range(0, itemPrefabs.Count);

            if (isGameActive)
            {
                Instantiate(itemPrefabs[index], spawnLocation, itemPrefabs[index].transform.rotation);
            }
        }
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //update score, no current conditions
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    //timer update
    public void UpdateTimeScore()
    {
        timeText.text = "Time: " + Mathf.Round(time);
        time += Time.deltaTime;
    }

    //fire projectile from bird
    public void FireBirdProjectile()
    {
        Instantiate(projectilePrefab, bird.transform.position, projectilePrefab.transform.rotation);
        if (transform.position.x > 15)
        {
            Destroy(gameObject);
        }
    }
}
