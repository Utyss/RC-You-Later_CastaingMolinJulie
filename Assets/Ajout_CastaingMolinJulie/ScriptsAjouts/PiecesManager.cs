using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class PiecesManager : MonoBehaviour
{
    public static PiecesManager m_instance;

    private int pieces = 0;
    public TextMeshProUGUI piecesText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (m_instance == null)
        {
            m_instance = this;
        }
    }

    // Update is called once per frame
    public void AjoutPieces()
    {
        pieces += 1;
        piecesText.text = $"Pieces : {pieces}";

        Debug.Log("piece gagnée. Total : " + pieces);
    }
}
