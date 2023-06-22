using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMgr : Singleton<TimeMgr>
{
    [SerializeField]
    private float currentTime;
    
    [SerializeField]
    private float nightCycleDuration;
    [SerializeField]
    private float dayCycleDuration;
    [SerializeField]
    private bool isDayTime = true;
    override protected void Awake() {
		base.Awake();

	}

}
