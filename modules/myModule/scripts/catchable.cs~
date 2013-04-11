function addCatchable(%x,%y){
		
  %end=new Sprite();
  %end.setBodyType( static );
  %end.catched=false;

  %end.Position = %x SPC %y;
  %w=2;
  %h=2;

  %end.Size = %w SPC %h;
  %end.Friction=0;
  %end.SceneLayer = 5;
  %end.SceneGroup = $ITEM ;

  %end.Image = "myModule:catchable";
  %end.UseBackgroundColor = true;
  %end.createEdgeCollisionShape( -%w/2, -%h/2, -%w/2, %h/2 );
  %end.createEdgeCollisionShape( %w/2, -%h/2, %w/2, %h/2);
  %end.createEdgeCollisionShape( -%w/2, %h/2, %w/2, %h/2 );
  %end.createEdgeCollisionShape( -%w/2, -%h/2, %w/2, -%h/2 );   
  myScene.add( %end);  
  myModule.itemCount++;
  if(!isObject(Guy)){
   itemCount.setText("0 / "@myModule.itemCount);
  }
  	    else{
  itemCount.setText(Guy.catchedItems@" / "@myModule.itemCount);
  }
}
