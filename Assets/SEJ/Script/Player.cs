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
        if (Input.GetKey(KeyCode.A)) //키보드 A 누르는중일 시
        {
            Debug.Log("A키 누름");
            transform.Translate(new Vector2(-0.006f, 0)); //Z축 이동 필요 없을 것 같아서 Vector2 사용
        }

        if (Input.GetKey(KeyCode.D)) //키보드 D 누르는중일 시
        {
            Debug.Log("D키 누름");
            transform.Translate(new Vector2(0.006f, 0));
        }
    }
}
