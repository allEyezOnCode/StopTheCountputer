using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// With the help of this video https://www.youtube.com/watch?v=LNLVOjbrQj4&t=901s <3
public class Controller : MonoBehaviour
{
    public float Speed = 4f;
    private Camera camera;
    private Vector2 mousePosition;
    private Rigidbody2D rb;
    private Vector2 move;

    private Animator _animator;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
       camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        if((move.x != 0 || move.y != 0) && !_animator.GetCurrentAnimatorStateInfo(0).IsName("walk")) _animator.Play("walk");
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
    }




    void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * Speed * Time.deltaTime);

        Vector2 lookDir = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    public Vector2 GetMousePos()
    {
        return mousePosition;
    }
}
