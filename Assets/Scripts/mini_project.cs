using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class mini_project : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject[] waypoints;
    public float moveSpeed;
    private float WPradius = 0.5f;
    private int currentWaypoint = 0;
    private int waypointMoved = 0;
    private int currentObject = 0;
    private UIDocument doc;
    private Button nextButton;
    private bool nextButtonClicked;

    // Start is called before the first frame update
    void Awake(){
        doc = GetComponent<UIDocument>();
        nextButton = doc.rootVisualElement.Q<Button>("next_button");
        nextButton.clicked += NextButtonClick;
    }
    void Start()
    {
        nextButtonClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(nextButtonClicked == true){
            moveObject(objects[currentObject],waypoints);
        }
        
    }

    void moveObject(GameObject objectToMove,GameObject[] waypoints){
        if(Vector3.Distance(waypoints[currentWaypoint].transform.position, objectToMove.transform.position) < WPradius){
            currentWaypoint++;
            waypointMoved++;
            if(waypointMoved == 2){
                if(currentObject >= objects.Length){
                    currentObject = 0;
                }else{
                    currentObject++;
                }
                waypointMoved = 0;
                nextButtonClicked = false;
            }

            if(currentWaypoint>= waypoints.Length){
                currentWaypoint = 0;
                nextButtonClicked = false;
            }
        }
        objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, waypoints[currentWaypoint].transform.position, Time.deltaTime * moveSpeed); 
        objectToMove.transform.eulerAngles = new Vector3(waypoints[currentWaypoint-1].transform.eulerAngles.x,
                                                          waypoints[currentWaypoint-1].transform.eulerAngles.y,
                                                          waypoints[currentWaypoint-1].transform.eulerAngles.z  ); 
    }



    private void NextButtonClick(){
        if(nextButtonClicked == false){
            nextButtonClicked = true;
        }else{
            nextButtonClicked = false;
        }
    }

    private void startButtonClicked(){
        
    }
}
