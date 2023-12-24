extends Node

@onready var main = $".."

func _ready():
	call_deferred("start")

func start():
	main.Start();
