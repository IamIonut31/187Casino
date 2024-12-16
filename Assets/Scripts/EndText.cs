using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndText : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private TextAsset inkJSON;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player.Kills >= 25 && collision.tag == "Player")
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        }
    }
}
