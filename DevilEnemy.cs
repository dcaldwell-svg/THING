using Godot;
using System;

public partial class DevilEnemy : CharacterBody2D
{
	// The maximum distance the Area2D will move from its start position
	[Export] public float MoveDistance { get; set; } = 200f;

	// How fast the Area2D moves
	[Export] public float Speed { get; set; } = 100f;

	// Movement axis: true for Horizontal (X), false for Vertical (Y)
	[Export] public bool IsHorizontal { get; set; } = true;

	private Vector2 _startPosition;
	private float _timePassed = 0f;

	public override void _Ready()
	{
		// Store the starting position so we oscillate around or from it
		_startPosition = Position;
	}

	public override void _Process(double delta)
	{
		// Accumulate time scaled by speed
		_timePassed += (float)delta * Speed;

		// Mathf.PingPong bounces between 0 and MoveDistance
		float offset = Mathf.PingPong(_timePassed, MoveDistance);

		if (IsHorizontal)
		{
			Position = new Vector2(_startPosition.X + offset, _startPosition.Y);
		}
		else
		{
			Position = new Vector2(_startPosition.X, _startPosition.Y + offset);
		}
	}
	
	
	
	public void OnPlayerEnter(Node2D body) {
		if (body is Player) {
			GetTree().ReloadCurrentScene();
		}
	}
}
