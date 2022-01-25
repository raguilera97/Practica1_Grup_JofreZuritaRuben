using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInf_UI : MonoBehaviour
{

    private Text levelText;
    private Image experienceBar;

    [SerializeField] LevelSystem levelSystem;

    void Start()
    {
        levelText = transform.Find("Lvl").GetComponent<Text>();
        experienceBar = transform.Find("Exp").Find("ExpBar").GetComponent<Image>();

        SetLevelSystem();
    }
    private void SetExpBarSize(float experienceNormalized)
    {
        experienceBar.rectTransform.sizeDelta = new Vector2(experienceNormalized, 14.86f);
    }
    public void SetLevelNumber(int levelNumber)
    {
        levelText.text = "" + (levelNumber + 1);
    }
    public void SetLevelSystem()
    {
        SetLevelNumber(levelSystem.GetLevelNumber());
        SetExpBarSize(levelSystem.GetExpNormalized() * 291.8f / levelSystem.nextLevel);

        levelSystem.OnExperienceChanged += LevelSystem_OnExperienceChanged;
        levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
    }

    private void LevelSystem_OnExperienceChanged(object sender, EventArgs e)
    {
        SetExpBarSize(levelSystem.GetExpNormalized() * 291.8f);
    }

    private void LevelSystem_OnLevelChanged(object sender, EventArgs e)
    {
        SetLevelNumber(levelSystem.GetLevelNumber());
    }


}
