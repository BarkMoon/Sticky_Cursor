using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditions : MonoBehaviour
{
    public int Fast = 400;
    public int Slow = 300;
    public int Big = 100;
    public int Small = 75;
    public int ClearNumber = 20;
    public int PracticeNumber = 3;
    public static int FastSpeed;
    public static int SlowSpeed;
    public static int BigSize;
    public static int SmallSize;
    public static int ClearNum;
    public static int PracticeNum;
    private void Start() {
        FastSpeed = Fast;
        SlowSpeed = Slow;
        BigSize = Big;
        SmallSize = Small;
        ClearNum = ClearNumber;
        PracticeNum = PracticeNumber;
    }
}
