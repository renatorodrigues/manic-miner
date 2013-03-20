function createGuy()
{
	
	
 // Create the sprite.
    %guy = new Sprite(Guy);
    
    // We want our spaceship to move and be affected by gravity and various forces
    // so we set its BodyType to dynamic
    %guy.setBodyType( dynamic );
       
    // Set the position.
    %guy.Position = "0 30";

    // Set the size.        
    %guy.Size = "4 4";
    
    // Set the layer closest to the camera (above the background)
    %guy.SceneLayer = 1;
    
    //%image=new ImageAsset();
    //%image.setFilterMode("Nearest");
    //%image.setImageFile("myModule:fatguy");
    
    
    
    
    // Set the scroller to use an animation!
    %guy.Animation = "myModule:FatGuyAnim";
    
   // %guy.Image = "myModule:fatguy";
    
  //  %guy.setImageFrame(0);
    
    echo("@@@@@@@ ",%guy.getFilterMode());

    // This creates a box which so that collisions with the screen edges register properly
    // Calling createPolygonBoxCollisionShape() without arguments sets the box to the size of the 
    // sceneobject automatically.
    %guy.createPolygonBoxCollisionShape();

    //%guy.setCollisionLayers(all);
    %guy.setCollisionCallback( true );
     Guy.stopAnimation();
    
   
    // Add the sprite to the scene.
    myScene.add( %guy );  
}



function Guy::onCollision(%this, %sceneobject, %collisiondetails)
{
	if(%sceneobject.getSceneGroup()==1){
		%this.setLinearVelocityX(myModule.actualPlayerSpeed);
		myModule.touchdown=1;
	}
}


