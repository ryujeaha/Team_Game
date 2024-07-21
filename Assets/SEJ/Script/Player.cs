using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float P_Speed; //�̵� �ӵ� ����

    RaycastHit2D hitInfo;//�浹�ߴ��� ����.
    public GameObject scan_Obj;//�浹�� ��ȣ�ۿ� ��ü������ ��� ����.
    Rigidbody2D myrigid;//�� ������ �ٵ带 ���� ����.
    Vector2 dir_vec;//���� ���� ��� �����ִ���.

    Dialogue_Manager the_DM;
    void Awake() {
        myrigid = GetComponent<Rigidbody2D>();
        the_DM = FindObjectOfType<Dialogue_Manager>();//�ش� ��ũ��Ʈ�� ������ �ִ� ��ü���Լ� �� ��ũ��Ʈ������ ������. 
    }
    // Update is called once per frame
    void Update()
    {
       P_MOVE();//�̵� ��ư ����
       Check_Object();
    }

    void P_MOVE()//*�ֿ� ��ɵ��� �Լ��� ���� ���� ���ų� ������ �� ���ؿ�!
    {
        if (Input.GetKey(KeyCode.A)) //Ű���� A ���������� ��
        {
            transform.Translate(new Vector2(-1f, 0) * P_Speed * Time.deltaTime); //Z�� �̵� �ʿ� ���� �� ���Ƽ� Vector2 ��� *�ſ� ��*
            dir_vec = Vector2.left;
            //*Translate �Լ�:transform�� ���� �Լ���, ��ġ���� ������ ����ŭ ���ؼ� �̵���Ű�� �Լ�.
            //0.01f���� ��� ������ �����ϴ� �� ���ٴ� public�� ����� ���ǵ� ���� �������� �����ϴ� ���� ���� �� �־��!
            /*Time.deltaTime�� �������� �ٲ𶧸��� (1~2���������� �̵��� �� ����) ���������� �ٲ�� �ð��� ��ȯ�ϴ� �Լ�����
            (100�������̶�� �ʴ� 100�� �������� �ٲ�� �������� �ٲ�� �ð��� 0.01�ʸ� ��ȯ�ؿ�), ���⿡���� 1�ʴ� �츮�� ������ ��ġ ������ �̵��ϰ� �ϴ� �����̿���.*/
        }

        if (Input.GetKey(KeyCode.D)) //Ű���� D ���������� ��
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

        if(hitInfo.collider != null)//��ȣ�ۿ� ���� ��ü�� �浹 �ߴٸ�.
        {
            scan_Obj = hitInfo.collider.gameObject;
        }
    }
}
