using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class StartBtnCtrl : MonoBehaviour, IPointerClickHandler{

	public GameMaster master;

	public void OnPointerClick(PointerEventData eventData){
		if(master.get_stage_index() == 0){
			master.count_increment();
		}

		
	}
}
