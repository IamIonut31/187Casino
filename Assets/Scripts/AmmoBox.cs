using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private AudioSource Reload;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.AmmoBox();
            Reload.Play();
            Destroy(this.gameObject);
        }
    }
}
