using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Timer;


public class Timer : MonoBehaviour
{
    
    [SerializeField]
    private float minRandomTime = 15f; 
    [SerializeField]
    private float maxRandomTime = 8f;
    public delegate void BorrowedTime();
    public event BorrowedTime OnTimeUp;

    private float counter;
    private Slider time;
    private TextMeshProUGUI info;
    private bool isTimeUp = false;

    private void Awake()
    {
        info = GameObject.FindWithTag("info").GetComponent<TextMeshProUGUI>();
        time = GameObject.Find("Timer").GetComponent<Slider>();
    }
    private void Start()
    {
        float randomTime = Random.Range(minRandomTime, maxRandomTime);
        time.maxValue = randomTime;
        time.value = randomTime;
        counter = randomTime;
        isTimeUp = false;
        
    }
    private void Update()
    {
        if(time.value> time.minValue)
        {
            counter -= Time.deltaTime;
            time.value = counter;
            info.text = ((int)time.value).ToString();
        }
        else
        {
            if(!isTimeUp)
            {
                info.text = "süre doldu!";
                isTimeUp = true;
                OnTimeUp?.Invoke();
            }
        }
    }
}
