using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject EndScreen;

    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private TextAsset inkJSON2;

    [SerializeField] private Animator anim;
    [SerializeField] private GameObject Weapon;

    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb2d;
    private Vector2 moveInput;

    private Vector2 mousePositon;
    [SerializeField] private Camera sceneCamera;
    public Weapon weapon;

    public int Ammo = 10;
    [SerializeField] private TextMeshProUGUI AmmoNumber;

    [SerializeField] private TextMeshProUGUI KillsNumber;
    public int Kills = 0;

    void Start()
    {
        StartCoroutine(StartDialogue());
    }

    void Update()
    {
        moveInput.x = InputManager.GetInstance().GetMoveDirection().x;
        moveInput.y = InputManager.GetInstance().GetMoveDirection().y;
        moveInput.Normalize();

        mousePositon = sceneCamera.ScreenToWorldPoint(InputManager.GetInstance().GetMousePosition());
        if(InputManager.GetInstance().GetShootPressed() && Ammo > 0 && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            weapon.Fire();
            Ammo -= 1;
            AmmoNumber.text = Ammo.ToString();
            if(Ammo == 0)
            {
                //DialogueManager.GetInstance().EnterDialogueMode(inkJSON2);
            }
        }

        if(Ammo == 0)
        {
            Weapon.SetActive(false);
            anim.SetBool("Weapon", false);
        }
        else
        {
            Weapon.SetActive(true);
            anim.SetBool("Weapon", true);
        }
        anim.SetFloat("Speed", moveInput.sqrMagnitude);
    }
    private void FixedUpdate()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("IdleWeapon") || !anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                if(Ammo == 0)
                {
                    anim.Play("Idle");
                }
                else
                {
                    anim.Play("IdleWeapon");
                }
            }
            rb2d.velocity = new Vector2(0, 0);
            return;
        }
        rb2d.velocity = moveInput * moveSpeed;
        Vector2 aimDirection = mousePositon - rb2d.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb2d.rotation = aimAngle;
    }

    public void AmmoBox()
    {
        Ammo += 10;
        AmmoNumber.text = Ammo.ToString();
    }

    public void Kill()
    {
        Kills += 1;
        KillsNumber.SetText(Kills.ToString() + "/25");
    }

    private IEnumerator StartDialogue()
    {
        yield return new WaitForSeconds(1f);
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            EndScreen.SetActive(true);
            anim.Play("Die");
        }
    }
}
