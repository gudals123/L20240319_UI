using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "item", menuName = "SO/ItemList")]
public class ItemList: ScriptableObject
{
    public List<Item> iList;



    /// <summary>
    /// 아이템 생성 함수
    /// </summary>
    /// <returns></returns>
    public static ItemList Create()
    {
        var asset = CreateInstance<ItemList>();
        AssetDatabase.CreateAsset(asset, "Assets/Resources/Item/itemExaple01.asset");
        AssetDatabase.SaveAssets();
        return asset;
    }


    public static ItemList Load()
    {
        var itemList = AssetDatabase.LoadAssetAtPath("Assets/Resources/Item/itemExaple01.asset", typeof(ItemList)) as ItemList;

        return itemList;
    }

}

