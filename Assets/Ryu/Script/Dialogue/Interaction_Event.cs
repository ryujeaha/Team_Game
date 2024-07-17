using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_Event : MonoBehaviour
{
    [SerializeField]DialogueEvent dialogue;//����ȭ �� Ŀ���� Ŭ������ ����ϱ� ���� ����.

    public Dialogue[] GetDialogues()//������ ���̽��� �ִ� �������� �������� �Լ�.
    {
        dialogue.dialogues = Database_Manager.instance.GetDialogues((int)dialogue.line.x,(int)dialogue.line.y);/*�����ͺ��̽� �Ŵ������� ���� �Լ��� ȣ���Ͽ� �������µ�/
        vector2�� float�̹Ƿ� int�� ����ȯ.*/
        return dialogue.dialogues;
    }
}
