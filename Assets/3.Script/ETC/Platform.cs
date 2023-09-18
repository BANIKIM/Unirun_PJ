using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] Obstacles;
    private bool isstep = false;

    private void OnEnable()
    {
        isstep = false;
        for(int i=0; i<Obstacles.Length; i++)
        {
            //������ ����ؼ� ��ֹ� Ȱ��ȭ ��Ȱ��ȭ
            if(Random.Range(0,3).Equals(0))
            {
                //������Ʈ�� Ȱ��ȭ �ϴ� �޼ҵ�� SetActive
                Obstacles[i].SetActive(true);
            }
            else
            {
                Obstacles[i].SetActive(false);

            }
        }
    }


    private void OnCollisionEnter2D(Collision2D coll)
    {
        //�÷��̾ �÷����� ����� �� ������ ����ϴ�.
        if(coll.transform.CompareTag("Player")&&!isstep)
        {
            isstep = true;
            GameManager.Instance.AddScore(1);
        }
    }

}
