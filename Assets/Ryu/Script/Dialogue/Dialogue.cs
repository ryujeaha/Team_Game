using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//Ŀ���� Ŭ������ �ν����� â���� ������ �Ұ���.�װ� ������ �� �ְ��ϱ� ���� ����ȭ ��ɾ�.
public class Dialogue
{
    [Tooltip("���ġ�� ĳ������ �̸�.")]//�ν����� â�� ������ ����.
    public string Name;//���ġ�� ĳ���� �̸�.

    [Tooltip("��� ����")]//�ν����� â�� ������ ����.
    public string[] ConTexts;//��� ����.(������ ���� �� �����Ƿ� �迭)
}

[System.Serializable]
public class DialogueEvent//Dialogue�� ������ ������ ����ϱ� ���ؼ� 
{
    public string E_Name;//�̺�Ʈ�� �̸�
    public Vector2 line;//x~y������ ��縦 �����س��� ���� ����
    public Dialogue[] dialogue;//Dialogue Ŭ������ ������ �־�� ���� ĳ������ ��縦 ����� �� �����Ƿ�, �ٸ� Ŭ�������� �迭�� ����� ��.
}