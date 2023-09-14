using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreRegistration : MonoBehaviour
{
    void Start() // texte atadık bunu kayıtını burdan yaptık
    {
        TextMeshProUGUI textForRegistation = GetComponent<TextMeshProUGUI>();

        EndGameManager.instance.RegisterScoreText(textForRegistation);

        textForRegistation.text = "Score: 0 ";
    }

   
}
