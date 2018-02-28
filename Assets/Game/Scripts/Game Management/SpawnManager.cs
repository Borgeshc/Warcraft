using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public List<Stage> stages;
    public List<Transform> spawnPositions;

    public Text stageText;

    [HideInInspector]
    public List<GameObject> activeEnemies;

    int currentStage;

    bool beginingStage;
    bool stageActive;
	
	void Update ()
    {
        if(!stageActive)
        {
            if(!beginingStage)
                stageText.text = "Press <R> To Begin Stage " + (currentStage + 1) + "!";

            if (Input.GetKeyDown(KeyCode.R))
            {
                stageActive = true;
                if (!beginingStage)
                {
                    beginingStage = true;
                    StartCoroutine(BeginningStage());
                }
            }
        }
	}

    IEnumerator BeginningStage()
    {
        for(int i = 3; i > 0; i--)
        {
            stageText.text = "Stage Begins in... " + i + "!";
            yield return new WaitForSeconds(1);
        }

        stageText.text = "";

        StageActive();
    }

    void StageActive()
    {
        for (int i = 0; i < stages[currentStage].enemies.Count; i++)
        {
           GameObject enemy = Instantiate(stages[currentStage].enemies[i], spawnPositions[stages[currentStage].spawnPositions[i]].position, spawnPositions[stages[currentStage].spawnPositions[i]].rotation);
            activeEnemies.Add(enemy);
        }

        currentStage++;
    }

    public void CheckStage(GameObject enemy)
    {
        activeEnemies.Remove(enemy);
        if (activeEnemies.Count <= 0)
        {
            beginingStage = false;
            stageActive = false;
        }
    }
}
