using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveQuest : Quest {

    private void Start() {
        QuestName = "Realocate the fishes";
        Description = "Realocate the fishes to a colder watert";

        Goals.Add(new RecycleGoal("Realocate the fishes", false, 0, 7));

        Goals.ForEach(g => g.Init());
    }

}
