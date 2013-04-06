function addEnd(%x,%y){
		
	%end=new Sprite();
	%end.setBodyType( static );


    %end.Position = %x SPC %y;
    %w=6;
    %h=6;
    
    %end.Size = %w SPC %h;
   %end.Friction=0;
  %end.SceneLayer = 5;
  %end.SceneGroup = 3 ;
   
   //%end.Image = "myModule:Tile"; //missing image
    %end.UseBackgroundColor = true;
    %end.createEdgeCollisionShape( -%w/2, -%h/2, -%w/2, %h/2 );
   %end.createEdgeCollisionShape( %w/2, -%h/2, %w/2, %h/2);
   %end.createEdgeCollisionShape( -%w/2, %h/2, %w/2, %h/2 );
    %end.createEdgeCollisionShape( -%w/2, -%h/2, %w/2, -%h/2 );   
    myScene.add( %end);  

    

}
