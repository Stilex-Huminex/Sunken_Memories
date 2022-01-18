using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    private bool item1, item2, item3;
    private bool drop1, drop2, drop3;

    public void PickUp(int id)
    {
        switch (id)
        {
            case 1:
                item1 = true;
                break;
            case 2:
                item2 = true;
                break;
            case 3:
                item3 = true;
                break;
        }
    }

    public void Drop(int id)
    {
        switch (id)
        {
            case 1:
                drop1 = true;
                break;
            case 2:
                drop2 = true;
                break;
            case 3:
                drop3 = true;
                break;
        }
    }

    public bool Recuperer1()
    {
        return item1;
    }
    public bool Recuperer2()
    {
        return item2;
    }
    public bool Recuperer3()
    {
        return item3;
    }

    public bool Ouvert()
    {
        return drop1 & drop2 & drop3;
    }
}
