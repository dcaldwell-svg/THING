extends Area2D
@onready var node_2: Node = %Node2
@onready var animation_player: AnimationPlayer = $AnimationPlayer

func _on_body_entered(body):
	node_2.add_point() # Replace with function body.
	animation_player.play("new_animation")
