using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishLine : MonoBehaviour {
    
    [SerializeField] private FishSpawner spawner;
    [SerializeField] private GameObject exitPos;
    [SerializeField] private int MAX_LINE_SIZE = 5;
    public List<GameObject> fishes = new List<GameObject>();
    public float timerInterval = 15f;
    public bool menu = false;
    void Start() {
        InvokeRepeating("NewFishRequest", 1f, 3f);
        // InvokeRepeating("CompleteFishRequest", 5f, 4f);
        if (menu){
            InvokeRepeating("CompleteFishRequest", timerInterval, timerInterval);
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.N)){
            CompleteFishRequest();
        }
        
    }
    
    public void NewFishRequest() {
        GameObject targetPosition = fishes.Count > 0 ? fishes[fishes.Count - 1]  : gameObject ;
        if (fishes.Count <= MAX_LINE_SIZE) {
            fishes.Add(this.spawner.SpawnFish(targetPosition));
        }
    }

    public void CompleteFishRequest() {
        if (fishes.Count == 0) {
            return; // No fish to process
        }

        if (fishes[0] != null) {
            fishes[0].GetComponent<FishCharacter>().SetTarget(exitPos);
            fishes[0].GetComponent<FishCharacter>().CompleteRequest();
        }
        
        for (int i = 1; i < fishes.Count; i++) {
            if (fishes[i] != null) {
                fishes[i].GetComponent<FishCharacter>().SetTarget(i == 1 ? gameObject : fishes[i - 1]);
            }
        }

        // Remove the first fish from the list after it's processed
        if (fishes.Count > 0) {
            fishes.RemoveAt(0);
        }
    }
}