//walls collision group = 1

function myModule::create( %this )
{
exec("./scripts/scenewindow.cs");
exec("./scripts/scene.cs");
exec("./gui/guiProfiles.cs");
exec("./scripts/fileIO.cs");

exec("./scripts/background.cs");
exec("./scripts/guy.cs");
exec("./scripts/normal_floor.cs");
exec("./scripts/clearing_floor.cs");

createSceneWindow();
createScene();
myModule.nfloor=0;
myModule.cfloor=0;
myModule.deleteBlocks=0;
mySceneWindow.setScene(myScene);
myScene.setDebugOn( "collision" );
myScene.setDebugOn( "fps" );
createBackground();

 addNormalFloor(0,-15,25,2);
  addNormalFloor(15,-5.5,10,2);
   addNormalFloor(25,0,100,2);
    //addNormalFloor(0,-25,100,2);
    
    addClearingFloor(0,10,20,2);
createGuy();


myModule.playerSpeed=14;
myModule.playerVSpeed=50;
Guy.setLinearVelocityY(-myModule.playerVSpeed);
myModule.gravity=0;
myModule.actualPlayerSpeed=0;
myModule.leftKey=0;
myModule.rightKey=0;
myModule.touchdown=0;
myModule.tick=0;
filewrite();

new ActionMap(actionMap);
actionMap.push();

   // activateDirectInput();
actionMap.bind(keyboard, "g", toggleG); 
actionMap.bind(keyboard, space, toggleG); 
actionMap.bind(keyboard, up, toggleG); 
actionMap.bind(keyboard, down, toggleG); 
actionMap.bind(keyboard, right, playerRight); 
actionMap.bind(keyboard, left, playerLeft); 
}

function playerRight(%val){
	Guy.onUpdate();
	if(%val)
   {
   	   
   	   myModule.rightKey=1;
      
   	   if(myModule.leftKey==1){
   	   	 Guy.setLinearVelocityX(0); 
   	   	  myModule.actualPlayerSpeed=0;
   	   	//myModule.playerSpeed=0;
   	   	 Guy.stopAnimation();
   	   }else{
		Guy.setLinearVelocityX(myModule.playerSpeed);
		//Guy.applyForce("20,0", Guy.getWorldCenter());
		myModule.actualPlayerSpeed=myModule.playerSpeed;
		
		if(mRound(Guy.getAngle())!=180){
   	   	 	 Guy.playAnimation("myModule:FatGuyAnim");
   	   	 }else{
   	   	 	 Guy.playAnimation("myModule:FatGuyAnim_Inv");
   	   	 }
	   }
	} else
   {
   	   myModule.rightKey=0;
   	   if(myModule.leftKey==1){
   	   	 Guy.setLinearVelocityX(-myModule.playerSpeed); 
   	   	//Guy.applyForce("-20,0", Guy.getWorldCenter());
   	   	  myModule.actualPlayerSpeed=-myModule.playerSpeed;
   	   	  if(mRound(Guy.getAngle())!=180){ 
			Guy.playAnimation("myModule:FatGuyAnim_Inv");
		}else{
			Guy.playAnimation("myModule:FatGuyAnim");
		}
		
   	   }else{
		   if(myModule.actualPlayerSpeed>0){
			   Guy.setLinearVelocityX(0);
			    myModule.actualPlayerSpeed=0;
			    Guy.stopAnimation();
		   }
   	   }
   }
}

function playerLeft(%val){
	Guy.onUpdate();
	if(%val)
	{
      
   	   myModule.leftKey=1;
   	   
   	    if(myModule.rightKey==1){
   	   	 Guy.setLinearVelocityX(0);  
   	   	 myModule.actualPlayerSpeed=0;
   	   	 Guy.stopAnimation();
   	   }else{
		Guy.setLinearVelocityX(-myModule.playerSpeed);
		//Guy.applyForce("-20", Guy.getWorldCenter());
		myModule.actualPlayerSpeed=-myModule.playerSpeed;
		if(mRound(Guy.getAngle())!=180){ 
			Guy.playAnimation("myModule:FatGuyAnim_Inv");
		}else{
			Guy.playAnimation("myModule:FatGuyAnim");
		}
		
	   }
	} else
   {
   	   myModule.leftKey=0;
   	   
   	   if(myModule.rightKey==1){
   	   	 Guy.setLinearVelocityX(myModule.playerSpeed);
   	   	// Guy.applyForce("20,0", Guy.getWorldCenter());
   	   	 if(mRound(Guy.getAngle())!=180){
   	   	 	 Guy.playAnimation("myModule:FatGuyAnim");
   	   	 }else{
   	   	 	 Guy.playAnimation("myModule:FatGuyAnim_Inv");
   	   	 }
   	   	 myModule.actualPlayerSpeed=myModule.playerSpeed;
   	   	 
   	   }else{
		    if(myModule.actualPlayerSpeed<0){
			   Guy.setLinearVelocityX(0); 
			   myModule.actualPlayerSpeed=0;
			   Guy.stopAnimation();
		   }
   	   }
   	
   }
}


function toggleG(%val)
{
	//Guy.onUpdate();
   if(%val)
   {
      //echo("g key down");
   } else
   {
      //echo("g key up");
      if(myModule.touchdown==1){
      	      myScene.Gravity="0, 0";
	      if(myModule.gravity==0){
		      //myScene.Gravity= "0, 9.8";
		      Guy.setLinearVelocityY(myModule.playerVSpeed);
		      myModule.gravity=1;
		      Guy.setAngle(180);
		      myModule.touchdown=0;
		      
		      
	      }else{
		       //myScene.Gravity="0, -9.8";
		       Guy.setLinearVelocityY(-myModule.playerVSpeed);
		       myModule.gravity=0;
		       Guy.setAngle(0);
		       myModule.touchdown=0;
		       
	      }
	      echo(Guy.getAnimation());
	      		if(Guy.getAnimation()$="myModule:FatGuyAnim_Inv"){
	      	      	echo("toanim");
		      	      Guy.playAnimation("myModule:FatGuyAnim");
		      }else{
		      	      echo("toinv");
		      	      Guy.playAnimation("myModule:FatGuyAnim_Inv");
		      }
		       if(myModule.actualPlayerSpeed<0.1 && myModule.actualPlayerSpeed>-0.1){
		        Guy.stopAnimation();
		       	       
		       }
      }
   }
}



function myModule::destroy( %this )
{
destroySceneWindow();
}

