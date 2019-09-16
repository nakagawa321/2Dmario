using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    private float flap = 500f;
    private float speed = 5.0f;
    private bool jump = false;
    private Vector2 logPosition = new Vector2(0.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody2Dを取得
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("is_state", 0); // 何もない状態

        // 移動
        if (Input.GetKey("right"))
        {
            animator.SetInteger("is_state", 1);
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey("left"))
        {
            animator.SetInteger("is_state", 1);
            transform.position -= transform.right * speed * Time.deltaTime;
        }

        // ジャンプ
        if (Input.GetKeyDown("space") && !jump)
        {
            animator.SetInteger("is_state", 2);
            rb.AddForce(Vector2.up * flap);
            jump = true;
        }

        // 落下中か
        if(transform.position.y < logPosition.y)
        {
            animator.SetInteger("is_state", 3);
        }
        logPosition.y = transform.position.y;
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        jump = false;        
    }

}
