using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class InputExt : MonoBehaviour{

	public bool isEnable = false;
	
	private string input_stream = "";
	private List<string> input_targets = new List<string>();
	private Action input_callback;

	void Start(){
			
	}

	public void Update(){
		if(!isEnable) return;

		foreach(string target in input_targets){
			if(Input.GetKeyDown(target)){
				switch(target){
					case "space":
						input_stream += " ";
						break;
					default:
						input_stream += target;
						break;
				}
				input_callback.Invoke();
			}
		}
	}

	public void SetInputCallback(Action action){
		input_callback += action;
	}

	public string GetStream(){
		return input_stream;
	}

	public void ClearStream(){
		input_stream = "";
	}

	public void Add_target(string target){
		if(!input_targets.Exists(x => x == target)){
			input_targets.Add(target);
		}
	}
	public void Add_target(List<string> targets){
		foreach(string t in targets){
			Add_target(t);
		}
	}
}
