
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    //분기가 넘어갈때 정해줌.
    public int sceneIndex;//이동할 씬의 인덱스 번호
    public string sceneName;//이동할 씬의 이름.

    public float duration; //암전되는 시간길이

    public Image coverImage; //암전효과를 낼 이미지

    public bool isSceneStart = false;
    IEnumerator SceneBlackOutProcess()
    {
        coverImage.gameObject.SetActive(true);

        float t = 0.0f;
        float alphaCount = 0.0f;
        while (t <= duration)
        {
            t += Time.deltaTime;
            if (isSceneStart == false)
            {
                //여기는 알파값이 0에서 시작.
                alphaCount = t / duration;//어두워지기
            }
            else
            {
                //여기는 알파 값을 1부터 시작해서 계산된 값은 뺌
                alphaCount = 1 - (t / duration);//투명해지기
            }

            coverImage.color = new Color(0, 0, 0, alphaCount);

            yield return new WaitForEndOfFrame();//하나의 프레임이 완전히 종료될 때 호출이 됩니다
        }

        yield return new WaitForEndOfFrame();

        //신로드
        if (isSceneStart == false)
        {
            //신로드
            SceneManager.LoadScene(sceneIndex);
            SceneManager.LoadScene(sceneName);
        }
        /*else 암전효과를 다른씬에서 켜지는 듯한 연출을 하기 위해서 필요한 부분
        {
            //서서히 밝아지고 투명해지면 오브젝트를 숨김
            coverImage.gameObject.SetActive(false);
        }

        isSceneStart = !isSceneStart;//false라면 true로, true라면 false로 전환*/
    }
    public void OnCLick_StartBtn()//게임 시작을 눌렀을 때
    {
        StartCoroutine(SceneBlackOutProcess());
        isSceneStart = false;
    }
      public void Onclick_Exit_Button()//게임 종료 버튼을 눌렀을 때.
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
