using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_player : MonoBehaviour
{

    public float Speed;

    UI ui;

    Rigidbody2D m_rigidbody2D;

    Vector3 change;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        ui = FindObjectOfType<UI>();
        animator = GetComponent<Animator>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        Di_chuyen_animator();
    }

    private void Di_chuyen_animator()
    {
        if (change != Vector3.zero)
        {
            if (!(transform.position.x <= 4)) change.x -= 1;
            else if (!(transform.position.x >= -4)) change.x += 1;
            if (!(transform.position.y <= 4)) change.y -= 1;
            else if (!(transform.position.y >= -4)) change.y += 1;
            dichuyen();
            animator.SetFloat("MoveX", change.x);
            animator.SetFloat("MoveY", change.y);
            animator.SetBool("Move", true);
        }
        else animator.SetBool("Move", false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("enemy"))
        {
            transform.position = Vector3.zero;
            ui.overgame();
        }
    }

    private void dichuyen()
    {
        m_rigidbody2D.MovePosition(transform.position + change * Speed * Time.deltaTime);
    }

}
