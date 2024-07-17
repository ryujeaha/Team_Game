using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Parser : MonoBehaviour
{
   public Dialogue[] Parse(string CSV_FileName)//준비한 엑셀에서 데이터를 가져오는(파싱) 함수.
   {
        List<Dialogue> dialoguesList = new List<Dialogue>();//자료형이 커스텀 클래스 Dialogue인 대사 리스트 생성(파싱된 데이터를 임시 저장하는 용도)
        TextAsset csvData = Resources.Load<TextAsset>(CSV_FileName);/*TextAsset은 csv파일을 받기위한 데이터 구조. Resources는 동명의 폴더를 말하며.
        폴더에서 CSV_FileName을 가진 파일을 TextAsset으로 변환해서 가져옴.*/
        string[] data = csvData.text.Split(new char[]{'\n'});/*csvData에 저장된 파일에서 text를 Split함수로 \n을 기준으로 잘라서 data 배열에 저장한다.
        ([0]번쨰에는 엑셀에 제일 윗줄이 들어가는 형식)*/
        for(int i = 1; i < data.Length;)//data 배열 순회.
        {
            string[] row = data[i].Split(new char[]{','});//CSV파일은 ,단위로 구별되기 때문에 현재 data에 있는 가로줄 전체를 ,로 쪼갬.(id, 캐릭터 이름, 대사)
            
            Dialogue dialogue = new Dialogue();//대사 리스트 생성.
            
            dialogue.Name = row[1];//이름 집어넣기.

            List<string> Context_List = new List<string>();//배열은 크기를 지정하지 않고 집어넣으면 오류가 나기 때문에 리스트를 사용.
          

            do{
                Context_List.Add(row[2]);//대사 집어 넣기.
                if(++i < data.Length){
                   row = data[i].Split(new char[]{','});//더 남아있다면 쪼개주기.
                }else{
                    break;
                }
            }while(row[0].ToString() == "");//id가 여백이라면, 같은 객체가 말하고 있다는 뜻이므로,현재 리스트에 대사를 집어넣음.

            dialogue.ConTexts = Context_List.ToArray();//가져온 대사들을 배열로 바꿔서 집어넣기.

            dialoguesList.Add(dialogue);//전부 집어 넣은 클래스를 리스트에 넣기.
        }
        return dialoguesList.ToArray();//Dialogue[] 형식으로 리턴을 해야하기 떄문에 LIST형식을 배열로 형변환 해서 리턴.
   }
}
