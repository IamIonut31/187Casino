using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform target;
    [SerializeField] private float minimumDistance;

    [SerializeField] private FieldOfView fov;
    [SerializeField] private AIPath aip;
    [SerializeField] private Player player;

    [SerializeField] private Animator anim;
    private Vector3 vdiff;
    private float atan2;

    [SerializeField] private Rigidbody2D rb2d;
    //private bool run;

    void FixedUpdate()
    {
        if(fov.canSeePlayer == true)
        {
            if (player.Ammo == 0)
            {
                //run = false;
                anim.SetBool("Weapon", true);
                anim.SetBool("Run", true);
                aip.canMove = true;
            }
            else
            {
                anim.SetBool("Run", true);
                anim.SetBool("Weapon", false);
                aip.canMove = false;
                //run = true;
                if (Vector2.Distance(transform.position, target.position) < minimumDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);

                    vdiff = target.transform.position - transform.position;
                    atan2 = Mathf.Atan2(vdiff.y, vdiff.x);
                    transform.rotation = Quaternion.Euler(0f, 0f, 180 + (atan2 * Mathf.Rad2Deg - 90f));
                }
            }
        }
    }
    /*
    private void Update()
    {
        if(run)
        {
            if (Vector2.Distance(transform.position, target.position) < minimumDistance)
            {
                rb2d.AddForce((transform.position - target.position) / speed, ForceMode2D.Force);

                vdiff = target.transform.position - transform.position;
                atan2 = Mathf.Atan2(vdiff.y, vdiff.x);
                transform.rotation = Quaternion.Euler(0f, 0f, 180 + (atan2 * Mathf.Rad2Deg - 90f));
            }
        }
    }
    /*
    if (Vector2.Distance(transform.position, target.position) < minimumDistance)
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);

        vdiff = target.transform.position - transform.position;
        atan2 = Mathf.Atan2(vdiff.y, vdiff.x);
        transform.rotation = Quaternion.Euler(0f, 0f, 180 + (atan2 * Mathf.Rad2Deg - 90f));
    }
    if (Vector2.Distance(transform.position, target.position) < minimumDistance)
    {
        rb2d.AddForce((transform.position - target.position) / speed);

        vdiff = target.transform.position - transform.position;
        atan2 = Mathf.Atan2(vdiff.y, vdiff.x);
        transform.rotation = Quaternion.Euler(0f, 0f, 180 + (atan2 * Mathf.Rad2Deg - 90f));
    }
    */
}
