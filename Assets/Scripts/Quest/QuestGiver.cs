using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC {
    public bool AssignedQuest {get; set;}
    public bool Helped {get; set;}
    public Quest QuestToGive {get; set;}

    [SerializeField] private GameObject questFactory;
    private GameObject factoryInstace;

    private void Start() {
        factoryInstace = Instantiate(questFactory);
    }


    public override void Interact() {
        base.Interact();

        if (!AssignedQuest && !Helped) {
            AssignQuest();
        } else if (!AssignedQuest && Helped) {

        } else  if (AssignedQuest && !Helped) {
            CheckQuest();
        }
    }

    void AssignQuest() {
        AssignedQuest = true;
        QuestToGive = factoryInstace.GetComponent<QuestFactory>().GetNewQuest(transform);
    }

    void CheckQuest() {
        if (QuestToGive.Completed) {
            QuestToGive.GiveReward();
            Helped = true;
            AssignedQuest = false;
        }
    }

}
