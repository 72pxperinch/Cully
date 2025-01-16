using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombManage : MonoBehaviour
{
    private GameObject dummy;
    private SpriteRenderer spriteRenderer;
    public Sprite dummySprite; 
    public Rigidbody2D myRigidbody;
    public bool birdIsAlive = true;
    public bombLogic logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<bombLogic>();

    }

    void Update()
    {
        if (transform.position.y < -4.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            logic.gameOver();
    }
}
