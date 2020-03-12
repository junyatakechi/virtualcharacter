using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRM;
using System;

public class BlendshapeController : MonoBehaviour {
	public GameObject vrm_obj;
	private VRMBlendShapeProxy proxy;

	// Use this for initialization
	void Start () {
		proxy = vrm_obj.GetComponent<VRMBlendShapeProxy>();
	}
	
	// Update is called once per frame
	void Update () {
		// VRMBlendShapeProxyはUpdateが始まってからでないと取得できない
		if (proxy == null){
			proxy = vrm_obj.GetComponent<VRMBlendShapeProxy>();
		}
		else
        {
			InputCommandFace(proxy);
		}
	}


	private void InputCommandFace(VRMBlendShapeProxy proxy) {
		String face_name = "";
		bool isUseKeyboad = true;
		if (isUseKeyboad)
		{
			if (Input.GetKey(KeyCode.Alpha1))
			{
				face_name = "NEUTRAL";
			}
			else if (Input.GetKey(KeyCode.Alpha2))
			{
				face_name = "ANGRY";
			}
			else if (Input.GetKey(KeyCode.Alpha3))
			{
				face_name = "FUN";
			}
			else if (Input.GetKey(KeyCode.Alpha4))
			{
				face_name = "JOY";
			}
			else if (Input.GetKey(KeyCode.Alpha5))
			{
				face_name = "SORROW";
			}
			else if (Input.GetKey(KeyCode.Alpha6))
			{
				face_name = "LOOKUP";
			}
			else if (Input.GetKey(KeyCode.Alpha7))
			{
				face_name = "LOOKDOWN";
			}
			else if (Input.GetKey(KeyCode.Alpha8))
			{
				face_name = "LOOKLEFT";
			}
			else if (Input.GetKey(KeyCode.Alpha9))
			{
				face_name = "LOOKRIGTH";
			}
			else if (Input.GetKey(KeyCode.Alpha5))
			{
				face_name = "BLINK";
			}
			else if (Input.GetKey(KeyCode.Z))
			{
				face_name = "BLINK_L";
			}
			else if (Input.GetKey(KeyCode.X))
			{
				face_name = "BLINK_R";
			}
			else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A))
			{
				face_name = "A";
			}
			else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.I))
			{
				face_name = "I";
			}
			else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.U))
			{
				face_name = "U";
			}
			else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.E))
			{
				face_name = "E";
			}
			else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.O))
			{
				face_name = "O";
			}

			else
			{
				face_name = "";
            }
		}

		//rest value
		proxy.AccumulateValue(BlendShapePreset.Neutral, 0.0f);
		proxy.AccumulateValue(BlendShapePreset.A, 0.0f);
		proxy.AccumulateValue(BlendShapePreset.I, 0.0f);
		proxy.AccumulateValue(BlendShapePreset.U, 0.0f);
		proxy.AccumulateValue(BlendShapePreset.E, 0.0f);
		proxy.AccumulateValue(BlendShapePreset.O, 0.0f);
		proxy.AccumulateValue(BlendShapePreset.Blink, 0.0f);
		proxy.AccumulateValue(BlendShapePreset.Blink_L, 0.0f);
		proxy.AccumulateValue(BlendShapePreset.Blink_R, 0.0f);
		proxy.AccumulateValue(BlendShapePreset.Angry, 0.0f);
		proxy.AccumulateValue(BlendShapePreset.Fun, 0.0f);
		proxy.AccumulateValue(BlendShapePreset.Joy, 0.0f);
		proxy.AccumulateValue(BlendShapePreset.Sorrow, 0.0f);
		proxy.AccumulateValue(BlendShapePreset.LookUp, 0.0f);
		proxy.AccumulateValue(BlendShapePreset.LookDown, 0.0f);
		proxy.AccumulateValue(BlendShapePreset.LookLeft, 0.0f);
		proxy.AccumulateValue(BlendShapePreset.LookRight, 0.0f);

		// apply face type
		switch (face_name){
			case "NEUTRAL":
				proxy.AccumulateValue(BlendShapePreset.Neutral, 1.0f);
				proxy.Apply();
				break;
			case "A":
				proxy.AccumulateValue(BlendShapePreset.A, 1.0f);
				proxy.Apply();
				break;
			case "I":
				proxy.AccumulateValue(BlendShapePreset.I, 1.0f);
				proxy.Apply();
				break;
			case "U":
				proxy.AccumulateValue(BlendShapePreset.U, 1.0f);
				proxy.Apply();
				break;
			case "E":
				proxy.AccumulateValue(BlendShapePreset.E, 1.0f);
				proxy.Apply();
				break;
			case "O":
				proxy.AccumulateValue(BlendShapePreset.O, 1.0f);
				proxy.Apply();
				break;
			case "BlINK":
				proxy.AccumulateValue(BlendShapePreset.Blink, 1.0f);
				proxy.Apply();
				break;
			case "BLINK_L":
				proxy.AccumulateValue(BlendShapePreset.Blink_L, 1.0f);
				proxy.Apply();
				break;
			case "BLINK_R":
				proxy.AccumulateValue(BlendShapePreset.Blink_R, 1.0f);
				proxy.Apply();
				break;
			case "ANGRY":
				proxy.AccumulateValue(BlendShapePreset.Angry, 1.0f);
				proxy.Apply();
				break;
			case "FUN":
				proxy.AccumulateValue(BlendShapePreset.Fun, 1.0f);
				proxy.Apply();
				break;
			case "JOY":
				proxy.AccumulateValue(BlendShapePreset.Joy, 1.0f);
				proxy.Apply();
				break;
			case "SORROW":
				proxy.AccumulateValue(BlendShapePreset.Sorrow, 1.0f);
				proxy.Apply();
				break;
			case "LOOKUP":
				proxy.AccumulateValue(BlendShapePreset.LookUp, 1.0f);
				proxy.Apply();
				break;
			case "LOOKDOWN":
				proxy.AccumulateValue(BlendShapePreset.LookDown, 1.0f);
				proxy.Apply();
				break;
			case "LOOKLEFT":
				proxy.AccumulateValue(BlendShapePreset.LookLeft, 1.0f);
				proxy.Apply();
				break;
			case "LOOKRIGHT":
				proxy.AccumulateValue(BlendShapePreset.LookRight, 1.0f);
				proxy.Apply();
				break;
			default:
				break;

		}
	}
}
