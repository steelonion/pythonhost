context.Properties["name"]="test"
context.PrintLine("hello!")
context.AutoBind=True

def newfunc():
	pass

def testautobind():
	context.PrintLine("testautobind!")
