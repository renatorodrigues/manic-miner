

function addClearingFloor(%x,%y,%w,%h){
	
	for(%i=0;5*%i<%w;%i++){
		
	myModule.cfloor[myModule.cfloor]=new Sprite();
	myModule.cfloor[myModule.cfloor].setBodyType( static );

	
    myModule.cfloor[myModule.cfloor].Position = (%i*5+%x) SPC %y;

    
    myModule.cfloor[myModule.cfloor].Size = 5 SPC %h;
   myModule.cfloor[myModule.cfloor].Friction=0;
  myModule.cfloor[myModule.cfloor].SceneLayer = 5;
  myModule.cfloor[myModule.cfloor].SceneGroup = 2 ;
   
   myModule.cfloor[myModule.cfloor].Image = "myModule:cTile";
    myModule.cfloor[myModule.cfloor].UseBackgroundColor = true;
    myModule.cfloor[myModule.cfloor].createEdgeCollisionShape( -5/2, -%h/2, -5/2, %h/2 );
   myModule.cfloor[myModule.cfloor].createEdgeCollisionShape( 5/2, -%h/2, 5/2, %h/2);
   myModule.cfloor[myModule.cfloor].createEdgeCollisionShape( -5/2, %h/2, 5/2, %h/2 );
    myModule.cfloor[myModule.cfloor].createEdgeCollisionShape( -5/2, -%h/2, 5/2, -%h/2 );   
    myScene.add( myModule.cfloor[myModule.cfloor]);  

    	myModule.nfloor++;
    	}

}
