using Godot;
using System;

public partial class PlayerMovement2D : CharacterBody2D
{
	// The [Export] attribute allows you to edit this value inside the Godot Editor Inspector
	[Export] 
	public float Speed { get; set; } = 200.0f;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

		if (direction != Vector2.Zero)
		{
			velocity = direction * Speed;
		}
		else
		{
			velocity = velocity.MoveToward(Vector2.Zero, Speed);
		}
		Velocity = velocity;
		MoveAndSlide(); 
	}
}
