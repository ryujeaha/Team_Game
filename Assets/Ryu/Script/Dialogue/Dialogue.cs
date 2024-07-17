using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//커스텀 클래스는 인스펙터 창에서 수정이 불가함.그걸 수정할 수 있게하기 위한 직렬화 명령어.
public class Dialogue
{
    [Tooltip("대사치는 캐릭터의 이름.")]//인스펙터 창에 툴팁을 띄우기.
    public string Name;//대사치는 캐릭터 이름.

    [Tooltip("대사 내용")]//인스펙터 창에 툴팁을 띄우기.
    public string[] ConTexts;//대사 내용.(여러번 말할 수 있으므로 배열)
}

[System.Serializable]
public class DialogueEvent//Dialogue의 내용을 여러개 사용하기 위해서 
{
    public string E_Name;//이벤트의 이름
    public Vector2 line;//x~y까지의 대사를 추출해내기 위한 변수
    public Dialogue[] dialogue;//Dialogue 클래스가 여러개 있어야 여러 캐릭터의 대사를 사용할 수 있으므로, 다른 클래스에서 배열로 만들어 줌.
}