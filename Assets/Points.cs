using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public TextMeshProUGUI ptsManager;
    [SerializeField] UnityEvent onTriggerEnter;
    [SerializeField] UnityEvent onTriggerExit;
    public int scoreNumber;
    void Start()
    {
        scoreNumber = 0;
        ptsManager.text = "Score : " + scoreNumber;

    }

    // Update is called once per frame
    void Update()
    {

    }
        private void OnTriggerEnter2D(Collider2D collision)
    {

            scoreNumber++;

        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            onTriggerExit.Invoke();
        }
}

