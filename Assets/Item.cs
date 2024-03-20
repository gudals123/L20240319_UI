using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum ItemTYPE
{
    WEAPON, ARMOR, POTION
}

[CreateAssetMenu(fileName = "item", menuName = "SO/Item")]
public class Item : ScriptableObject
{
    [SerializeField] string description;
    [SerializeField] ItemTYPE type;


    public ItemTYPE Type { get => type; set => type = value; }
    public string Description { get => description; set => description = value; }

    /// <summary>
    /// 아이템 생성 함수
    /// </summary>
    /// <returns></returns>
    public static Item Create()
    {
        var asset = CreateInstance<Item>();
        AssetDatabase.CreateAsset(asset, "Assets/Resources/Item/item1.asset");
        AssetDatabase.SaveAssets();
        return asset;
    }


    public static Item Load()
    {
        var itemList = AssetDatabase.LoadAssetAtPath("Assets/Resources/Item/item1.asset", typeof(Item)) as Item;

        return itemList;
    }


}
