using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public float speed = 5.0f;
    private GameManager gameManager;
    private Vector3 initPos;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x < -12.4)
            {
                transform.position = initPos;
            }
        }
    }
}
