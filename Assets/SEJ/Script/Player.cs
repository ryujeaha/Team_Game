using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) //Ű���� A ���������� ��
        {
            Debug.Log("AŰ ����");
            transform.Translate(new Vector2(-0.006f, 0)); //Z�� �̵� �ʿ� ���� �� ���Ƽ� Vector2 ���
        }

        if (Input.GetKey(KeyCode.D)) //Ű���� D ���������� ��
        {
            Debug.Log("DŰ ����");
            transform.Translate(new Vector2(0.006f, 0));
        }
    }
}
