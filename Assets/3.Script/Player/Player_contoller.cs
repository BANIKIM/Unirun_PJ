using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_contoller : MonoBehaviour
{
    //  ���콺�� 2�� �̻� Ŭ�� �ϸ� ������ �� �̻� �ȵǵ��� ����
    // �ִϸ��̼��� ������ �����ؾ� �� Animator - Grounded(Flase)�� ����
    // ������ ����� ���� Rigdbody�� �̿��ؼ� ����
    // addfource ��� �޼��带 ��� �Ѵ�.

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
        //������Ʈ ������ ���� -> ������Ʈ(��ũ��Ʈ) �ʱ�ȭ
        player_r = transform.GetComponent<Rigidbody2D>();
        animater = transform.GetComponent<Animator>();
        audio = transform.GetComponent<AudioSource>();
    }


    private void Update()
    {
        // 1. ����ڰ� �Է� (���콺 ���ʹ�ư)�� �����ϰ� ����ó��
        // 2. ����ī��Ʈ�� Ȯ���ؾ��մϴ�. 
        // 3. Player�� ������ ���̻� ������ �ȵǵ��� �մϴ�.


        if(isDead==true)
        {
            return; // �׳� ����������.
        }
        if (Input.GetMouseButtonDown(0) && JumpCount < 2) //GetMouseButtonDown(0) 0���� ���� 1���� ������
        {
            JumpCount++; // ���� ī���� ����
            //���� ������ �ӵ��� ���������� 0���� ����
            player_r.velocity = Vector2.zero;//�ӵ��� 0,0���� �������
            
            player_r.AddForce(new Vector2(0, JumpForce));//�÷��̾� ������ٵ� y�� +�� ���� �ݴϴ�.
            //�����Ҹ�
            audio.Play();
        } 
        else if(Input.GetMouseButtonUp(0)&&player_r.velocity.y>0)
        //���콺 ���� ��ư�� ����, ������ٵ��� �ӵ� Y���� �����(���-> ���λ����)
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
            //�״� �޼ҵ带 �־��ּ���
            Die();
        }
    }
    private void Die()
    {
        //�÷��̾� ��� Animation ���
        animater.SetTrigger("Die");


        //Clip Jump -> Dead �� ����

        audio.clip = DeadClip;
        audio.Play();

        //�÷��̾��� �ӵ��� ���� 0���� ����� �ּ���
        player_r.velocity = Vector2.zero;

        isDead = true;

        GameManager.Instance.Player_Dead();
    }


    private void OnCollisionEnter2D(Collision2D coll)
    {
        //�÷��̾��� �ݶ��̴��� ����
        //�ٴڿ� ������� �����ϱ� ���� ���
        //��� �ݶ��̴��� �������, �浹ǥ���� ������ ���� �ִٸ�
        if(coll.contacts[0].normal.y>0.7f)
        {
            //���� ������� ǥ��
            isGounded = true;
            //���� ������� ����ī��Ʈ�� 0���� �ʱ�ȭ
            JumpCount = 0;
        }

    }
    private void OnCollisionExit2D(Collision2D coll)
    {
        isGounded = false;
    }
    //�÷��̾� �ݶ��̴� ����
    //��� ���� ������ ���
    /* private void OnCollisionEnter2D(Collision2D coll)
     {
         isGounded = false;
     }*/

}
