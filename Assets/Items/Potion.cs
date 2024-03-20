using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Countable, Usable
{
    public bool Use()
    {
        //포션의 개수가 충분할 경우 펴선의 개수를 1 감소 시킨다.
        return true;
    }
}
