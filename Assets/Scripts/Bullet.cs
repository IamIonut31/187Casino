using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Wall":
                Destroy(gameObject);
                break;
            case "Enemy":
                player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
                Destroy(gameObject);
                collision.gameObject.GetComponent<Animator>().Play("Die");
                player.Kill();
                break;
        }
    }
}
