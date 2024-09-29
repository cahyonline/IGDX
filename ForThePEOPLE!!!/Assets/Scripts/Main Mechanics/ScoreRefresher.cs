using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRefresher : MonoBehaviour
{
    // Start is called before the first frame update
    public PickItUp itemCoder;
    public PickItUpKeys keyCoder;
    public void RefresherS()
    {
        itemCoder.Refresher();
        keyCoder.Refresher();
        Debug.Log("Refresh Item Value");
    }
}

