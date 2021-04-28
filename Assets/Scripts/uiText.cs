using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class uiText : MonoBehaviour
{
    private float time;
    public TextMeshProUGUI timeText;
    // Start is called before the first frame update
    void Start()
    {
        time = 11;
        timeText.text = "Time remaining: " + (int)time; 
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timeText.text = "Time remaining: " + (int)time;
    }
}
