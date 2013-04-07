
function addBush(%x,%y){
		
	%bush=new Sprite();
	%bush.setBodyType( static );


    %bush.Position = %x SPC %y;
    %w=2;
    %h=2;
    
    %bush.Size = "2 2";
   %bush.Friction=0;
  %bush.SceneLayer = 5;
  %bush.SceneGroup = $ENEMY ;
   
   %bush.Image = "myModule:bush"; //missing image
    %bush.UseBackgroundColor = true;
    %bush.createEdgeCollisionShape( -%w/2, -%h/2, 0, %h/2 );
   %bush.createEdgeCollisionShape( %w/2, -%h/2, 0, %h/2);
  // %bush.createEdgeCollisionShape( -%w/2, %h/2, %w/2, %h/2 );
    %bush.createEdgeCollisionShape( -%w/2, -%h/2, %w/2, -%h/2 );   
    myScene.add( %bush);  

    

}
