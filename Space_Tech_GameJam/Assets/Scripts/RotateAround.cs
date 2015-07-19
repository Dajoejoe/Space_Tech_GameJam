/************************************************
 *		Copyright (c) Ben's Weird Games 2014	*
 * 		Created by: Ben Toepke					*
 ***********************************************/
using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {
	
	public enum Axis
	{
		Forward, Up, Right, Random
	}
	public Axis axis;
	
	public enum Simulation
	{
		Local, World
	}
	public Simulation simulation;
	
	public bool rotate = true;
	public float speed = .1f;
	public bool randomSpeed = false;
	public float randomRange = 0;
	public float maxSpeed = 90;
	public bool accelerate = false;
	public float acceleration = 0;
	
	Transform _transform;
	// Use this for initialization
	void Start () {
		_transform = transform;
		if (randomSpeed)
			speed = Random.Range(-randomRange,randomRange);
	}
	
	// Update is called once per frame
	void Update () {
		if (rotate)
		{
			Rotate();
			
			if (accelerate)
			{
				speed += acceleration;
				if (speed > maxSpeed)
					speed = maxSpeed;
			}
		}
	}
	
	void Rotate()
	{
		Vector3 _axis = Vector3.zero;
		if (simulation == Simulation.World)
		{
			switch(axis)
			{
			case Axis.Forward:
				_axis = Vector3.forward;
				break;
			case Axis.Right:
				_axis = Vector3.right;
				break;
			case Axis.Up:
				_axis = Vector3.up;
				break;
			case Axis.Random:
				_axis = new Vector3(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f));
				_axis.Normalize();
				break;
			}
		}
		else if (simulation == Simulation.Local)
		{
			switch(axis)
			{
			case Axis.Forward:
				_axis = _transform.forward;
				break;
			case Axis.Right:
				_axis = _transform.right;
				break;
			case Axis.Up:
				_axis = _transform.up;
				break;
			case Axis.Random:
				_axis = new Vector3(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f));
				_axis.Normalize();
				break;
			}
		}
		
		_transform.RotateAround(_axis,speed*Time.deltaTime/40);
	}
}
