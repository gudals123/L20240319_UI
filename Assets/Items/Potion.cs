using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Countable, Usable
{
    public bool Use()
    {
        //������ ������ ����� ��� �켱�� ������ 1 ���� ��Ų��.
        return true;
    }
}
