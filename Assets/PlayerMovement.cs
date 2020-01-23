using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveInput;
    public float moveSpeed = 5f;
    public Rigidbody2D theRB;
    public Transform gunArm;

    public bool facingRight;

    private float activeMoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        transform.position += new Vector3(moveInput.x * Time.deltaTime * moveSpeed, moveInput.y * Time.deltaTime * moveSpeed, 0.0f);

        theRB.velocity = moveInput * moveSpeed;

        //FlipPlayer();

        //Mouse Position Variables
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);

        //Flip Character and Weapon with Mouse
        if (mousePos.x < screenPoint.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            gunArm.localScale = new Vector3(-1f, -1f, 1f);
        }
        else
        {
            transform.localScale = Vector3.one;
            gunArm.localScale = Vector3.one;
        }

        //Rotate Weapon with Mouse
        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        gunArm.rotation = Quaternion.Euler(0, 0, angle);

    }

    /*private void FlipPlayer()
    {
        if (moveInput.x < 0)
        {
            facingRight = false;
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        else if (moveInput.x > 0)
        {
            facingRight = true;
            transform.localRotation = Quaternion.Euler(0, 0, -90);
        }
    } */
}
