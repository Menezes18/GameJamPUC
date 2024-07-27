using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashQuest : Quest {

    private void Start() {
        QuestName = "Recycle the trash";
        Description = "Clean all trash in the area and put them on the correct bin";

        Goals.Add(new RecycleGoal("Recicle all trash", false, 0, 5));

        Goals.ForEach(g => g.Init());
    }

}
