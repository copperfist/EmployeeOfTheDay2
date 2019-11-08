using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectData : MonoBehaviour
{
    public Dictionary<string, int> intData = new Dictionary<string, int>();
    public Dictionary<string, bool> boolData = new Dictionary<string, bool>();
    public Dictionary<string, string> stringData = new Dictionary<string, string>();
    public Dictionary<string, float> floatData = new Dictionary<string, float>();
    public Dictionary<string, GameObject> gameObjectData = new Dictionary<string, GameObject>();
}