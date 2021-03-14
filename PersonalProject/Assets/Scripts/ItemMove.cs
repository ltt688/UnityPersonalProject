using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    public float speed = 5.0f;
    public int pointVal;
    public Animator itemAnimation;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x < -15)
            {
                Destroy(gameObject);
            }
        }
    }


    //wall collision effects
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.UpdateScore(pointVal);
            itemAnimation.Play("Collected");
        }
    }
}
