function createGuy(%x,%y)
{
	
	
 // Create the sprite.
    %guy = new Sprite(Guy);
    
    // We want our spaceship to move and be affected by gravity and various forces
    // so we set its BodyType to dynamic
    %guy.setBodyType( dynamic );
       
    // Set the position.
    %guy.Position = %x SPC %y;
    %guy.SpawnPos=%x SPC %y;
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
    
    //echo("@@@@@@@ ",%guy.getFilterMode());

    // This creates a box which so that collisions with the screen edges register properly
    // Calling createPolygonBoxCollisionShape() without arguments sets the box to the size of the 
    // sceneobject automatically.
    %guy.createPolygonBoxCollisionShape(4,3,0,-0.5);

  
    
   
    
    //%guy.setCollisionLayers(all);
    %guy.setCollisionCallback( true );
     Guy.stopAnimation();
     %guy.setUpdateCallback(true);
     //%guy.setGatherContacts (true);
    //Guy.schedule(32, Guy,"onUpdate", Guy);
   
    // Add the sprite to the scene
    echo(%guy);
    myScene.add( %guy );  
    
    
}

function Guy::onUpdate(%this)
{	//echo("update");
	//echo(%this.getContactCount ());
  // %this.updateHorizontal();
   %this.updateVertical();
   //%this.setCurrentAnimation();
}

function Guy::updateVertical(%this)
{
	
	myModule.tick++;
	

	
	if(myModule.gravity==0){
		%ny=getWord(%this.getRenderPosition(),1)-2.1;
	}else{
		%ny=getWord(%this.getRenderPosition(),1)+2.1;
	}
	%down=0;
	%obj[0]=myScene.pickRayCollision(%this.getRenderPosition(),getWord(%this.getRenderPosition(),0) SPC %ny);
	%obj[1]=myScene.pickRayCollision(%this.getRenderPosition(),getWord(%this.getRenderPosition(),0)-2 SPC %ny);
	%obj[2]=myScene.pickRayCollision(%this.getRenderPosition(),getWord(%this.getRenderPosition(),0)+2 SPC %ny);
	
	
				
		for(%i=0;%i<3;%i++){
			%sceneobject=getWord(%obj[%i],0);
			if(%sceneobject$=""){
		
			}else{
			%down++;
				
			if(myModule.tick>15){	
				
				if(%sceneobject.getSceneGroup()==2){
					%sceneobject.setHeight(%sceneobject.getHeight()-0.5);
					//echo(%sceneobject.getHeight());
					//%sceneobject.clearCollisionShapes();
					//%sceneobject.createPolygonBoxCollisionShape();
					if(%sceneobject.getHeight()<0.2){
						//%sceneobject.safeDelete();
						%sceneobject.setHeight(0);
						%sceneobject.setActive( false );
						//myModule.deleteBlocks++;
				}
			}
			}
			}
		}
		
		if(myModule.tick>15){	
	myModule.tick=0;	
	}
	if(%down==0){
	//echo("air");
	
	if(myModule.gravity!=0){
		      //myScene.Gravity= "0, 9.8";
		      Guy.setLinearVelocityY(myModule.playerVSpeed);
		      %this.setLinearVelocityX(myModule.actualPlayerSpeed);
		      myModule.touchdown=0;
		      
		      
	      }else{
		       //myScene.Gravity="0, -9.8";
		       Guy.setLinearVelocityY(-myModule.playerVSpeed);
		    %this.setLinearVelocityX(myModule.actualPlayerSpeed);
		       myModule.touchdown=0;
		       
	      }
}else{
	//echo("touch");
	%this.setLinearVelocityX(myModule.actualPlayerSpeed);
	myModule.touchdown=1;
	 
}
		

}




function Guy::onCollision(%this, %sceneobject, %collisiondetails)
{
	
	if(%sceneobject.getSceneGroup()==1){
		echo("1");
		%this.setLinearVelocityX(myModule.actualPlayerSpeed);
		myModule.touchdown=1;
		
		
	}
	
	if(%sceneobject.getSceneGroup()==2){
		echo("2");
		%this.setLinearVelocityX(myModule.actualPlayerSpeed);
		myModule.touchdown=1;
		%sceneobject.setHeight(%sceneobject.getHeight()-0.5);
		echo(%sceneobject.getHeight());
		//%sceneobject.clearCollisionShapes();
		//%sceneobject.createPolygonBoxCollisionShape();
		if(%sceneobject.getHeight()<0.2){
			//%sceneobject.safeDelete();
			
			%sceneobject.setActive( false );
			myModule.deleteBlocks++;
		}
	}
	if(%sceneobject.getSceneGroup()==10){
		echo("dead");
		%this.Position=%this.SpawnPos;
		myModule.gravity=0;
	}
}


