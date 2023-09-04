using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ButtonIcons : MonoBehaviour
{
    [SerializeField] private Button[] lvlButton;
    [SerializeField] private Sprite unlockedIcon;
    [SerializeField] private Sprite lockedIcon;
    [SerializeField] private int firstLevelBuildIndex;

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt(EndGameManager.instance.levelUnlock, firstLevelBuildIndex);

        for (int i = 0; i < lvlButton.Length; i++)
        {
            if (i + firstLevelBuildIndex <= unlockedLevel) // unlocked
            {
                lvlButton[i].interactable = true;
                lvlButton[i].image.sprite = unlockedIcon;
                TextMeshProUGUI textButton = lvlButton[i].GetComponentInChildren<TextMeshProUGUI>();
                textButton.text = (i + 1).ToString();
                textButton.enabled = true;

            }
            else // locked
            {
                lvlButton[i].interactable = false;
                lvlButton[i].image.sprite = lockedIcon;
                lvlButton[i].GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            }
        }
    }


}
