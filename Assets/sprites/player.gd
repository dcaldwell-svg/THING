extends CharacterBody2D

var is_attacking = false
const SPEED = 130.0
const JUMP_VELOCITY = -350.0
@onready var animated_sprite: AnimatedSprite2D = $AnimatedSprite2D
func _physics_process(delta: float) -> void:
	# Add the gravity.
	if not is_on_floor():
		velocity += get_gravity() * delta
	if Input.is_action_just_pressed("attack") and is_on_floor():
		is_attacking = true
		
	# Handle jump.
	if Input.is_action_just_pressed("jump") and is_on_floor():
		velocity.y = JUMP_VELOCITY

	# Get the input direction and handle the movement/deceleration.
	# As good practice, you should replace UI actions with custom gameplay actions.
	var direction := Input.get_axis("moveleft", "moveright")
	if direction > 0:
		animated_sprite.flip_h = false
	elif direction < 0:
		animated_sprite.flip_h = true
	if is_on_floor() and not is_attacking:
		if direction == 0:
			animated_sprite.play("idle") 
		else:
			animated_sprite.play("run")
	elif not is_attacking:
		animated_sprite.play("jump")
	else:
		animated_sprite.play("attack")

	if direction:
		velocity.x = direction * SPEED
	else:
		velocity.x = move_toward(velocity.x, 0, SPEED)

	move_and_slide()


func _on_animated_sprite_2d_animation_finished() -> void:
	animated_sprite.play("idle")
	is_attacking = false
