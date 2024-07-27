using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleGoal : Goal {


    public RecycleGoal(string description, bool completed, int currentAmount, int requredAmoutn) {
        this.Description = description;
        this.Completed = completed;
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requredAmoutn;
    }

    public override void Init() {
        base.Init();
    }

    void TrashRecicled() {
        this.CurrentAmount++;
        this.Evaluate();
    }
}
