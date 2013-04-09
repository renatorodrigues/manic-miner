function addClearingFloor(%x, %y, %w, %h) {
  %cw = 2;
  for(%i = %x-(%w/2); %i < %x+(%w/2); %i = %i + 2){
    //echo(%i);

    myModule.cfloor[myModule.cfloor] = new Sprite();
    myModule.cfloor[myModule.cfloor].a = "ack";
    myModule.cfloor[myModule.cfloor].setBodyType(static);


    myModule.cfloor[myModule.cfloor].Position = %i + 1 SPC %y;

    myModule.cfloor[myModule.cfloor].Size = %cw SPC %h;
    myModule.cfloor[myModule.cfloor].Friction = 0;
    myModule.cfloor[myModule.cfloor].SceneLayer = 5;
    myModule.cfloor[myModule.cfloor].SceneGroup = $CLEAR_TILE ;

    myModule.cfloor[myModule.cfloor].Image = "myModule:clearFloor";
    myModule.cfloor[myModule.cfloor].UseBackgroundColor = true;
    myModule.floor[myModule.cfloor].setRepeatX(%w/2);
    /*
    myModule.cfloor[myModule.cfloor].createEdgeCollisionShape( -%cw/2, -%h/2, -%cw/2, %h/2 );
    myModule.cfloor[myModule.cfloor].createEdgeCollisionShape( %cw/2, -%h/2, %cw/2, %h/2);
    myModule.cfloor[myModule.cfloor].createEdgeCollisionShape( -%cw/2, %h/2, %cw/2, %h/2 );
    myModule.cfloor[myModule.cfloor].createEdgeCollisionShape( -%cw/2, -%h/2, %cw/2, -%h/2 ); 
    */
    myModule.cfloor[myModule.cfloor].createPolygonBoxCollisionShape();
    myScene.add( myModule.cfloor[myModule.cfloor]);  

    myModule.nfloor++;
  }
}
