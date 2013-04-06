function createSceneWindow()
{   
    // Sanity!
    if ( !isObject(mySceneWindow) )
    {
        // Create the scene window.
        new SceneWindow(mySceneWindow);

       // Set Gui profile. If you omit the following line, the program will still run as it uses                
       // GuiDefaultProfile by default

        mySceneWindow.Profile = GuiDefaultProfile;
       
        // Place the sceneWindow on the Canvas
        Canvas.setContent( mySceneWindow );                     
    }

    //Note that the SceneWindow's camera defaults to the following values, you could omit them entirely and       
    //obtain the same result.

    mySceneWindow.setCameraPosition( 0, 0 );
    mySceneWindow.setCameraSize( 100, 75 );
    mySceneWindow.setCameraZoom( 1 );
    mySceneWindow.setCameraAngle( 0 );
    mySceneWindow.Pos=0;
    
}


function destroySceneWindow()
{
    // Finish if no window available.
    if ( !isObject(mySceneWindow) )
        return;
    
    // Delete the window.
    mySceneWindow.delete();
}