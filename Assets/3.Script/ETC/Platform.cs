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
            //랜덤을 사용해서 장애물 활성화 비활성화
            if(Random.Range(0,3).Equals(0))
            {
                //오브젝트의 활성화 하는 메소드는 SetActive
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
        //플레이어가 플랫폼을 밟았을 때 점수를 얻습니다.
        if(coll.transform.CompareTag("Player")&&!isstep)
        {
            isstep = true;
            GameManager.Instance.AddScore(1);
        }
    }

}
