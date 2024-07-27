using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour {

    [SerializeField] private GameObject[] fishPrefabs;

    public GameObject SpawnFish(GameObject targetLinePosition) {
        int randomFishIndex = Random.Range(0, fishPrefabs.Length);
        GameObject newFish = Instantiate(fishPrefabs[randomFishIndex], transform.position, Quaternion.identity, transform.parent);

        newFish.GetComponent<FishCharacter>().SetTarget(targetLinePosition);

        return newFish;
    }
  
}
