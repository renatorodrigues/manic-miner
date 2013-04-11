function addClearingFloor(%x, %y, %w, %h) {
  %cw = 2;
  for(%i = %x-(%w/2); %i < %x+(%w/2); %i = %i + 2){
    //echo(%i);

    myModule.cfloor[myModule.ncfloor] = new Sprite(ClearingFloor);
    myModule.cfloor[myModule.ncfloor].a = "ack";
    myModule.cfloor[myModule.ncfloor].setBodyType(static);


    myModule.cfloor[myModule.ncfloor].Position = %i + 1 SPC %y;

    myModule.cfloor[myModule.ncfloor].Size = %cw SPC %h;
    myModule.cfloor[myModule.ncfloor].initH=%h;
    myModule.cfloor[myModule.ncfloor].Friction = 0;
    myModule.cfloor[myModule.ncfloor].SceneLayer = 5;
    myModule.cfloor[myModule.ncfloor].SceneGroup = $CLEAR_TILE ;

    myModule.cfloor[myModule.ncfloor].Image = "myModule:clearFloor";
    myModule.cfloor[myModule.ncfloor].UseBackgroundColor = true;
    //myModule.cfloor[myModule.ncfloor].setRepeatX(%w/2);
    /*
    myModule.cfloor[myModule.cfloor].createEdgeCollisionShape( -%cw/2, -%h/2, -%cw/2, %h/2 );
    myModule.cfloor[myModule.cfloor].createEdgeCollisionShape( %cw/2, -%h/2, %cw/2, %h/2);
    myModule.cfloor[myModule.cfloor].createEdgeCollisionShape( -%cw/2, %h/2, %cw/2, %h/2 );
    myModule.cfloor[myModule.cfloor].createEdgeCollisionShape( -%cw/2, -%h/2, %cw/2, -%h/2 ); 
    */
    myModule.cfloor[myModule.ncfloor].createPolygonBoxCollisionShape();
    myScene.add( myModule.cfloor[myModule.ncfloor]);  

    myModule.ncfloor++;
  }
}

function ClearingFloor::reset(%this){
	%this.setHeight(%this.initH);
	%sceneobject.setActive( true );
}

