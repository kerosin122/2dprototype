using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HeroController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float jumpForce = 10f;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundLayer;

    public TextMeshProUGUI shotsText;
    [SerializeField]
    private Animator animator;
    [SerializeField]



    private float acceleration = 40f;



    private Rigidbody2D rb;
    private bool isGrounded;

    private float groundCheckRadius = 0.2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);


        // Управление анимациями
        animator.SetBool("isRunning", Mathf.Abs(rb.velocity.x) > 0.1f && isGrounded);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("yVelocity", rb.velocity.y);
        float moveDirection = Input.GetAxis("Horizontal");
        float targetSpeed = moveDirection * moveSpeed;
        // Проверяем, находится ли персонаж в воздухе
        if (!isGrounded)
        {
            // Персонаж в воздухе, используем MoveTowards для плавного изменения скорости
            float newSpeed = Mathf.MoveTowards(rb.velocity.x, targetSpeed, acceleration * Time.deltaTime);
            rb.velocity = new Vector2(newSpeed, rb.velocity.y);
        }
        else
        {
            // Персонаж на земле, можно мгновенно изменить скорость или использовать другой метод
            rb.velocity = new Vector2(targetSpeed, rb.velocity.y);
        }



        // Переключение направления персонажа
        if (moveDirection > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveDirection < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }


        // Прыжок
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

        }




    }
}

