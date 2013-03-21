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
    %guy.Friction="0.0";
    %guy.FixedAngle = true;
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
     %guy.setUpdateCallback(true);
     %guy.setGatherContacts (true);
    //Guy.schedule(32, Guy,"onUpdate", Guy);
   
    // Add the sprite to the scene
    
    myScene.add( %guy );  
    
    
}

function Guy::onUpdate(%this)
{
	//echo(%this.getContactCount ());
  // %this.updateHorizontal();
   %this.updateVertical();
   //%this.setCurrentAnimation();
}

function Guy::updateVertical(%this)
{
	
if(%this.getContactCount ()<1){
	 if(myModule.gravity!=0){
		      //myScene.Gravity= "0, 9.8";
		      Guy.setLinearVelocityY(myModule.playerVSpeed);
		      
		      myModule.touchdown=0;
		      
		      
	      }else{
		       //myScene.Gravity="0, -9.8";
		       Guy.setLinearVelocityY(-myModule.playerVSpeed);
		    
		       myModule.touchdown=0;
		       
	      }
}
   /*%yVelocity = %this.getLinearVelocityY();
   
   %this.setLinearVelocityY(5);
   %collision = %this.castCollision(0.005);
   
   %normalX = getWord(%collision, 4);
   %normalY = getWord(%collision, 5);
   
   // no collision
   if (%collision $= "")
   {
   	   
   	   echo("no");
      %this.airborne = true;
      %this.setConstantForceY(100);
      %this.setLinearVelocityY(%yVelocity);
      return;
   }
   
   // collides with wall to the left
   if (%normalX == 1 && %normalY == 0)
   {
      %this.againstLeftWall = true;
      %this.setLinearVelocityX(0);
      %this.setLinearVelocityY(%yVelocity);
      return;
   }
   
   // collides with wall to the right
   if (%normalX == -1 && %normalY == 0)
   {
      %this.againstRightWall = true;
      %this.setLinearVelocityX(0);
      %this.setLinearVelocityY(%yVelocity);
      return;
   }
   
   // on ground with no wall collisions
   if (%normalX == 0 && %normalY == -1)
   {
      %this.airborne = false;
      %this.againstLeftWall = false;
      %this.againstRightWall = false;
      %this.setConstantForceY(0);
      %this.setLinearVelocityY(%yVelocity);
      return;
   }
   
   // in air and hits platform with head
   if (%normalY == 1)
   {
      %this.airborne = true;
      %this.setLinearVelocityX(0);
      %this.setConstantForceY(100);
      %this.setLinearVelocityY(%yVelocity);
      return;
   }
   
   // in case another type of collision normal was detected
   error("another collison type" SPC %normalX SPC %normalY);
   %this.airborne = false;
   %this.againstLeftWall = false;
   %this.againstRightWall = false;
   %this.setLinearVelocityY(%yVelocity);*/
}




function Guy::onCollision(%this, %sceneobject, %collisiondetails)
{
	
	echo(%collisiondetails);
	if(%sceneobject.getSceneGroup()==1){
		%this.setLinearVelocityX(myModule.actualPlayerSpeed);
		myModule.touchdown=1;
		if(myModule.gravity==0){
		
		//	myScene.Gravity="0, -9.8";
		}else{
		//	myScene.Gravity= "0, 9.8";
		}
	}
}


