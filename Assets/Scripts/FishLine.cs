using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishLine : MonoBehaviour {
    [SerializeField] private FishSpawner spawner;
    [SerializeField] private GameObject exitPos;
    [SerializeField] private int MAX_LINE_SIZE = 5;
    public List<GameObject> fishes = new List<GameObject>();

    void Start() {
        InvokeRepeating("NewFishRequest", 1f, 3f);
        InvokeRepeating("CompleteFishRequest", 5f, 4f);
    }

    public void NewFishRequest() {
        GameObject targetPosition = fishes.Count > 0 ? fishes[fishes.Count - 1]  : gameObject ;
        if (fishes.Count <= MAX_LINE_SIZE) {
            fishes.Add(this.spawner.SpawnFish(targetPosition));



            

        }
    }

    public void CompleteFishRequest() {
        fishes[0].GetComponent<FishCharacter>().SetTarget(exitPos);
        fishes[0].GetComponent<FishCharacter>().CompleteRequest();

        fishes[1].GetComponent<FishCharacter>().SetTarget(gameObject);
        for(int i = 2; i < fishes.Count; i++) {
            fishes[i].GetComponent<FishCharacter>().SetTarget(fishes[i -1]);
        }

        fishes.RemoveAt(0);
    }
}
