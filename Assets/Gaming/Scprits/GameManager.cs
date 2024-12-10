using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class GameManager : ScriptableObject
{
    public bool isPressing;
    public float x;
    public float z;
    public enum Level { one, two, three, four, five, six, seven, eight, nine, ten }
    public Level level;
    public float speed = 50;
    public bool lost;
}
