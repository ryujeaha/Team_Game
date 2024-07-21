using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float P_Speed; //이동 속도 변수

    RaycastHit2D hitInfo;//충돌했는지 여부.
    public GameObject scan_Obj;//충돌한 상호작용 객체정보를 담는 변수.
    Rigidbody2D myrigid;//내 리지드 바드를 담을 변수.
    Vector2 dir_vec;//현재 내가 어디를 보고있는지.

    Dialogue_Manager the_DM;
    void Awake() {
        myrigid = GetComponent<Rigidbody2D>();
        the_DM = FindObjectOfType<Dialogue_Manager>();//해당 스크립트를 가지고 있는 객체에게서 이 스크립트정보를 가져옴. 
    }
    // Update is called once per frame
    void Update()
    {
       P_MOVE();//이동 버튼 판정
       Check_Object();
    }

    void P_MOVE()//*주요 기능들은 함수로 묶는 것이 보거나 수정할 때 편해요!
    {
        if (Input.GetKey(KeyCode.A)) //키보드 A 누르는중일 시
        {
            transform.Translate(new Vector2(-1f, 0) * P_Speed * Time.deltaTime); //Z축 이동 필요 없을 것 같아서 Vector2 사용 *매우 굿*
            dir_vec = Vector2.left;
            //*Translate 함수:transform의 하위 함수로, 위치값을 정해준 값만큼 더해서 이동시키는 함수.
            //0.01f등의 상수 값으로 조정하는 것 보다는 public을 사용한 스피드 값의 조정으로 조절하는 것이 편할 수 있어요!
            /*Time.deltaTime은 프레임이 바뀔때마다 (1~2프레임으로 이동할 때 마다) 한프레임이 바뀌는 시간을 반환하는 함수에요
            (100프레임이라면 초당 100번 프레임이 바뀌니 프레임이 바뀌는 시간인 0.01초를 반환해요), 여기에서는 1초당 우리가 지정한 위치 값으로 이동하게 하는 역할이에요.*/
        }

        if (Input.GetKey(KeyCode.D)) //키보드 D 누르는중일 시
        {  
            transform.Translate(new Vector2(1f, 0)* P_Speed * Time.deltaTime);
            dir_vec =Vector2.right;
        }

        if(Input.GetKeyDown(KeyCode.E) && scan_Obj != null)
        {
          
            the_DM.Show_Dialogue(hitInfo.transform.GetComponent<Interaction_Event>().GetDialogues());
        }
    }

    void  Check_Object(){
        Debug.DrawRay(myrigid.position +new Vector2(dir_vec.x *0.5f , dir_vec.y* 0.5f ),dir_vec * 0.7f,new Color(0,1,0));
        hitInfo = Physics2D.Raycast(myrigid.position +new Vector2(dir_vec.x *0.5f , dir_vec.y* 0.5f ),dir_vec * 0.7f,LayerMask.GetMask("Object"));

        if(hitInfo.collider != null)//상호작용 가능 객체와 충돌 했다면.
        {
            scan_Obj = hitInfo.collider.gameObject;
        }
    }
}
