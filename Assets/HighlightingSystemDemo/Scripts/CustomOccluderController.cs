using UnityEngine;
using System.Collections;

public class CustomOccluderController : MonoBehaviour {

    void OnEnable() {
        HighlightableObject ho = gameObject.GetComponent<HighlightableObject>();
        if (ho == null) {
            ho = gameObject.AddComponent<HighlightableObject>();
        }
        ho.OccluderOn();
    }
}
