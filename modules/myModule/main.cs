//walls collision group = 1

function myModule::create( %this )
{
exec("./scripts/scenewindow.cs");
exec("./scripts/scene.cs");
exec("./gui/guiProfiles.cs");

exec("./scripts/background.cs");
exec("./scripts/guy.cs");

createSceneWindow();
createScene();

mySceneWindow.setScene(myScene);
myScene.setDebugOn( "collision" );
myScene.setDebugOn( "fps" );
createBackground();
createGuy();

myModule.playerSpeed=7;
myModule.playerVSpeed=40;
Guy.setLinearVelocityY(-myModule.playerVSpeed);
myModule.gravity=0;
myModule.actualPlayerSpeed=0;
myModule.leftKey=0;
myModule.rightKey=0;
myModule.tochdown=0;


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
	if(%val)
   {
   	   
   	   myModule.rightKey=1;
      
   	   if(myModule.leftKey==1){
   	   	 Guy.setLinearVelocityX(0); 
   	   	
   	   	 Guy.stopAnimation();
   	   }else{
		Guy.setLinearVelocityX(myModule.playerSpeed);
		   myModule.actualPlayerSpeed=myModule.playerSpeed;
		     Guy.playAnimation("myModule:FatGuyAnim");
	   }
	} else
   {
   	   myModule.rightKey=0;
   	   if(myModule.leftKey==1){
   	   	 Guy.setLinearVelocityX(-myModule.playerSpeed);  
   	   	   Guy.playAnimation("myModule:FatGuyAnim_Inv");
   	   }else{
		   if(myModule.actualPlayerSpeed>0){
			   Guy.setLinearVelocityX(0);
			   
			    Guy.stopAnimation();
		   }
   	   }
   }
}

function playerLeft(%val){
	if(%val)
   {
      
   	   myModule.leftKey=1;
   	   
   	    if(myModule.rightKey==1){
   	   	 Guy.setLinearVelocityX(0);  
   	   	 myModule.actualPlayerSpeed=0;
   	   	 Guy.stopAnimation();
   	   }else{
		Guy.setLinearVelocityX(-myModule.playerSpeed);
		myModule.actualPlayerSpeed=-myModule.playerSpeed;
		 Guy.playAnimation("myModule:FatGuyAnim_Inv");
		
	   }
	} else
   {
   	   myModule.leftKey=0;
   	   
   	   if(myModule.rightKey==1){
   	   	 Guy.setLinearVelocityX(myModule.playerSpeed);  
   	   	 Guy.playAnimation("myModule:FatGuyAnim");
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
   if(%val)
   {
      //echo("g key down");
   } else
   {
      //echo("g key up");
      if(myModule.gravity==0){
      	      //myScene.Gravity= "0, 9.8";
      	      Guy.setLinearVelocityY(myModule.playerVSpeed);
      	      myModule.gravity=1;
      	      Guy.setAngle(180);
      	      
      }else{
      	       //myScene.Gravity="0, -9.8";
      	       Guy.setLinearVelocityY(-myModule.playerVSpeed);
      	       myModule.gravity=0;
      	       Guy.setAngle(0);
      	       
      }
   }
}



function myModule::destroy( %this )
{
destroySceneWindow();
}

