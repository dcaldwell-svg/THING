extends Area2D
@onready var node_2: Node = %Node2
func _on_body_entered(body):
	node_2.add_point() # Replace with function body.
	queue_free()
