using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRM;
using System;
using System.Linq;

public class BlendshapeController : MonoBehaviour {
	public GameObject vrm_obj;
	private VRMBlendShapeProxy proxy;

	[Tooltip("瞬きさせるかどうか")]
	public bool IsActive = true;
	[Tooltip("瞬きの強さ（表情の目の開き具合に合わせる）")]
	[Range(0, 2.0f)]
	public float ModulateRatio = 1.0f;
	public BlinkParameterSet blinkParameters = new BlinkParameterSet();
	public bool IsBlinking { get { return player != null && !player.IsFinished; } }
    private TransitionPlayer player;



	// Use this for initialization
	void Start() {
		proxy = vrm_obj.GetComponent<VRMBlendShapeProxy>();
		StartCoroutine(BlinkSignaler());
	}

	// Update is called once per frame
	void Update() {
		// VRMBlendShapeProxyはUpdateが始まってからでないと取得できない
		if (proxy == null) {
			proxy = vrm_obj.GetComponent<VRMBlendShapeProxy>();
		}
		else
		{
			InputCommandFace(proxy);
		}

		if (IsBlinking)
		{
			proxy.ImmediatelySetValue(BlendShapePreset.Blink, player.Next(Time.deltaTime));
		}

	}

	private void OnDestroy()
	{
		StopAllCoroutines();
	}

	IEnumerator BlinkSignaler()
	{
		while (true)
		{
			if (IsActive && !IsBlinking)
			{
				// randomThreshold の確率で瞬きしない
				float _seed = UnityEngine.Random.Range(0.0f, 1.0f);
				if (_seed > blinkParameters.randomThreshold)
				{
					Blink();
				}
			}
			// interval だけ待つ
			yield return new WaitForSeconds(blinkParameters.interval);
		}
	}

	private void Blink()
	{
		player = new TransitionPlayer(CreateBlinkTransition(), proxy.GetValue(BlendShapePreset.Blink));
	}

	private BlendshapeController.Transition CreateBlinkTransition()
	{
		var closePartDuration = blinkParameters.closeDuration / 2;
		var openPartDuration = blinkParameters.openDuration / 2;
		return new BlendshapeController.Transition()
			.AddKey(blinkParameters.ratioHalf * ModulateRatio, closePartDuration)
			.AddKey(blinkParameters.ratioClose * ModulateRatio, closePartDuration)
			.AddKey(blinkParameters.ratioHalf * ModulateRatio, openPartDuration)
			.AddKey(0, openPartDuration);
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
		switch (face_name) {
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


	[Serializable]
	public class BlinkParameterSet
	{
		[Range(0, 1.0f)]
		public float ratioHalf = 0.3f;
		[Range(0, 1.0f)]
		public float ratioClose = 0.9f;
		public float closeDuration = 0.1f;
		public float openDuration = 0.2f;
		public float interval = 1.5f;
		[Range(0, 1.0f)]
		public float randomThreshold = 0.7f;
	}

	#region Transition
	public class Transition
	{
		private List<TransitionKey> keys;

		public IEnumerable<TransitionKey> Keys { get { return keys.AsEnumerable(); } }

		public Transition()
		{
			keys = new List<TransitionKey>();
		}

		public Transition AddKey(float weight, float duration)
		{
			keys.Add(new TransitionKey(weight, duration));
			return this;
		}

		[Serializable]
		public class TransitionKey
		{
			public TransitionKey(float targetWeight, float duration)
			{
				this.targetWeight = targetWeight;
				this.duration = duration;
			}
			public float targetWeight;
			public float duration;
		}
	}

	private class TransitionPlayer
	{
		private Queue<Transition.TransitionKey> keys;
		public bool IsFinished { private set; get; }

		private Transition.TransitionKey previousKey;
		private Transition.TransitionKey currentKey;
		private float current;
        private Transition transition;
        private float v;

        public TransitionPlayer(Transition t, float startingWeight)
		{
			keys = new Queue<Transition.TransitionKey>(t.Keys);
			previousKey = new Transition.TransitionKey(startingWeight, 0);
			currentKey = keys.Dequeue();
			current = 0;
			IsFinished = false;
		}

        public float Next(float timeDelta)
		{
			if (IsFinished) return currentKey.targetWeight;

			current += timeDelta;
			if (current > currentKey.duration)
			{
				if (keys.Count == 0)
				{
					IsFinished = true;
					return currentKey.targetWeight;
				}

				previousKey = currentKey;
				currentKey = keys.Dequeue();
				current -= currentKey.duration;
			}

			return Mathf.Lerp(previousKey.targetWeight, currentKey.targetWeight, current / currentKey.duration);
		}

		public void Abort()
		{
			IsFinished = true;
		}
	}
	#endregion
    
}
