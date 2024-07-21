using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Manager : MonoBehaviour
{
    [SerializeField] GameObject Dialogue_Bar;//��ȭâ_�̹���
    [SerializeField] GameObject Dialogue_Name_Bar;//��ȭâ_�̸�ĭ_�̹���.

    [SerializeField] Text txt_Dialogue;//��ȭ�� �� �ؽ�ƮŸ�� ����.
    [SerializeField] Text txt_Name;//�̸��� �� �ؽ�Ʈ Ÿ�� ����.

    Dialogue[] dialogues;//������ ������ ���� ����.
    
    Player player;

    bool is_dialogue = false;//��ȭ ���� ��� true;
    bool is_Next = false;//Ư�� Ű �Է� ���.

    [Header("�ؽ�Ʈ ��� ������")]//Ÿ��Ÿ�� ������ ȿ���� ����.
    [SerializeField] float text_Delay;

    int line_Cnt = 0;//��ȭ ī��Ʈ.(�� ��ü�� ��ȭ�� �����ٸ� �������Ѽ� ���� ��ȭ�� �������� �ϴ� ����.)
    int Context_cnt = 0;//��� ī��Ʈ(��ȭ�� �������� �� �ֱ� ������ �� ������ üũ.)
    

    private void Start() {
        player = FindObjectOfType<Player>();
    }


    private void Update() {
        talk_Setting();
    }

    void talk_Setting()
    {
        if(is_dialogue)//��ȭ ���̶��
        {
            if(is_Next)//���� ��ȭ�� ��� ���ٸ�.
            {
                if(Input.GetKeyDown(KeyCode.Space))//�����̽��� ���ȴٸ�
                {
                    is_Next = false;//�ٽ� ���ο� ��ȭ�� ���۵ǹǷ� �ٲ��ֱ�.
                    txt_Dialogue.text = "";//��ȭâ �ʱ�ȭ
                    if(++Context_cnt < dialogues[line_Cnt].ConTexts.Length)//���� ����� ���� ��簡 �ִٸ�.(Context_cnt�� �������� �� ���̺��� Ŭ ���)
                    {
                        StartCoroutine(TypeWriter());//�ٽ� �ڷ�ƾ ȣ��� ���� ��� ���.
                    }
                    else//���� ����� ���� ��簡 ���� ���.
                    {
                        Context_cnt = 0;//���� ��� ��ȭ�� �Ѿ�Ƿ� �ʱ�ȭ
                        if(++line_Cnt < dialogues.Length)//���� ��ȭ�� ����� �������� ���(�� ��ȭ�� ������ �ʾ��� ���)
                        {
                            StartCoroutine(TypeWriter());//�ٽ� �ڷ�ƾ ȣ��� ���� ��� ���.
                        }
                        else//��� ��ȭ�� �����ٸ�.
                        {
                            EndDialogue();
                        }
                    }
                }
            }
        }
    }

    public void Show_Dialogue(Dialogue[] p_dialogues)//��ȭ ���� �� ȯ�� ���� �Լ�.
    {
        is_dialogue = true;//��ȭ ���� �˸�.
        txt_Dialogue.text = "";//�ؽ�Ʈ �ʱ�ȭ
        txt_Name.text = "";//�ؽ�Ʈ �ʱ�ȭ
        dialogues = p_dialogues;//���� ���� ����.
        StartCoroutine(TypeWriter());//��ȭ �ڷ�ƾ ����.
    }

    void EndDialogue()//��ȭ �� �Լ�
    {
        is_dialogue = false;//��ȭ �� �˸�.
        //�ʱ�ȭ �۾�
        Context_cnt = 0;
        line_Cnt -= 0;
        dialogues = null;
        is_Next = false;
        Setting_UI(false);//��ȭâ �����
        player.is_Action = false;//�̵����� ��Ÿ��. 
    }

    IEnumerator TypeWriter()
    {
        Setting_UI(true);//ȯ�� ����.

        string t_replace_text = dialogues[line_Cnt].ConTexts[Context_cnt];//��Ʈ�� �ӽú����� ���پ� ��� + '�� ,�� ��ȯ.
        t_replace_text = t_replace_text.Replace("'",",");//Replace�� Ư�� ���ڿ��� ��ü ��Ű�� �Լ���(�������ڿ�,�ٲܹ��ڿ�)�����̴�.

        txt_Name.text = dialogues[line_Cnt].Name;//�̸� �ؽ�Ʈ�� ����.
        for(int i = 0; i < t_replace_text.Length; i++)//���� �ٿ� ����� ���� ���̸�ŭ �ݺ�.
        {
            txt_Dialogue.text += t_replace_text[i];//���ڿ��� +���ϸ� �ٷ� ���� �ٴ� Ư¡�� �̿��Ͽ� �ѱ��ھ� �ٿ��� ��������.
            yield return new WaitForSeconds(text_Delay);//�ѹ� �ݺ��� �� ���� ���� �ð���ŭ �����̸� �־� �����ϴ� �Լ�.(���ڰ� ������ ���� ȿ��)     
        }

        is_Next = true;//���� ��ȭ ��
        yield return null;
    }
    void Setting_UI(bool P_Flag)
    {
        //���� bool �Ű����� P_Flag ������ ������/������ �ϱ�
        Dialogue_Bar.SetActive(P_Flag);
        Dialogue_Name_Bar.SetActive(P_Flag);
    }
}
