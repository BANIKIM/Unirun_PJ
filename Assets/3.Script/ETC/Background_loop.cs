using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_loop : MonoBehaviour
{


    private float width;
    // Start is called before the first frame update
    void Start()
    {
        //넓이는 BackGround object의 박스 콜라이더 2D size x를 가지고 와야한다.
        //transform;
        //gameObject; 이 두가지는 컴포넌트를 선언하지 않고도 바로 가져 올 수 있다 

        width = transform.GetComponent<BoxCollider2D>().size.x;
        //width 에 해당 컴포넌트의 x옵션을 가지고 온다.
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameover)
        {
            return;
        }
        if (transform.position.x<=-width)
        {
            Vector2 offset = new Vector2(width * 2f, 0);
            transform.position = (Vector2)transform.position+offset;//()는 형변환을 하기 위해 사용
            
        }
    }
}
