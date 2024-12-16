using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verify : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private Rigidbody2D BossDoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player.Kills < 25 && collision.tag == "Player")
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            collision.transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y + 2);
        }
        else
        {
            if(player.Kills >= 25 && collision.tag == "Player")
            {
                BossDoor.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}
