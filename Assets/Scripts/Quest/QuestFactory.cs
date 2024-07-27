using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestFactory : MonoBehaviour {

    [SerializeField] private List<Quest> quests = new List<Quest>();

    public Quest GetNewQuest(Transform parent) {
        int randomIndex = Random.Range(0, quests.Count);
        return Instantiate(quests[randomIndex], parent);
    }

}
