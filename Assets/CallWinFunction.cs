using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallWinFunction : MonoBehaviour
{
    public RescuePet rp;
    public void CallWinFunctionHere()
    {
        print("Calling win function from animation");
        rp.WinGame();
    }
}
