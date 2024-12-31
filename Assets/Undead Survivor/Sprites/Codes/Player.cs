using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public Vector2 inputVec;

    Rigidbody2D rigid;
    public float speed;
    SpriteRenderer spriter;
    Animator anim;
    public Scanner scanner;


    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
    }

    // Update is called once per frame
    // void Update()
    // {
    //     inputVec.x = Input.GetAxis("Horizontal");
    //     inputVec.y = Input.GetAxis("Vertical");
    // }

    // void FixedUpdate()
    // {
    //     // 1. 힘들 준다
    //     rigid.AddForce(inputVec);
    //
    //     // 2. 속도 제어
    //     rigid.velocity = inputVec;
    //
    //     // 3. 위치 이동
    //     rigid.MovePosition(rigid.position + inputVec);
    // }

    // 물리이동 구현
    private void FixedUpdate()
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }

    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);
        

        if( inputVec.x != 0 ){
            spriter.flipX = inputVec.x < 0;
        }
    }
}
