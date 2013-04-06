

function addClearingFloor(%x,%y,%w,%h){
	%cw=2;
	for(%i=0;%cw*%i<%w;%i++){
		
	myModule.cfloor[myModule.cfloor]=new Sprite();
	myModule.cfloor[myModule.cfloor].setBodyType( static );

	
    myModule.cfloor[myModule.cfloor].Position = (%i*%cw+%x) SPC %y;

    
    myModule.cfloor[myModule.cfloor].Size = %cw SPC %h;
   myModule.cfloor[myModule.cfloor].Friction=0;
  myModule.cfloor[myModule.cfloor].SceneLayer = 5;
  myModule.cfloor[myModule.cfloor].SceneGroup = 2 ;
   
   myModule.cfloor[myModule.cfloor].Image = "myModule:cTile";
    myModule.cfloor[myModule.cfloor].UseBackgroundColor = true;
    /*myModule.cfloor[myModule.cfloor].createEdgeCollisionShape( -%cw/2, -%h/2, -%cw/2, %h/2 );
   myModule.cfloor[myModule.cfloor].createEdgeCollisionShape( %cw/2, -%h/2, %cw/2, %h/2);
   myModule.cfloor[myModule.cfloor].createEdgeCollisionShape( -%cw/2, %h/2, %cw/2, %h/2 );
    myModule.cfloor[myModule.cfloor].createEdgeCollisionShape( -%cw/2, -%h/2, %cw/2, -%h/2 ); */
     myModule.cfloor[myModule.cfloor].createPolygonBoxCollisionShape();
    myScene.add( myModule.cfloor[myModule.cfloor]);  

    	myModule.nfloor++;
    	}

}
