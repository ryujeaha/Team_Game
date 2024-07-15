
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    //�бⰡ �Ѿ�� ������.
    public int sceneIndex;//�̵��� ���� �ε��� ��ȣ
    public string sceneName;//�̵��� ���� �̸�.

    public float duration; //�����Ǵ� �ð�����

    public Image coverImage; //����ȿ���� �� �̹���

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
                //����� ���İ��� 0���� ����.
                alphaCount = t / duration;//��ο�����
            }
            else
            {
                //����� ���� ���� 1���� �����ؼ� ���� ���� ��
                alphaCount = 1 - (t / duration);//����������
            }

            coverImage.color = new Color(0, 0, 0, alphaCount);

            yield return new WaitForEndOfFrame();//�ϳ��� �������� ������ ����� �� ȣ���� �˴ϴ�
        }

        yield return new WaitForEndOfFrame();

        //�ŷε�
        if (isSceneStart == false)
        {
            //�ŷε�
            SceneManager.LoadScene(sceneIndex);
            SceneManager.LoadScene(sceneName);
        }
        /*else ����ȿ���� �ٸ������� ������ ���� ������ �ϱ� ���ؼ� �ʿ��� �κ�
        {
            //������ ������� ���������� ������Ʈ�� ����
            coverImage.gameObject.SetActive(false);
        }

        isSceneStart = !isSceneStart;//false��� true��, true��� false�� ��ȯ*/
    }
    public void OnCLick_StartBtn()//���� ������ ������ ��
    {
        StartCoroutine(SceneBlackOutProcess());
        isSceneStart = false;
    }
      public void Onclick_Exit_Button()//���� ���� ��ư�� ������ ��.
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
