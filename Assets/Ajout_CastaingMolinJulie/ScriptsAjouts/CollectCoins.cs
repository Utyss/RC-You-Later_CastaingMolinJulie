using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class CollectCoins : MonoBehaviour
{

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			PiecesManager.m_instance.AjoutPieces();
			Destroy(gameObject);
			
		}
	}
}
