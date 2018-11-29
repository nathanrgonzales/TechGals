using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrDontDestroyMusic : MonoBehaviour {
	void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}
}
