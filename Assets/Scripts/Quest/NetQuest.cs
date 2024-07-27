using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetQuest : Quest {

    private void Start() {
        QuestName = "Remove the Net";
        Description = "Cut all the net";

        Goals.Add(new RecycleGoal("Remove the net", false, 0, 3));

        Goals.ForEach(g => g.Init());
    }

}
