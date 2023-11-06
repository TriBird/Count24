using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameMaster : MonoBehaviour{

	public Transform counter_trans;
	
	private int counter = 0;
	private int stage_index = 0;

	void Start(){
		
	}

	public void count_increment(){
		counter++;
		if(counter == 24){
			stage_index++;
			counter = 0;
		}

		counter_trans.GetComponent<Text>().text = counter.ToString();
	}

	public void count_set(int number){
		counter = number;
		counter_trans.GetComponent<Text>().text = counter.ToString();
	}

	public int get_stage_index(){
		return stage_index;
	}
}
