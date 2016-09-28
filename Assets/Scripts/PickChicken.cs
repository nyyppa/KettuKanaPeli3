using UnityEngine;
using System.Collections;

public class PickChicken : MonoBehaviour {
    
    public GameObject chickenInMouth;
    public GameObject chickenInDen1;
    public GameObject chickenInDen2;
    private int chickensInDenCount = 0;
    private const int CHICKEN_COUNT_TO_WIN = 2;
    private bool gameOn = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (chickensInDenCount == CHICKEN_COUNT_TO_WIN && gameOn) {
            print("You win!");
            gameOn = false;
        }
	}

	void OnTriggerEnter(Collider collider){
		
		if(collider.gameObject.tag.Equals ("Chicken") && !chickenInMouth.activeSelf) {
            chickenInMouth.SetActive(true);
            Destroy (collider.gameObject);
		}

        if (collider.gameObject.tag.Equals ("Den") && chickenInMouth.activeSelf) {
            chickenInMouth.SetActive(false);
            chickensInDenCount++;

            if (chickensInDenCount == 1) {
                chickenInDen1.SetActive(true);
            } else if (chickensInDenCount == 2) {
                chickenInDen2.SetActive(true);
            }
        }
	}
    
}
