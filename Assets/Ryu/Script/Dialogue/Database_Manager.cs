using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database_Manager : MonoBehaviour
{
    public static Database_Manager instance;//��𼭵� ã�� ���ϵ��� ������ ��üȭ ��Ŵ.

    [SerializeField] string CSV_FileName;

    Dictionary<int, Dialogue> dialogue_DIC = new Dictionary<int, Dialogue>();//�����̶�� ��� ���� int Ÿ������ Dialogue�� ã�� �� �ְ��ϴ� ģ��.

    public static bool is_Finish = false;//���� ������ �Ǿ����� ���� ����
    
    void Awake() //Start���� ���� ���� ����Ǵ� �Լ�.
    {
        if(instance == null){
            instance = this;//�ν��Ͻ��� ����ִٸ� ������ ������Ѷ�.
            Dialogue_Parser the_Parser = GetComponent<Dialogue_Parser>();//the_Parser��� ������ �ڵ带 �������� �Լ�GetComponent�� �ļ��� ������ �ش�.
            Dialogue[] dialogues = the_Parser.Parse(CSV_FileName);//�Ľ��� ȣ���Ͽ� ������ �������⸦ �����Ѵ�. ��� �����ʹ� dialogues���� ����ִ�.
            for(int i = 0; i < dialogues.Length; i++)//dialogues��ȸ
            {
                dialogue_DIC.Add(i+1,dialogues[i]);//��ųʸ��� ù�������� ���� ����� ����.
            }
            is_Finish = true;//�Ľ��� ����.
        }
    }

    public Dialogue[] GetDialogues(int Strat_Num, int End_Num)//��ųʸ����� ����� �������� �������� �Լ�.
    {
        List<Dialogue> dialogue_List = new List<Dialogue>();//������ ����.

        for(int i = 0; i <= End_Num - Strat_Num;i++)
        {
            dialogue_List.Add(dialogue_DIC[Strat_Num+i]);//��ųʸ����� 1���� ����������Ƿ� i�� ������.
        }
        return dialogue_List.ToArray();
    }
}
