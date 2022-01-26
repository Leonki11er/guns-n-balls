using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayLoop : MonoBehaviour
{
    public delegate void Do_stuff_in_Array(int Column, int Line);
    public static void Array_look_backward(Do_stuff_in_Array Do_stuff, int Column, int Line)
    {
        for (int c = Column - 1; c >= 0; c--)
        {
            for (int l = Line - 1; l >= 0; l--)
            {
                Do_stuff(c, l);
            }
        }
    }

    public static void Array_look_forward(Do_stuff_in_Array Do_stuff, int Column, int Line)
    {
        for (int c = 0; c < Column; c++)
        {
            for (int l = 0; l < Line; l++)
            {
                Do_stuff(c, l);
            }
        }
    }

}
