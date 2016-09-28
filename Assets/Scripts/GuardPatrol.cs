using UnityEngine;
using System.Collections;

public class GuardPatrol : MonoBehaviour {
	private NavMeshAgent agent;
	public waypoint[] navPoints;
	private waypoint nextWaypoint;
	private int waypointIndex=0;
	public VisionPoint visionpoint;
	public Vector3 destination;
    public float spottedMultiplier = 1.5f;
	public float pursuitMultiplier = 2;
	GameObject player;
	private float originalSpeed;
	public GameObject pursuit;
	public GameObject noticed;
	public float rotationSpeed=1;
	public float RotationDegree=90;
	public float maxRotateTime=2;
	public float rotationTime=9000;
	Rigidbody r;
	//private Vector3 originalRotation;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		setNextWaypoint (navPoints [0]);
		originalSpeed = agent.speed;
		pursuit.SetActive (false);
		noticed.SetActive (false);
		r = GetComponent<Rigidbody> ();
		agent.updateRotation =false;
		rotationTime = maxRotateTime * 3 + 1;
	}

	void setNextWaypoint(waypoint w){
		agent.SetDestination (w.transform.position);
		nextWaypoint = w;
	}

	void Rotate(){
		//r.rotation *= deltaRotation;
		agent.updateRotation = false;
		if(rotationTime<maxRotateTime){
			Quaternion deltaRotation = Quaternion.Euler (transform.up * rotationSpeed * Time.deltaTime);
			transform.rotation = r.rotation*deltaRotation;
            agent.speed = 0;
            agent.updatePosition = false;
		}else if(rotationTime<maxRotateTime * 3){
			Quaternion deltaRotation = Quaternion.Euler (transform.up * rotationSpeed * Time.deltaTime);
			transform.rotation = r.rotation * Quaternion.Inverse(deltaRotation);
            agent.speed = 0;
            agent.updatePosition = false;
		}else{
            if (agent.speed == 0)
            {
                agent.speed = originalSpeed;
            }
			agent.updatePosition = true;
			agent.updateRotation = true;
		}
		rotationTime += Time.deltaTime;
	}

	void Update () {
		Rotate ();
		if(player){
			agent.destination = player.transform.position;
			if(!pursuit.activeSelf){
				pursuit.SetActive (true);
				noticed.SetActive (false);
			}
		} else if (visionpoint) {
			if(!noticed.activeSelf){
				noticed.SetActive (true);
				pursuit.SetActive (false);
			}
		} else {
			if(noticed.activeSelf){
				noticed.SetActive (false);
			}
			if(pursuit.activeSelf){
				pursuit.SetActive (false);
			}
		}
		destination=agent.destination;

		if(agent.isPathStale) {
			agent.ResetPath ();
		}

		if(agent.pathStatus==NavMeshPathStatus.PathPartial||agent.pathStatus==NavMeshPathStatus.PathInvalid) {
			if(!agent.pathPending){
				startNextWaypoint ();
			}
		}
	}
	public void waypointReached(waypoint g){
		if(g==nextWaypoint){
			startNextWaypoint ();
		}
	}
	void startNextWaypoint(){
		if(waypointIndex>=navPoints.Length-1){
			waypointIndex = 0;
			setNextWaypoint (navPoints [waypointIndex]);
		}else{
			waypointIndex++;
			setNextWaypoint (navPoints [waypointIndex]);
		}
	}
	public void setVisionPoint(VisionPoint v){
		if(visionpoint){
			Destroy (visionpoint.gameObject);
		}

		visionpoint = v;
		agent.SetDestination (v.transform.position);
		/*print (agent.nextPosition);
		print (this.transform.position);
		print (transform.tag);
		LineRenderer line = GetComponent<LineRenderer> ();
		line.SetPositions (new Vector3[]{gameObject.transform.position,v.transform.position});
		Time.timeScale = 0;*/
	}
	public void visionPointReached(VisionPoint v){
		if(visionpoint==v){
			Destroy (v.gameObject);
			visionpoint = null;
            //agent.SetDestination (nextWaypoint.transform.position);
            if (!player)
            {
                rotationTime = 0;
            }
			
			//agent.speed = 0;

		}
	}

	void OnCollisionEnter(Collision other){
		if(other.collider.tag.Equals ("Fox")){
			Destroy (other.collider.gameObject);
            print("You lose!");
		}
	}

	public void followPlayer(GameObject player){
		this.player = player;
		if(player==null){
			if(visionpoint){
				if(agent.destination!=visionpoint.transform.position){
					agent.SetDestination (visionpoint.transform.position);
					agent.speed = originalSpeed * spottedMultiplier;
				}
			}else{
				if(agent.destination!=nextWaypoint.transform.position){
					agent.SetDestination (nextWaypoint.transform.position);
                    if (rotationTime < maxRotateTime * 3)
                    {
                        agent.speed = originalSpeed;
                    }
					
				}
			}
		}else{
			if(agent.speed==originalSpeed){
				agent.speed *= pursuitMultiplier;
			}
		}

	}
}
