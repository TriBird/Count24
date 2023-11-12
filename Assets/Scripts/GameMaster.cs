using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Threading;

public class GameMaster : MonoBehaviour{

	public Transform counter_trans, bits_trans, clicktostart_trans;
	public InputExt inputext_ins;

	private int counter = 0;
	private int stage_max = 15;

	private List<bool> clear_flags = new List<bool>();

	void Start(){
		initial_placement();

		for(int i=0; i<stage_max; i++) clear_flags.Add(false);
	}

	public void initial_placement(){
		bits_trans.localPosition = new Vector2(0, -650f);
	}

	public void count_increment(int gimmickID){
		counter++;
		counter_trans.GetComponent<Text>().text = counter.ToString();

		if(counter == 24) clear_stage(gimmickID);
	}

	public void count_set(int number, int gimmickID){
		counter = number;
		counter_trans.GetComponent<Text>().text = counter.ToString();

		if(counter == 24) clear_stage(gimmickID);
	}

	public void clear_stage(int stage){
		DOVirtual.DelayedCall(1.0f, ()=>{
			clear_flags[stage] = true;
			count_set(0, 0);

			if(stage == 0){
				bits_trans.DOLocalMoveY(-600f, 1.0f);
			}
			if(stage == 1){
				bits_trans.DOLocalMoveY(-550f, 1.0f);
				bits_trans.GetChild(0).DOLocalMoveY(-700f, 0.5f);
			}
			if(stage == 2){
				clicktostart_trans.GetComponent<StartBtnUnit>().Stage3_preparation();
			}
			if(stage == 3){
				inputext_ins.isEnable = true;
				inputext_ins.Add_target(new List<string>(){"2", "4", "t", "w", "e", "n", "y", "space", "f", "o", "u", "r"});
				inputext_ins.SetInputCallback(()=>{
					// limit -> 11 str
					if(inputext_ins.GetStream().Length >= 12){
						inputext_ins.ClearStream();
						return;
					}

					counter_trans.GetComponent<Text>().text = inputext_ins.GetStream();

					// judge
					if(inputext_ins.GetStream() == "24"){
						// next_stage();
						clear_stage(4);
						inputext_ins.isEnable = false;
						DOVirtual.DelayedCall(1.0f, ()=>{
							inputext_ins.ClearStream();
							inputext_ins.isEnable = true;
						});
					}
					if(inputext_ins.GetStream() == "twenty four"){
						clear_stage(5);
						inputext_ins.isEnable = false;
						DOVirtual.DelayedCall(1.0f, ()=>{
							inputext_ins.ClearStream();
							inputext_ins.isEnable = true;
						});
					}
				});
			}
		});
	}

	public bool get_clear_flag(int stage_idx){
		return clear_flags[stage_idx];
	}

	public void DebugBtn(){
		for(int i=0; i<15; i++){
			if(!clear_flags[i]){
				print("Debug clear:" + i);
				clear_stage(i);
				return;
			}
		}
	}
}
