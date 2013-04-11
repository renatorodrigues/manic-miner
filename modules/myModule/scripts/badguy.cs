function spawnBadGuy(%x,%y)
{
	
	
 // Create the sprite.
    %guy = new Sprite(BadGuy);
    %guy.SceneGroup = $ENEMY ;
    // We want our spaceship to move and be affected by gravity and various forces
    // so we set its BodyType to dynamic
    %guy.setBodyType( dynamic );
    %guy.N=myModule.badguy;
     %guy.touchdown=0;
      %guy.tick=0;
      %guy.notfall=1;
    myModule.badguy++;
    // Set the position.
    %guy.Position = %x SPC %y;

    // Set the size.        
    %guy.Size = "3 4";
    %guy.dirChange=0;
    // Set the layer closest to the camera (above the background)
    %guy.SceneLayer = 1;
    %guy.Friction="0.0";
    %guy.FixedAngle = true;
    //%image=new ImageAsset();
    //%image.setFilterMode("Nearest");
    //%image.setImageFile("myModule:fatguy");
    %guy.gravity=0;
    %guy.actualSpeed=13;
    %guy.setLinearVelocityX(%guy.actualSpeed);
    
    // Set the scroller to use an animation!
    
    %guy.Animation = "myModule:BadGuyAnim";
    
   // %guy.Image = "myModule:fatguy";
    
  //  %guy.setImageFrame(0);
    
   // echo("@@@@@@@ ",%guy.getFilterMode());

    // This creates a box which so that collisions with the screen edges register properly
    // Calling createPolygonBoxCollisionShape() without arguments sets the box to the size of the 
    // sceneobject automatically.
    %guy.createPolygonBoxCollisionShape(3,3,0,-0.5);

  
    
   
    
    //%guy.setCollisionLayers(all);
    %guy.setCollisionCallback( true );
     Guy.stopAnimation();
     %guy.setUpdateCallback(true);
     //%guy.setGatherContacts (true);
    //Guy.schedule(32, Guy,"onUpdate", Guy);
   
    // Add the sprite to the scene
    %guy.setLinearVelocityY(-myModule.playerVSpeed);
    //echo(%guy);
    myScene.add( %guy );  
    %guy.followG=false;
    return %guy;
     %guy.Animation = "myModule:ObeseGuyAnim";
    
}

function spawnGravityBadGuy(%x,%y){
	%guy=spawnBadGuy(%x,%y);
	%guy.followG=true;
	%guy.Size = "5 5";
	%guy.clearCollisionShapes();
	%guy.createPolygonBoxCollisionShape(5,4,0,-0.5);
	
}

function  BadGuy::onUpdate(%this)
{	//echo("update");
	//echo(%this.getContactCount ());
  // %this.updateHorizontal();
   %this.updateVertical();
   //%this.setCurrentAnimation();
  // echo("BadGuy "@%this.N);
}

function BadGuy::updateVertical(%this)
{
	
	%this.tick++;
	if(%this.getLinearVelocityX()<0.2 &&%this.getLinearVelocityX()>- 0.2){
		%this.setLinearVelocityX(%this.actualSpeed);
		      	     
	}
	
	if(%this.followG==true){
		if(myModule.gravity!=%this.gravity){
			%this.gravity=myModule.gravity;
			if(%this.gravity==0){
				%this.setAngle(0);
			}else{
				%this.setAngle(180);
			}
			
			if(%this.getAnimation()$="myModule:BadGuyAnim_Inv" || %this.getAnimation()$="myModule:ObeseGuyAnim_Inv" ){
	      	      	
		      	      if(%this.followG){
		      	      	      %this.playAnimation("myModule:ObeseGuyAnim");
		      	      }else{
				%this.playAnimation("myModule:BadGuyAnim");
			      }
		      }else{
		      	      if(%this.followG){
		      	      	      %this.playAnimation("myModule:ObeseGuyAnim_Inv");
		      	      }else{		      	      
		      	      	      %this.playAnimation("myModule:BadGuyAnim_Inv");
		      	      }
		      }
		
		}
	}
	
	if(%this.gravity==0){
		%ny=getWord(%this.getRenderPosition(),1)-2.1;
		%m=2;
		if(%this.followG){
			%ny=getWord(%this.getRenderPosition(),1)-2.6;
			%m=2.1;
		}
	}else{
		%ny=getWord(%this.getRenderPosition(),1)+2.1;
		%m=-2;
		if(%this.followG){
			%ny=getWord(%this.getRenderPosition(),1)+2.6;
			%m=-2.1;
		}
		
	}
	if(%this.actualSpeed>0){
		
		%nx=getWord(%this.getRenderPosition(),0)+2.1;
		if(%this.followG){
			%nx=getWord(%this.getRenderPosition(),0)+3;
		}
	}else{
		%nx=getWord(%this.getRenderPosition(),0)-2.1;
		if(%this.followG){
			%nx=getWord(%this.getRenderPosition(),0)-3;
		}
	}
	%down=0;
	%front=myScene.pickRayCollision(%this.getRenderPosition(),%nx SPC getWord(%this.getRenderPosition(),1));
	%front1=myScene.pickRayCollision(%this.getRenderPosition(),%nx SPC getWord(%this.getRenderPosition(),1)-%m);
	%front2=myScene.pickRayCollision(%this.getRenderPosition(),%nx SPC getWord(%this.getRenderPosition(),1)+%m-1);
	%obj[0]=myScene.pickRayCollision(%this.getRenderPosition(),getWord(%this.getRenderPosition(),0) SPC %ny);
	%obj[1]=myScene.pickRayCollision(%this.getRenderPosition(),getWord(%this.getRenderPosition(),0)-2 SPC %ny);
	%obj[2]=myScene.pickRayCollision(%this.getRenderPosition(),getWord(%this.getRenderPosition(),0)+2 SPC %ny);
	
	
				
		for(%i=0;%i<3;%i++){
			%sceneobject=getWord(%obj[%i],0);
			if(%sceneobject$=""){
		
			}else{
			%down++;
				
			if(%this.tick>15){	
				
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
		
		if(%this.tick>15){	
	%this.tick=0;	
	}
	if((%down<3 &&  %down>0 &&%this.followG==false) || (%down<3 && %down>0&&  %this.followG==true) || %front!$="" || %front1!$="" || %front2!$=""){
		if(%this.followG ){
			echo("@@@@@@@@@@@@@"@%front@" + "@%front1@" + "@%front2@" down - "@%down@" dirChange "@%this.dirChange);
		}
		if((%this.notfall==1 || %front!$="")&&  %this.dirChange==0){
		      	      %this.actualSpeed=-%this.actualSpeed;
		      	      %this.setLinearVelocityX(%this.actualSpeed);
		      	     
		      	     %this.dirChange=1;
		      	       if(%this.actualSpeed>0){
		      	       	       if(%this.gravity==0){
		      	       	       	       if(%this.followG){
		      	       	       	       	       %this.playAnimation("myModule:ObeseGuyAnim");
		      	       	       	       }else{
		      	       	       	       	       %this.playAnimation("myModule:BadGuyAnim");
		      	       	       	       }
		      	       	       }else{
		      	       	       	       if(%this.followG){
		      	       	       	       	       %this.playAnimation("myModule:ObeseGuyAnim_Inv");
		      	      	      	       }else{
		      	      	      	       	       %this.playAnimation("myModule:BadGuyAnim_Inv");
		      	       	       	       }
		      	       	       }
   	   	 	       }else{
   	   	 	       	       if(%this.gravity!=0){
		      	       	       	 if(%this.followG){
		      	       	       	       	       %this.playAnimation("myModule:ObeseGuyAnim");
		      	       	       	       }else{
		      	       	       	       	       %this.playAnimation("myModule:BadGuyAnim");
		      	       	       	       }
		      	       	       }else{
		      	       	       	       if(%this.followG){
		      	       	       	       	       %this.playAnimation("myModule:ObeseGuyAnim_Inv");
		      	      	      	       }else{
		      	      	      	       	       %this.playAnimation("myModule:BadGuyAnim_Inv");
		      	       	       	       }
		      	       	       }
   	   	 	       }
		      }
	}else{
		
		%this.dirChange=0;
	}
	
	if(%down==0){
	//echo("air");
	%this.dirChange=0;
	if((%this.gravity!=0 )){
		      //myScene.Gravity= "0, 9.8";
		       %this.setLinearVelocityY(myModule.playerVSpeed);
			      %this.setLinearVelocityX(%this.actualSpeed);
			      %this.touchdown=0;
		      
		      
	      }else{
		       //myScene.Gravity="0, -9.8";
		       	%this.setLinearVelocityY(-myModule.playerVSpeed);
		       	%this.setLinearVelocityX(%this.actualSpeed);
		       	%this.touchdown=0;
		      
		       
	      }
}else{
	//echo("touch");
	%this.setLinearVelocityX(%this.actualSpeed);
	%this.touchdown=1;
	 
}
		

}

function BadGuy::changeDir(%this){
	
	if(%this.followG ){
			echo("@@@@ change dir");
		}
	//echo("from: "@%this.actualSpeed@" to: "-%this.actualSpeed);
			%this.actualSpeed=-%this.actualSpeed;
		      	      %this.setLinearVelocityX(%this.actualSpeed);
		      	     
		      	     %this.dirChange=1;
		      	     
		      	      if(%this.actualSpeed>0){
		      	       	       if(%this.gravity==0){
		      	       	       	if(%this.followG){
		      	       	       	       	       %this.playAnimation("myModule:ObeseGuyAnim");
		      	       	       	       }else{
		      	       	       	       	       %this.playAnimation("myModule:BadGuyAnim");
		      	       	       	       }
		      	       	       }else{
		      	       	       	       if(%this.followG){
		      	       	       	       	       %this.playAnimation("myModule:ObeseGuyAnim_Inv");
		      	      	      	       }else{
		      	      	      	       	       %this.playAnimation("myModule:BadGuyAnim_Inv");
		      	       	       	       }
		      	       	       }
   	   	 	       }else{
   	   	 	       	       if(%this.gravity!=0){
		      	       	       if(%this.followG){
		      	       	       	       	       %this.playAnimation("myModule:ObeseGuyAnim");
		      	       	       	       }else{
		      	       	       	       	       %this.playAnimation("myModule:BadGuyAnim");
		      	       	       	       }
		      	       	       }else{
		      	       	       	       if(%this.followG){
		      	       	       	       	       %this.playAnimation("myModule:ObeseGuyAnim_Inv");
		      	      	      	       }else{
		      	      	      	       	       %this.playAnimation("myModule:BadGuyAnim_Inv");
		      	       	       	       }
		      	       	       }
   	   	 	       }
}


function BadGuy::onCollision(%this, %sceneobject, %collisiondetails)
{
	
	
	
		
		
	if(%sceneobject.getSceneGroup()==$NORMAL_TILE || %sceneobject.getSceneGroup()==$MOVING_TILE){
		//echo("1  ---- "@%this.actualSpeed@" -- "@%this.N);
		%this.setLinearVelocityX(%this.actualSpeed);
		
		%this.touchdown=1;
		
		
	}
	
	if(%sceneobject.getSceneGroup()==$CLEAR_TILE){
		//echo("2");
		%this.setLinearVelocityX(%this.actualSpeed);
		%this.touchdown=1;
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
}


