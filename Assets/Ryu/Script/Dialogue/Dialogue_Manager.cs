using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Manager : MonoBehaviour
{
    [SerializeField] GameObject Dialogue_Bar;//대화창_이미지
    [SerializeField] GameObject Dialogue_Name_Bar;//대화창_이름칸_이미지.

    [SerializeField] Text txt_Dialogue;//대화가 들어갈 텍스트타입 변수.
    [SerializeField] Text txt_Name;//이름이 들어갈 텍스트 타입 변수.

    Dialogue[] dialogues;//추출한 정보를 담을 공간.
    
    Player player;

    bool is_dialogue = false;//대화 중일 경우 true;
    bool is_Next = false;//특정 키 입력 대기.

    [Header("텍스트 출력 딜레이")]//타닥타닥 나오는 효과를 위함.
    [SerializeField] float text_Delay;

    int line_Cnt = 0;//대화 카운트.(한 객체의 대화가 끝난다면 증가시켜서 다음 대화가 나오도록 하는 역할.)
    int Context_cnt = 0;//대사 카운트(대화가 여러줄일 수 있기 때문에 이 변수로 체크.)
    

    private void Start() {
        player = FindObjectOfType<Player>();
    }


    private void Update() {
        talk_Setting();
    }

    void talk_Setting()
    {
        if(is_dialogue)//대화 중이라면
        {
            if(is_Next)//현재 대화가 모두 출력됬다면.
            {
                if(Input.GetKeyDown(KeyCode.Space))//스페이스가 눌렸다면
                {
                    is_Next = false;//다시 새로운 대화가 시작되므로 바꿔주기.
                    txt_Dialogue.text = "";//대화창 초기화
                    if(++Context_cnt < dialogues[line_Cnt].ConTexts.Length)//현재 대상의 다음 대사가 있다면.(Context_cnt를 증가했을 때 길이보다 클 경우)
                    {
                        StartCoroutine(TypeWriter());//다시 코루틴 호출로 다음 대사 출력.
                    }
                    else//현재 대상의 다음 대사가 없을 경우.
                    {
                        Context_cnt = 0;//다음 대상에 대화로 넘어가므로 초기화
                        if(++line_Cnt < dialogues.Length)//다음 대화할 대상이 남아있을 경우(총 대화가 끝나지 않았을 경우)
                        {
                            StartCoroutine(TypeWriter());//다시 코루틴 호출로 다음 대사 출력.
                        }
                        else//모든 대화가 끝났다면.
                        {
                            EndDialogue();
                        }
                    }
                }
            }
        }
    }

    public void Show_Dialogue(Dialogue[] p_dialogues)//대화 시작 겸 환경 세팅 함수.
    {
        is_dialogue = true;//대화 시작 알림.
        txt_Dialogue.text = "";//텍스트 초기화
        txt_Name.text = "";//텍스트 초기화
        dialogues = p_dialogues;//받은 정보 저장.
        StartCoroutine(TypeWriter());//대화 코루틴 실행.
    }

    void EndDialogue()//대화 끝 함수
    {
        is_dialogue = false;//대화 끝 알림.
        //초기화 작업
        Context_cnt = 0;
        line_Cnt -= 0;
        dialogues = null;
        is_Next = false;
        Setting_UI(false);//대화창 지우기
        player.is_Action = false;//이동중을 나타냄. 
    }

    IEnumerator TypeWriter()
    {
        Setting_UI(true);//환경 세팅.

        string t_replace_text = dialogues[line_Cnt].ConTexts[Context_cnt];//스트링 임시변수에 한줄씩 담기 + '를 ,로 변환.
        t_replace_text = t_replace_text.Replace("'",",");//Replace는 특정 문자열을 대체 시키는 함수로(지정문자열,바꿀문자열)형식이다.

        txt_Name.text = dialogues[line_Cnt].Name;//이름 텍스트에 대입.
        for(int i = 0; i < t_replace_text.Length; i++)//현재 줄에 대사의 글자 길이만큼 반복.
        {
            txt_Dialogue.text += t_replace_text[i];//문자열은 +를하면 바로 옆에 붙는 특징을 이용하여 한글자씩 붙여서 대입해줌.
            yield return new WaitForSeconds(text_Delay);//한번 반복될 때 마다 정한 시간만큼 딜레이를 주어 리턴하는 함수.(글자가 적히는 듯한 효과)     
        }

        is_Next = true;//현재 대화 끝
        yield return null;
    }
    void Setting_UI(bool P_Flag)
    {
        //받은 bool 매개변수 P_Flag 값으로 켜졌다/꺼졌다 하기
        Dialogue_Bar.SetActive(P_Flag);
        Dialogue_Name_Bar.SetActive(P_Flag);
    }
}
