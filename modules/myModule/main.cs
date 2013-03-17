//-----------------------------------------------------------------------------
// Copyright (c) 2013 GarageGames, LLC
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
//-----------------------------------------------------------------------------

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
myModule.playerVSpeed=20;
Guy.setLinearVelocityY(-myModule.playerVSpeed);
myModule.gravity=0;
new ActionMap(actionMap);
actionMap.push();

   // activateDirectInput();
actionMap.bind(keyboard, "g", toggleG); 
actionMap.bind(keyboard, space, toggleG); 
actionMap.bind(keyboard, right, playerRight); 
actionMap.bind(keyboard, left, playerLeft); 
}

function playerRight(%val){
	if(%val)
   {
      
   
	Guy.setLinearVelocityX(myModule.playerSpeed);
	} else
   {
   	Guy.setLinearVelocityX(0);   
   }
}

function playerLeft(%val){
	if(%val)
   {
      
   
	Guy.setLinearVelocityX(-myModule.playerSpeed);
	} else
   {
   	Guy.setLinearVelocityX(0); 
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
      	      
      }else{
      	       //myScene.Gravity="0, -9.8";
      	       Guy.setLinearVelocityY(-myModule.playerVSpeed);
      	       myModule.gravity=0;
      	       
      }
   }
}



function myModule::destroy( %this )
{
destroySceneWindow();
}

