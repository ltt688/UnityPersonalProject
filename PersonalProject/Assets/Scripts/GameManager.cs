using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameActive = true;
    public GameObject bird;
    // Start is called before the first frame update
    void Start()
    {
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
        isGameActive = false;
        Destroy(bird);
        Debug.Log("Game Over");
    }
}
