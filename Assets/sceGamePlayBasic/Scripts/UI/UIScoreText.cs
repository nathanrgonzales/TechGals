using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RedRunner.UI
{

	public class UIScoreText : Text
	{

		protected bool m_Collected = false;

		protected override void Awake ()
		{			
			GameManager.OnReset += GameManager_OnReset;
			base.Awake ();
		}

		void GameManager_OnReset ()
		{
			m_Collected = false;
		}
	}

}