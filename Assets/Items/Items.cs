using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//�������� Ŭ����
//������ �����ʹ� ������ ���� ��ũ���ͺ� ������Ʈ
public abstract class Items
{
    public ItemData Data { get; private set; }
    public Items(ItemData data) 
    {
        Data = data;
    }



}

