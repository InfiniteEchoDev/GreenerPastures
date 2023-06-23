using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePanel : MonoBehaviour
{
    [SerializeField]
    private float currentAngle = 0.0f;
    [SerializeField]
    private const float dayStartAngle = 180.0f;  
    [SerializeField]
    private const float nightStartAngle = 360.0f;
    [SerializeField]
    private Transform TimeUnderlay;
    [SerializeField]
    private TMPro.TMP_Text TimeAmtText;

    void Start ()
    {
        if (TimeMgr.Instance.isDayTime)
            currentAngle = dayStartAngle;
        else 
            currentAngle = nightStartAngle;
    }
    // Update is called once per frame
    void Update()
    {
        var currentTime = TimeMgr.Instance.currentTime;
        TimeAmtText.text = currentTime.ToString();
        var oldAngle = currentAngle;
        if (TimeMgr.Instance.isDayTime)
            currentAngle = dayStartAngle + 180.0f * currentTime / TimeMgr.Instance.dayCycleDuration;
        else
            currentAngle = nightStartAngle + 180.0f * currentTime / TimeMgr.Instance.nightCycleDuration;
        
        if (currentAngle > oldAngle) {
            Debug.Log("Rotated to currentAngle.");
            TimeUnderlay.Rotate(new Vector3(0.0f, 0.0f, currentAngle - oldAngle));
        } else {
            Debug.Log("Rotated to oldAngle.");
            TimeUnderlay.Rotate(new Vector3(0.0f, 0.0f, oldAngle - currentAngle));
        }
    }
}
