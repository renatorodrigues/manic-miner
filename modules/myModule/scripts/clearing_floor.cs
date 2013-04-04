

function addClearingFloor(%x,%y,%w,%h){
	
	for(%i=0;3*%i<%w;%i++){
		
	myModule.cfloor[myModule.cfloor]=new Sprite();
	myModule.cfloor[myModule.cfloor].setBodyType( static );

	
    myModule.cfloor[myModule.cfloor].Position = (%i*3+%x) SPC %y;

    
    myModule.cfloor[myModule.cfloor].Size = 3 SPC %h;
   myModule.cfloor[myModule.cfloor].Friction=0;
  myModule.cfloor[myModule.cfloor].SceneLayer = 5;
  myModule.cfloor[myModule.cfloor].SceneGroup = 2 ;
   
   myModule.cfloor[myModule.cfloor].Image = "myModule:cTile";
    myModule.cfloor[myModule.cfloor].UseBackgroundColor = true;
    /*myModule.cfloor[myModule.cfloor].createEdgeCollisionShape( -3/2, -%h/2, -3/2, %h/2 );
   myModule.cfloor[myModule.cfloor].createEdgeCollisionShape( 3/2, -%h/2, 3/2, %h/2);
   myModule.cfloor[myModule.cfloor].createEdgeCollisionShape( -3/2, %h/2, 3/2, %h/2 );
    myModule.cfloor[myModule.cfloor].createEdgeCollisionShape( -3/2, -%h/2, 3/2, -%h/2 ); */
     myModule.cfloor[myModule.cfloor].createPolygonBoxCollisionShape();
    myScene.add( myModule.cfloor[myModule.cfloor]);  

    	myModule.nfloor++;
    	}

}
