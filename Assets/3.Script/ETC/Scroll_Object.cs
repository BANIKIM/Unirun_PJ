using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll_Object : MonoBehaviour
{
    [SerializeField]//private로 선언해도 옵션을 밖으로 보여줄 수 있다.
    private float Speed = 10f;

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isGameover)
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);//Time.deltaTime 시간 단위로 움직인다.

        }
    }
}
