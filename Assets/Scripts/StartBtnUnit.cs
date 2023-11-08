using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.Mathematics;

public class StartBtnUnit : MonoBehaviour{

	public GameMaster master;
	private int HideCounter = 0;

	void Start(){
		transform.Find("StartBtn").GetComponent<CanvasGroup>().alpha = 1;
		transform.Find("FakeStartBtn").GetComponent<CanvasGroup>().alpha = 0;

		Color col = transform.Find("Hidden").GetComponent<Image>().color;
		col.a = 0;
		transform.Find("Hidden").GetComponent<Image>().color = col;
	}

	public void Stage1_Hundler(){
		if(master.get_stage_index() == 0){
			master.count_increment();
		}
	}

	public void Stage4_preparation(){
		transform.Find("StartBtn").GetComponent<CanvasGroup>().DOFade(0, 0.5f).SetEase(Ease.Linear);
		transform.Find("FakeStartBtn").GetComponent<CanvasGroup>().DOFade(1, 0.5f).SetEase(Ease.Linear);
	}

	public void Stage4_HideBtnClicked(){
		if(HideCounter >= 24) return;
		if(master.get_stage_index() == 3){
			HideCounter++;
			transform.Find("Hidden").GetComponentInChildren<Text>().text = "\n"+HideCounter.ToString();
			
			Color col = transform.Find("Hidden").GetComponent<Image>().color;
			col.a = 1f / 24f * HideCounter;
			transform.Find("Hidden").GetComponent<Image>().color = col;

			if(HideCounter == 24){
				DOVirtual.DelayedCall(1.0f, ()=>{
					Sequence seq = DOTween.Sequence();
					seq.Append(transform.Find("Hidden/HideCounter").DOLocalMoveY(118f, 0.5f));
					seq.Append(transform.Find("Hidden/HideCounter").DOLocalMoveY(0f, 0.5f));
				});
				DOVirtual.DelayedCall(1.5f, ()=>{
					master.count_set(24);
					transform.Find("Hidden").GetComponentInChildren<Text>().text = "TYPE\n"+HideCounter.ToString();
				});
			}
		}
		
	}

	// memo
	// 255 / 24 = 10.625

}
