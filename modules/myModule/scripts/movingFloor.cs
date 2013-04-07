function addMovingFloor(%x,%y,%w,%h,%speed,%direction){
		
  %floor=new Scroller(MovingFloor);//new Sprite(MovingFloor);
  %floor.setBodyType( static );

  %floor.Position = %x SPC %y;

  %floor.Speed=%speed*%direction;  
  %floor.Size = %w SPC %h;
  %floor.Friction=0;
  %floor.SceneLayer = 5;
  %floor.SceneGroup = $MOVING_TILE ;

  //%floor.Image = "myModule:movingFloor";
  
  %floor.setRepeatX(%w/2);
  if(%direction>0){
    %floor.Animation = "myModule:movingFloorAnim";
  }else{
    %floor.Animation = "myModule:movingFloorInvAnim";
  }

  %floor.UseBackgroundColor = true;
  %floor.createEdgeCollisionShape( -%w/2, -%h/2, -%w/2, %h/2 );
  %floor.createEdgeCollisionShape( %w/2, -%h/2, %w/2, %h/2);
  %floor.createEdgeCollisionShape( -%w/2, %h/2, %w/2, %h/2 );
  %floor.createEdgeCollisionShape( -%w/2, -%h/2, %w/2, -%h/2 );   
  myScene.add( %floor);  
}
