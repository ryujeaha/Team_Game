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
       P_MOVE();//�̵� ��ư ����
    }

    void P_MOVE()//*�ֿ� ��ɵ��� �Լ��� ���� ���� ���ų� ������ �� ���ؿ�!
    {
         if (Input.GetKey(KeyCode.A)) //Ű���� A ���������� ��
        {
            Debug.Log("AŰ ����");
            transform.Translate(new Vector2(-1f, 0) * P_Speed * Time.deltaTime); //Z�� �̵� �ʿ� ���� �� ���Ƽ� Vector2 ��� *�ſ� ��*
            //*Translate �Լ�:transform�� ���� �Լ���, ��ġ���� ������ ����ŭ ���ؼ� �̵���Ű�� �Լ�.
            //0.01f���� ��� ������ �����ϴ� �� ���ٴ� public�� ����� ���ǵ� ���� �������� �����ϴ� ���� ���� �� �־��!
            /*Time.deltaTime�� �������� �ٲ𶧸��� (1~2���������� �̵��� �� ����) ���������� �ٲ�� �ð��� ��ȯ�ϴ� �Լ�����
            (100�������̶�� �ʴ� 100�� �������� �ٲ�� �������� �ٲ�� �ð��� 0.01�ʸ� ��ȯ�ؿ�), ���⿡���� 1�ʴ� �츮�� ������ ��ġ ������ �̵��ϰ� �ϴ� �����̿���.*/
        }

        if (Input.GetKey(KeyCode.D)) //Ű���� D ���������� ��
        {
            Debug.Log("DŰ ����");
            transform.Translate(new Vector2(1f, 0)* P_Speed * Time.deltaTime);
        }
    }
}
