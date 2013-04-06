

function addNormalFloor(%x,%y,%w,%h){
		
	myModule.floor[myModule.nfloor]=new Sprite();
	myModule.floor[myModule.nfloor].setBodyType( static );


    myModule.floor[myModule.nfloor].Position = %x SPC %y;

    
    myModule.floor[myModule.nfloor].Size = %w SPC %h;
   myModule.floor[myModule.nfloor].Friction=0;
  myModule.floor[myModule.nfloor].SceneLayer = 5;
  myModule.floor[myModule.nfloor].SceneGroup = $NORMAL_TILE ;
   
   myModule.floor[myModule.nfloor].Image = "myModule:Tile";
    myModule.floor[myModule.nfloor].UseBackgroundColor = true;
    myModule.floor[myModule.nfloor].createEdgeCollisionShape( -%w/2, -%h/2, -%w/2, %h/2 );
   myModule.floor[myModule.nfloor].createEdgeCollisionShape( %w/2, -%h/2, %w/2, %h/2);
   myModule.floor[myModule.nfloor].createEdgeCollisionShape( -%w/2, %h/2, %w/2, %h/2 );
    myModule.floor[myModule.nfloor].createEdgeCollisionShape( -%w/2, -%h/2, %w/2, -%h/2 );   
    myScene.add( myModule.floor[myModule.nfloor]);  

    myModule.nfloor++;

}
