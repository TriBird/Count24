using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;
using Unity.Mathematics;

public class BitCtrl : MonoBehaviour, IDragHandler{

	public GameMaster master;
	public int bit_number = 0;

	public void OnDrag(PointerEventData eventData){
		if(master.get_stage_index() == 0){
			float axis_y = eventData.position.y-750f;
			transform.localPosition = new Vector3(transform.localPosition.x, axis_y);
			master.count_set(Mathf.FloorToInt(axis_y / 100f)+28);
		}
	}

	void Start(){
			
	}
}
