using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database_Manager : MonoBehaviour
{
    public static Database_Manager instance;//어디서든 찾기 편하도록 본인을 객체화 시킴.

    [SerializeField] string CSV_FileName;

    Dictionary<int, Dialogue> dialogue_DIC = new Dictionary<int, Dialogue>();//사전이라는 뜻과 같이 int 타입으로 Dialogue를 찾을 수 있게하는 친구.

    public static bool is_Finish = false;//전부 저장이 되었는지 여부 변수
    
    void Awake() //Start보다 더욱 빨리 실행되는 함수.
    {
        if(instance == null){
            instance = this;//인스턴스가 비어있다면 본인을 저장시켜라.
            Dialogue_Parser the_Parser = GetComponent<Dialogue_Parser>();//the_Parser라는 공간에 코드를 가져오는 함수GetComponent로 파서를 가져와 준다.
            Dialogue[] dialogues = the_Parser.Parse(CSV_FileName);//파스를 호출하여 데이터 가져오기를 실행한다. 모든 데이터는 dialogues에게 담겨있다.
            for(int i = 0; i < dialogues.Length; i++)//dialogues순회
            {
                dialogue_DIC.Add(i+1,dialogues[i]);//딕셔너리에 첫번쨰부터 대사와 등등을 저장.
            }
            is_Finish = true;//파싱이 끝남.
        }
    }

    public Dialogue[] GetDialogues(int Strat_Num, int End_Num)//딕셔너리에서 저장된 정보들을 가져오는 함수.
    {
        List<Dialogue> dialogue_List = new List<Dialogue>();//저장할 공간.

        for(int i = 0; i <= End_Num - Strat_Num;i++)
        {
            dialogue_List.Add(dialogue_DIC[Strat_Num+i]);//딕셔너리에서 1부터 저장시켰으므로 i를 더해줌.
        }
        return dialogue_List.ToArray();
    }
}
