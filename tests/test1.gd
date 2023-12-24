extends Node

var text : Label = null

func _ready():
	text = Label.new()
	add_child(text)
	print(text.get_rect().size)
	text.text = "Hello, test!\nLets make it a long text."

func _physics_process(delta):
	print(text.get_rect().size)
	text.text += "2"
	
