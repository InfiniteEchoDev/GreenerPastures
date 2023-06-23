using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMgr : Singleton<TimeMgr>
{
    [field: SerializeField]
    public float currentTime {get; private set;}
    
    [field: SerializeField]
    public float nightCycleDuration {get; private set;}

    [field: SerializeField]
    public float dayCycleDuration {get; private set;}

    [field: SerializeField]
    public bool isDayTime {get; private set;} = true;

    override protected void Awake() {
	  	base.Awake();
  	}
    
    void Update()
    {
      currentTime += Time.deltaTime;
      var cycleDuration = isDayTime ? dayCycleDuration : nightCycleDuration;
      
      if (currentTime > cycleDuration) {
          // TODO call some callback function
          isDayTime = !isDayTime;
          currentTime %= cycleDuration;
      }
    }

}
