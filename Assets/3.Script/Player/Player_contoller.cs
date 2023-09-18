using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_contoller : MonoBehaviour
{
    //  마우스를 2번 이상 클릭 하면 점프가 더 이상 안되도록 만듬
    // 애니메이션을 점프로 변경해야 함 Animator - Grounded(Flase)로 만듬
    // 점프를 사용할 때는 Rigdbody를 이용해서 만듬
    // addfource 라는 메서드를 사용 한다.

    public AudioClip DeadClip;

    [SerializeField]
    private float JumpForce = 700f;

    private int JumpCount = 0;
    private bool isGounded = false;
    private bool isDead = false;

    private Rigidbody2D player_r;
    private Animator animater;
    private AudioSource audio;

    private void Start()
    {
        //컴포넌트 가지고 오기 -> 컴포넌트(스크립트) 초기화
        player_r = transform.GetComponent<Rigidbody2D>();
        animater = transform.GetComponent<Animator>();
        audio = transform.GetComponent<AudioSource>();
    }


    private void Update()
    {
        // 1. 사용자가 입력 (마우스 왼쪽버튼)을 감지하고 점프처리
        // 2. 점프카운트를 확인해야합니다. 
        // 3. Player가 죽으면 더이상 실행이 안되도록 합니다.


        if(isDead==true)
        {
            return; // 그냥 빠져나간다.
        }
        if (Input.GetMouseButtonDown(0) && JumpCount < 2) //GetMouseButtonDown(0) 0번이 왼쪽 1번이 오른쪽
        {
            JumpCount++; // 점프 카운터 증가
            //점프 직전의 속도를 순간적으로 0으로 변경
            player_r.velocity = Vector2.zero;//속도를 0,0으로 만들어줌
            
            player_r.AddForce(new Vector2(0, JumpForce));//플레이어 리지드바디에 y의 +로 힘을 줍니다.
            //점프소리
            audio.Play();
        } 
        else if(Input.GetMouseButtonUp(0)&&player_r.velocity.y>0)
        //마우스 왼쪽 버튼을 때고, 리지드바디의 속도 Y값이 양수면(양수-> 위로상승중)
        {
            player_r.velocity = player_r.velocity * 0.5f;
        }
        //Gounded
        animater.SetBool("Gounded", isGounded);


    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Dead") &&!isDead)
        {
            //죽는 메소드를 넣어주세요
            Die();
        }
    }
    private void Die()
    {
        //플레이어 사망 Animation 출력
        animater.SetTrigger("Die");


        //Clip Jump -> Dead 로 변경

        audio.clip = DeadClip;
        audio.Play();

        //플레이어의 속도를 무도 0으로 만들어 주세요
        player_r.velocity = Vector2.zero;

        isDead = true;

        GameManager.Instance.Player_Dead();
    }


    private void OnCollisionEnter2D(Collision2D coll)
    {
        //플레이어의 콜라이더의 기준
        //바닥에 닿았음을 감지하기 위해 사용
        //어떠한 콜라이더가 닿았으며, 충돌표면이 위쪽을 보고 있다면
        if(coll.contacts[0].normal.y>0.7f)
        {
            //땅에 닿았음을 표시
            isGounded = true;
            //땅에 닿았으니 점프카운트는 0으로 초기화
            JumpCount = 0;
        }

    }
    private void OnCollisionExit2D(Collision2D coll)
    {
        isGounded = false;
    }
    //플레이어 콜라이더 기준
    //닿는 것이 끝났을 경우
    /* private void OnCollisionEnter2D(Collision2D coll)
     {
         isGounded = false;
     }*/

}
