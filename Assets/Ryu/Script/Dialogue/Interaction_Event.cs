using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_Event : MonoBehaviour
{
    [SerializeField]DialogueEvent dialogue;//직렬화 한 커스텀 클래스를 사용하기 위한 선언.

    public Dialogue[] GetDialogues()//데이터 베이스의 있는 정보들을 꺼내오는 함수.
    {
        dialogue.dialogues = Database_Manager.instance.GetDialogues((int)dialogue.line.x,(int)dialogue.line.y);/*데이터베이스 매니저에서 만든 함수를 호출하여 가져오는데/
        vector2는 float이므로 int로 형변환.*/
        return dialogue.dialogues;
    }
}
