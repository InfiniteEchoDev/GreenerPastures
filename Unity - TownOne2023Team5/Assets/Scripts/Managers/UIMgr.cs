using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class UIMgr : Singleton<UIMgr> {

	override protected void Awake() {
		base.Awake();
	}

	[Header("Obj Refs")]
	public TMPro.TMP_Text SheepAmtText;
	public TMPro.TMP_Text WolfAmtText;


}
