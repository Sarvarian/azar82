class_name BabrMainLoopGD
extends MainLoop

const BabrMainLoopScript : Script = preload("res://main_loop/BabrMainLoop.cs")

var babr_main_loop : MainLoop = null

func _initialize():
	babr_main_loop = BabrMainLoopScript.new()
	babr_main_loop._Initialize()

func _process(delta : float):
	return babr_main_loop._Process(delta)

func _physics_process(delta : float):
	return babr_main_loop._PhysicsProcess(delta)

func _finalize():
	babr_main_loop._Finalize()
