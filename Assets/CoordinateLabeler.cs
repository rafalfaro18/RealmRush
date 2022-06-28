using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways] // Run In Editor mode.
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    void Awake() {
        label = GetComponent<TextMeshPro>();
        DisplayCoordinates();
    }
    
    void Update()
    {
        if(!Application.isPlaying){
            DisplayCoordinates();
        }
    }

    void DisplayCoordinates(){
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.y);
        label.text = $"{coordinates.x},{coordinates.y}";
    }
}
