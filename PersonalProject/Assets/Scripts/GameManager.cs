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
    public Button restartButton;
    private ObstaclesGenerator obstaclesGenerator;
    // Start is called before the first frame update
    void Start()
    {
        obstaclesGenerator = GameObject.Find("ObstaclesGenerator").GetComponent<ObstaclesGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
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
        obstaclesGenerator.GenerateObstacles();
        bird.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(false);
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
