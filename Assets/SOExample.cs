using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SOExample : MonoBehaviour
{
    public Item item_object;
    public ItemList item_list;

    void Start()
    {
        //Debug.Log(item_object.Type);
        //Debug.Log(item_object.Description);


        item_list = ItemList.Create();
        var item_ob1 = Item.Create();

        item_list.iList.Add(item_ob1);

        for (int i = 0; i < item_list.iList.Count; i++)
        {
            Debug.Log(item_list.iList[i].name);
        }


        var item_list2 = ItemList.Load();
        Debug.Log(AssetDatabase.GetAssetPath(item_list2));
        //AssetDatabase는 새로운 에셋을 지정된 경로에 생성할 때 사용합니다.
        //경로에는 확장자를 명시해줘야 합니다.
        //에셋이 이미 path 경로에 존재하는 경우 덮어씌워집니다.
        //모든 경로는 프로젝트의 폴더를 기준으로 설정합니다.

        //사용 목적 : 에셋의 소스 파일에서 게임 도는 실기간 앱에서 사용할 수 있는 형태로 데이터를 전환해야 하는데
        //유니티는 전환된 파일, 전환된 파일과 연결된 데이터를 에셋 데이터베이스에 저장합니다.


    }

    void Update()
    {

    }


}
