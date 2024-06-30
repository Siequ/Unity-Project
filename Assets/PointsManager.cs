using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : Enemy
{
    public TextMeshProUGUI ptsManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ptsManager.text = playerPoints.ToString();
    }
}
