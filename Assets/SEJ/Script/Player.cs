using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float P_Speed; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       P_MOVE();//이동 버튼 판정
    }

    void P_MOVE()//*주요 기능들은 함수로 묶는 것이 보거나 수정할 때 편해요!
    {
         if (Input.GetKey(KeyCode.A)) //키보드 A 누르는중일 시
        {
            Debug.Log("A키 누름");
            transform.Translate(new Vector2(-1f, 0) * P_Speed * Time.deltaTime); //Z축 이동 필요 없을 것 같아서 Vector2 사용 *매우 굿*
            //*Translate 함수:transform의 하위 함수로, 위치값을 정해준 값만큼 더해서 이동시키는 함수.
            //0.01f등의 상수 값으로 조정하는 것 보다는 public을 사용한 스피드 값의 조정으로 조절하는 것이 편할 수 있어요!
            /*Time.deltaTime은 프레임이 바뀔때마다 (1~2프레임으로 이동할 때 마다) 한프레임이 바뀌는 시간을 반환하는 함수에요
            (100프레임이라면 초당 100번 프레임이 바뀌니 프레임이 바뀌는 시간인 0.01초를 반환해요), 여기에서는 1초당 우리가 지정한 위치 값으로 이동하게 하는 역할이에요.*/
        }

        if (Input.GetKey(KeyCode.D)) //키보드 D 누르는중일 시
        {
            Debug.Log("D키 누름");
            transform.Translate(new Vector2(1f, 0)* P_Speed * Time.deltaTime);
        }
    }
}
