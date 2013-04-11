function readFile()
{
	%file = new FileObject();

	if(%file.openForRead("maps.dat"))
	{
		%x=1;
		while(!%file.isEof())
		{
			%line = %file.readLine();
			echo("line" @ %x @ " = " @ %line);
			%x++;
		}
	}
	else
	{
		error("CANNOT OPEN FOR READ");
	}
	%file.close();
	%file.delete();
}

function filewrite(%this)
{
	%saveFile = new FileObject();
	
	//%dataFile = expandFilename();	
	%saveFile.openForWrite("MyGameSaveData.dat");
	
	%saveFile.writeLine("Saved Game Data for MyGame, Version 1.0");
	
	%saveFile.writeLine("Test - Hello World");
	
	
	%saveFile.close();
	%saveFile.delete();
}
