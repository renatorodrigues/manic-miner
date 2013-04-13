//walls collision group = 1

function populateFonts()
{      
      %font = "Arial";      
      %sizes = "18 24 32 36";      
      for (%i = 0; %i < getWordCount(%sizes); %i++)            
            populateFontCacheRange(%font, getWord(%sizes, %i), 32, 126);      
      writeFontCache();
}


function myModule::create( %this )
{
	
	$NORMAL_TILE=1;
	$CLEAR_TILE=2;
	$END_PLACE=3;
	$MOVING_TILE=4;
	$ENEMY=10;
	$ITEM=11;
	$PLAYER=5;
exec("./scripts/scenewindow.cs");
exec("./scripts/scene.cs");
exec("./gui/guiProfiles.cs");
exec("./scripts/fileIO.cs");

exec("./scripts/background.cs");
exec("./scripts/level.cs");
exec("./scripts/guy.cs");
exec("./scripts/badguy.cs");
exec("./scripts/normal_floor.cs");
exec("./scripts/movingFloor.cs");
exec("./scripts/clearing_floor.cs");
exec("./scripts/bush.cs");
exec("./scripts/stalagmites.cs");
exec("./scripts/end.cs");
exec("./scripts/menu.cs");
exec("./scripts/catchable.cs");
//populateFonts();
createSceneWindow();
createScene();
createMenu();
//splash.setVisibility(1);
myModule.main=1;
myModule.colorB=0;
myModule.xScroller=960;
showSplash();
new ActionMap(control);
	control.push();
	control.bind(keyboard, enter, startGame); 
	if (!alxIsPlaying(myModule.SplashM))
      {
         // Play the selected music
         myModule.SplashM = alxPlay("myModule:welcomeSound");
      }
}

function myScene::restartGame(){
	restartGame();
}

function myScene::BlackScreen(){
	Canvas.BackgroundColor="black";
}

function restartGame(){
	
	for(%i=0;%i<myModule.ncfloor;%i++){
			myModule.cfloor[%i].safeDelete();
		}
		
		
	for(%i=0;%i<myModule.nfloor;%i++){
		myModule.floor[%i].safeDelete();
	}
	myScene.clear();
	control.pop();
	alxStopAll();
	//splash.setVisible(true);
	
	showSplash();
	life1.setVisible(true); 
	life2.setVisible(true); 
	life3.setVisible(true); 
	myModule.main=1;
	new ActionMap(control);
	control.push();
	control.bind(keyboard, enter, startGame); 
	if (!alxIsPlaying(myModule.SplashM))
      {
         // Play the selected music
         myModule.SplashM = alxPlay("myModule:welcomeSound");
      }
}

function startGame(){
	if(myModule.main==0){
		return;
	}
	alxStop(myModule.SplashM);
	if (!alxIsPlaying(myModule.Handle))
      {
         // Play the selected music
         myModule.Handle = alxPlay("myModule:backgroundSound");
      }
      	//canvasSplash.setVisible(false); 
	//splash.setVisible(false); 
	//Canvas.popDialog(splashui);
	showIngame();
	myModule.main=0;
	myModule.badguy=0;
	myModule.nfloor=0;
	myModule.ncfloor=0;
	myModule.deleteBlocks=0;
	myModule.playerSpeed=14;
	myModule.playerVSpeed=50;
	myModule.gravity=0;
	myModule.actualPlayerSpeed=0;
	myModule.leftKey=0;
	myModule.rightKey=0;
	myModule.touchdown=0;
	myModule.tick=0;
	myModule.itemCount=0;
	myModule.indie=0;
	mySceneWindow.setScene(myScene);
	//myScene.setDebugOn( "collision" );
	//myScene.setDebugOn( "fps" );
	createBackground();
	createLevel();
	/*
	addNormalFloor(0,-15,25,2);
	addNormalFloor(15,-5.5,10,2);
	addNormalFloor(13,0,70,2);
	addMovingFloor(-10,10,10,2,7,1);
	addNormalFloor(-13,36.5,70,2);
	addCatchable(10,23);
	
	addCatchable(-5,70);
	addBush(25,2);
	addStalagmite(-5,34.5);
	addEnd(45,-19.5);
	addClearingFloor(0,10,20,2);
	*/
	//spawnBadGuy(-10,-5);
	
	//spawnBadGuy(-15,-5);
	
	//spawnGravityBadGuy(-20,-10);
	
	Guy.setLinearVelocityY(-myModule.playerVSpeed);
	
	filewrite();
	
	
	
	control.bind(keyboard, "g", toggleG); 
	control.bind(keyboard, space, toggleG); 
	control.bind(keyboard, up, toggleUp); 
	control.bind(keyboard, down, toggleDown); 
	control.bind(keyboard, right, playerRight); 
	control.bind(keyboard, left, playerLeft); 
	
	control.bind(keyboard, "w", toggleUp); 
	control.bind(keyboard, "s", toggleDown); 
	control.bind(keyboard, "d", playerRight); 
	control.bind(keyboard, "a", playerLeft); 
	
	control.bind(keyboard, "m", backgroundMusicOnOff); 
}

function backgroundMusicOnOff(%val){
	
	if(%val){
		if (!alxIsPlaying(myModule.Handle))
	      {
		 // Play the selected music
		 myModule.Handle = alxPlay("myModule:backgroundSound");
	      }else{
		 alxStop(myModule.Handle);     
		}
      	}
}


function playerRight(%val){
	
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


function toggleUp(%val){
	if( myModule.gravity==0){
		toggleG(%val);
	}
}

function toggleDown(%val){
	if( myModule.gravity!=0){
		toggleG(%val);
	}

}

function toggleG(%val)
{
	//Guy.onUpdate();
   if(%val)
   {
      //echo("g key down");
   
      //echo("g key up");
      if(myModule.touchdown==1){
      	      if (!alxIsPlaying(Guy.jumpsound) && myModule.indie==0)
		{
			// Play the selected music
			echo("start1");
         	Guy.jumpsound = alxPlay("myModule:jumpSound");
         	}
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

