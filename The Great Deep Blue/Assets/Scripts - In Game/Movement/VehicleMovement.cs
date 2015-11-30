using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(RTSObject))]
public class VehicleMovement : LandMovement {
    
    private NavMeshPath path;

    private Quaternion m_LookRotation;
    private Vector3 m_Direction;
    private bool m_PlayMovingSound = false;
    private bool m_SoundIsPlaying = false;

    public bool AffectedByCurrent = true;
	public Rigidbody rb;

    FMOD.Studio.EventInstance sfx_Manager;

    public float RotationalSpeed 
	{
		get;
		private set;
	}
	
	public float Acceleration
	{
		get;
		private set;
	}
	
	public override Vector3 TargetLocation 
	{
		get 
		{
			if (Path == null || Path.Count == 0)
			{
				return Vector3.zero;
			}
			else
			{
				return Path[Path.Count-1];
			}
		}
	}
	
	// Use this for initialization
	void Start () 
	{
		m_Parent = GetComponent<RTSObject>();
		//m_CurrentTile.SetOccupied(m_Parent, false);

		rb = GetComponent<Rigidbody>();
	}

    private new void Update()
    {
        base.Update();

        if (Application.isEditor)
        {
            if (Path != null)
            {
                /*for (int i = 1; i < Path.Count; i++)
                {
                    Debug.DrawLine(Path[i - 1], Path[i]);
                } */
            }
            else
            {
                Debug.DrawLine(transform.position, transform.position + Vector3.forward * 10);
            }
        }

        if (Path != null && Path.Count > 0)
        {
            m_PlayMovingSound = true;
            AffectedByCurrent = false;
            MoveForward();

            //We have a path, lets move!
            //Make sure we're pointing at the target            
            if (!PointingAtTarget())
            {
                RotateTowards(TargetLocation);
            }           
            
            UpdateCurrentTile();
        }
        else
        {
            m_Parent.GetComponent<Rigidbody>().velocity = transform.forward * 0;
            m_PlayMovingSound = false;
            AffectedByCurrent = true;
        }

        if (m_PlayMovingSound && !m_SoundIsPlaying)
        {
           // sfx_Manager = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/" + m_Parent.Name + "/movement");
            //sfx_Manager.start();
            m_SoundIsPlaying = true;
        }
        else if (!m_PlayMovingSound && m_SoundIsPlaying)
        {
            //sfx_Manager.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
           // sfx_Manager.release();
            m_SoundIsPlaying = false;
        }
    }

    private void FindPath(Vector3 location)
    {
        //path = new NavMeshPath();
        //NavMesh.CalculatePath(m_Parent.transform.position, location, NavMesh.AllAreas, path);
    }

    private void RotateTowards(Vector3 location)
    {
        m_Direction = (location - m_Parent.transform.position).normalized;

        m_LookRotation = Quaternion.LookRotation(new Vector3(m_Direction.x, m_Direction.y * 0, m_Direction.z));

        m_Parent.transform.rotation = Quaternion.Slerp(m_Parent.transform.rotation, m_LookRotation, Time.deltaTime * RotationalSpeed);
    }

    private void MoveForward()
    {
        //m_Parent.transform.Translate(Vector3.forward * Speed);
        m_Parent.GetComponent<Rigidbody>().AddForce(transform.forward * Speed);

        if (m_TargetTile == m_ArrivalTile)
        {
            Stop();
            m_Parent.GetComponent<Rigidbody>().velocity = transform.forward * 0;
        }
    }

    public override void MoveTo(Vector3 location)
    {
        if (m_ArrivalTile != null)
        {
            m_ArrivalTile.ExpectingArrival = false;
        }
        m_ArrivalTile = Grid.GetClosestArrivalTile(location);
        m_ArrivalTile.ExpectingArrival = true;

        Tile currentTile = Grid.GetClosestTile(transform.position);
        ManagerResolver.Resolve<IThreadManager>().AddPathfindingThread(new GetPathThread(m_Parent, currentTile, m_ArrivalTile, Const.BLOCKINGLEVEL_Normal));
    }

    public override void Stop()
    {
        if (Path != null && Path.Count > 0)
        {
            Vector3 nextPos = Path[0];
            Path.Clear();
            Path.Add(nextPos);
            m_Parent.GetComponent<Rigidbody>().velocity = transform.forward * 0;
        }
    }

    public override void Follow(Transform target)
    {
        MoveTo(target.position);
    }


    public override void AssignDetails(Item item)
    {
        Speed = item.Speed / 2;
        CurrentSpeed = 0;
        RotationalSpeed = item.RotationSpeed / 2;
        Acceleration = item.Acceleration;
    }

    private void UpdateCurrentTile()
    {
        //What sort of tile are we on
        Tile currentTile = m_CurrentTile;
        m_CurrentTile = Grid.GetClosestTile(transform.position);

        if (currentTile != null && currentTile != m_CurrentTile)
        {
            //We've changed tiles, make sure the old tile is no longer occupied
            currentTile.NoLongerOccupied(m_Parent);

            //Since we've changed, our next tile should equal the target tile
            if (m_CurrentTile != m_TargetTile)
            {
                //If it doesn't equal then we've drifted off the tiles slightly, set the current tile the target tile
                m_CurrentTile = m_TargetTile;
            }

            if (Path.Count == 1)
            {
                m_CurrentTile.SetOccupied(m_Parent, true);
            }
            else
            {                
                m_CurrentTile.SetOccupied(m_Parent, false);
            }
        }
    }

    private bool PointingAtTarget()
    {
        Vector3 forwardVector = transform.forward;
        Vector3 targetVector = Path[0] - transform.position;

        forwardVector.y = 0;
        targetVector.y = 0;

        float angle = Vector3.Angle(forwardVector, targetVector);
        Vector3 crossProduct = Vector3.Cross(forwardVector, targetVector);

        if (crossProduct.y < 0) angle *= -1;

        if (Mathf.Abs(angle) < 2.0f)
        {
            return true;
        }
        else
        {
            int direction = 1;
            if (angle < 0)
            {
                direction = -1;
            }

            transform.Rotate(0, RotationalSpeed * Time.deltaTime * direction, 0);
        }

        return false;
    }
    
}
 