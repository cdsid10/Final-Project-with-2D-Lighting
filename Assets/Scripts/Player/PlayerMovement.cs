using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    private Vector2 moveInput;
    public float moveSpeed = 5f;
    public Rigidbody2D theRB;
    public Transform gunArm;
    public Animator anim;
    public Transform dLight;

    [SerializeField]
    private float activeMoveSpeed;
    public float dashSpeed = 8f, dashLength = .5f, dashCD = 1f, dashInvincibility = 0.5f;
    [HideInInspector]
    public float dashCounter;
    private float dashCoolCounter;
    public bool canMove = true;

    public SpriteRenderer body;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        activeMoveSpeed = moveSpeed;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Move();

            MouseRotate();

            Dash();
        }
    }

    

    void Move()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        //transform.position += new Vector3(moveInput.x * Time.deltaTime * moveSpeed, moveInput.y * Time.deltaTime * moveSpeed, 0.0f);

        theRB.velocity = moveInput * activeMoveSpeed;

        if(moveInput != Vector2.zero)
        {
            
                anim.SetBool("isWalking", true);
            
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }

    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;

                anim.SetTrigger("dash");

                PlayerHealthController.instance.MakeInvincible(dashInvincibility);
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCD;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }

    void MouseRotate()
    {
        //Mouse Position Variables
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);

        //Flip Character and Weapon with Mouse
        if (mousePos.x < screenPoint.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            gunArm.localScale = new Vector3(-1f, -1f, 1f);
            dLight.localRotation = Quaternion.Euler(0, -180, -90f);
            ShootAnim.instance.chargedText.GetComponent<SpriteRenderer>().flipX = true;
            
            
        }
        else
        {
            transform.localScale = Vector3.one;
            gunArm.localScale = Vector3.one;
            dLight.localRotation = Quaternion.Euler(0, 0, -90f);
            ShootAnim.instance.chargedText.GetComponent<SpriteRenderer>().flipX = false;
           
        }

        //Rotate Weapon with Mouse
        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        gunArm.rotation = Quaternion.Euler(0, 0, angle);

    }
}
