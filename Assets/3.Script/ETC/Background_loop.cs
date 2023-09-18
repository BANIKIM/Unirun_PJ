using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_loop : MonoBehaviour
{


    private float width;
    // Start is called before the first frame update
    void Start()
    {
        //���̴� BackGround object�� �ڽ� �ݶ��̴� 2D size x�� ������ �;��Ѵ�.
        //transform;
        //gameObject; �� �ΰ����� ������Ʈ�� �������� �ʰ� �ٷ� ���� �� �� �ִ� 

        width = transform.GetComponent<BoxCollider2D>().size.x;
        //width �� �ش� ������Ʈ�� x�ɼ��� ������ �´�.
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
            transform.position = (Vector2)transform.position+offset;//()�� ����ȯ�� �ϱ� ���� ���
            
        }
    }
}
