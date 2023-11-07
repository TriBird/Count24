using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameMaster : MonoBehaviour{

	public Transform counter_trans, bits_trans;
	
	private int counter = 0;
	private int stage_index = 0;

	void Start(){
		initial_placement();
	}

	public void initial_placement(){
		bits_trans.localPosition = new Vector2(0, -650f);
	}

	public void count_increment(){
		counter++;
		counter_trans.GetComponent<Text>().text = counter.ToString();

		if(counter == 24) next_stage();
	}

	public void count_set(int number){
		counter = number;
		counter_trans.GetComponent<Text>().text = counter.ToString();

		if(counter == 24) next_stage();
	}

	public void next_stage(){
		stage_index++;
		
		// I want to show "24" before stage advance.
		DOVirtual.DelayedCall(1.0f, ()=>{
			counter = 0;
			counter_trans.GetComponent<Text>().text = counter.ToString();

			if(stage_index == 1){
				bits_trans.DOLocalMoveY(-600f, 1.0f);
			}
			if(stage_index == 2){
				bits_trans.DOLocalMoveY(-550f, 1.0f);
				bits_trans.GetChild(0).DOLocalMoveY(-700f, 0.5f);
			}
		});
	}

	public int get_stage_index(){
		return stage_index;
	}
}
