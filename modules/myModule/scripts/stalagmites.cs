
function addStalagmite(%x, %y){
		
	%stal=new Sprite();
	%stal.setBodyType( static );


    %stal.Position = %x SPC %y;
    %w=2;
    %h=2;
    
    %stal.Size = "2 2";
   %stal.Friction=0;
  %stal.SceneLayer = 5;
  %stal.SceneGroup = $ENEMY ;
   
   %stal.Image = "myModule:ice"; //missing image
    %stal.UseBackgroundColor = true;
    %stal.createEdgeCollisionShape( -%w/2, %h/2, 0, -%h/2 );
   %stal.createEdgeCollisionShape( %w/2, %h/2, 0, -%h/2);
  // %stal.createEdgeCollisionShape( -%w/2, %h/2, %w/2, %h/2 );
    %stal.createEdgeCollisionShape( -%w/2, %h/2, %w/2, %h/2 );   
    myScene.add( %stal);  

    

}
