using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Manager : MonoBehaviour
{
    [SerializeField] GameObject Dialogue_Bar;
    //[SerializeField] GameObject Dialogue_Name_Bar;

    [SerializeField] Text txt_Dialogue;
    //[SerializeField] Text txt_Name;

    Dialogue[] dialogues;

    bool is_dialogue = false;
    
    public void Show_Dialogue(Dialogue[] p_dialogues)
    {
        txt_Dialogue.text = "";
        //txt_Name.text = "";


        dialogues = p_dialogues;
        Setting_UI(true);
    }

    void Setting_UI(bool P_Flag)
    {
        Dialogue_Bar.SetActive(P_Flag);
        //Dialogue_Name_Bar.SetActive(P_Flag);
    }
}
