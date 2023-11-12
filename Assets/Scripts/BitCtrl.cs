using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;
using Unity.Mathematics;

public class BitCtrl : MonoBehaviour, IDragHandler, IPointerClickHandler{

	public GameMaster master;
	public int bit_number = 0;

	private static List<bool> binaries = new List<bool>(){false, false, false, false, false, false, false, false};

	public void OnDrag(PointerEventData eventData){
		if(!master.get_clear_flag(1)){
			float axis_y = eventData.position.y-700f;
			transform.localPosition = new Vector3(transform.localPosition.x, axis_y);
			master.count_set(Mathf.FloorToInt(axis_y / 100f)+22, 1);
		}
	}

	public void OnPointerClick(PointerEventData eventData){
		if(!master.get_clear_flag(2)){
			if(binaries[bit_number]){
				transform.DOLocalMoveY(transform.localPosition.y-50f, 0.5f);
			}else{
				transform.DOLocalMoveY(transform.localPosition.y+50f, 0.5f);
			}
			binaries[bit_number] = !binaries[bit_number];

			int result = 0;
			for(int i=0; i<8; i++){
				if(binaries[7-i]){
					result += (int)Mathf.Pow(2, 7-i);
				}
			}
			master.count_set(result, 2);
		}
	}

	void Start(){
			
	}

}
