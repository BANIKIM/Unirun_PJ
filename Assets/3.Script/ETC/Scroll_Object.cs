using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll_Object : MonoBehaviour
{
    [SerializeField]//private�� �����ص� �ɼ��� ������ ������ �� �ִ�.
    private float Speed = 10f;

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isGameover)
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);//Time.deltaTime �ð� ������ �����δ�.

        }
    }
}
