using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Parser : MonoBehaviour
{
   public Dialogue[] Parse(string CSV_FileName)//�غ��� �������� �����͸� ��������(�Ľ�) �Լ�.
   {
        List<Dialogue> dialoguesList = new List<Dialogue>();//�ڷ����� Ŀ���� Ŭ���� Dialogue�� ��� ����Ʈ ����(�Ľ̵� �����͸� �ӽ� �����ϴ� �뵵)
        TextAsset csvData = Resources.Load<TextAsset>(CSV_FileName);/*TextAsset�� csv������ �ޱ����� ������ ����. Resources�� ������ ������ ���ϸ�.
        �������� CSV_FileName�� ���� ������ TextAsset���� ��ȯ�ؼ� ������.*/
        string[] data = csvData.text.Split(new char[]{'\n'});/*csvData�� ����� ���Ͽ��� text�� Split�Լ��� \n�� �������� �߶� data �迭�� �����Ѵ�.
        ([0]�������� ������ ���� ������ ���� ����)*/
        for(int i = 1; i < data.Length;)//data �迭 ��ȸ.
        {
            string[] row = data[i].Split(new char[]{','});//CSV������ ,������ �����Ǳ� ������ ���� data�� �ִ� ������ ��ü�� ,�� �ɰ�.(id, ĳ���� �̸�, ���)
            
            Dialogue dialogue = new Dialogue();//��� ����Ʈ ����.
            
            dialogue.Name = row[1];//�̸� ����ֱ�.

            List<string> Context_List = new List<string>();//�迭�� ũ�⸦ �������� �ʰ� ��������� ������ ���� ������ ����Ʈ�� ���.
          

            do{
                Context_List.Add(row[2]);//��� ���� �ֱ�.
                if(++i < data.Length){
                   row = data[i].Split(new char[]{','});//�� �����ִٸ� �ɰ��ֱ�.
                }else{
                    break;
                }
            }while(row[0].ToString() == "");//id�� �����̶��, ���� ��ü�� ���ϰ� �ִٴ� ���̹Ƿ�,���� ����Ʈ�� ��縦 �������.

            dialogue.ConTexts = Context_List.ToArray();//������ ������ �迭�� �ٲ㼭 ����ֱ�.

            dialoguesList.Add(dialogue);//���� ���� ���� Ŭ������ ����Ʈ�� �ֱ�.
        }
        return dialoguesList.ToArray();//Dialogue[] �������� ������ �ؾ��ϱ� ������ LIST������ �迭�� ����ȯ �ؼ� ����.
   }
}
