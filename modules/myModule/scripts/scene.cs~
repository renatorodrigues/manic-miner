function createScene()
{
    // Destroy the scene if it already exists.
    if ( isObject(myScene) )
        destroyScene();
    
    // Create the scene.
    new Scene(myScene);
    myScene.Gravity="0, -9.8";
   
    
}

//-----------------------------------------------------------------------------

function destroyScene()
{
    // Finish if no scene available.
    if ( !isObject(myScene) )
        return;

    // Delete the scene.
    myScene.delete();
}