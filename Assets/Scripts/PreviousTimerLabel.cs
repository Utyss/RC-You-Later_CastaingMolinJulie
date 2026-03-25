using System;
using TMPro;
using UnityEngine;

public class PreviousTimerLabel : MonoBehaviour
{
	public TextMeshProUGUI previousLabel;

	private static PreviousTimerLabel m_instanceLabel;

	void Awake()
	{
		m_instanceLabel = this;
	}

    //public static void AffichageScoreLoaded()
    //{
    //	string precedentScoreText = "";

    //	foreach (long step in Timer.steps)
    //	{
    //		double timeInSeconds = step * 0.001f;
    //		precedentScoreText += "Previous Time:" + "s\n" + timeInSeconds.ToString("F2") + "s\n";
    //	}

    //       m_instanceLabel.previousLabel.text = precedentScoreText;
    //   }
}
