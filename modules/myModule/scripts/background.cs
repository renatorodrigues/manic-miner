function createBackground()
{
     // Create the sprite.
    %background = new Sprite();
    
    // Set the sprite as "static" so it is not affected by gravity.
    %background.setBodyType( static );

    // Set the object's center to coordinates 0 0 which corresponds to the center of the Scene
    // Remember that our camera is set to point to coordinates 0 0 as well

    %background.Position = "0 0";

    // Set the object's size. Notice that this corresponds to the size of our camera, which was created in
    // scenewindow.cs. The background will thus cover the entirety of our scenewindow.
    %background.Size = "100 62.5";
    %background.Friction=0;
    // Set to the furthest background layer.
    %background.SceneLayer = 31;
    %background.SceneGroup = $NORMAL_TILE ;
    
    // Sets the image to use for our background
    //%background.Image = "ToyAssets:skyBackground";
    %background.BackgroundColor = "Black";
    %background.UseBackgroundColor = true;
    // Create border collisions.
    %background.createEdgeCollisionShape( -50, -25, -50, 112.5 );
    %background.createEdgeCollisionShape( 50, -25, 50, 112.5);
    %background.createEdgeCollisionShape( -50, 112.5, 20, 112.5 );
    %background.createEdgeCollisionShape( -50, -25, 50, -25 );   
   //%background.createEdgeCollisionShape( 20, 37.5, 20, 50);
    //%background.setDefaultRestitution(1);
    // Add the sprite to the scene.
    myScene.add( %background );   

    addNormalFloor(0,-26,100,2); //FIXME y=-26&99 is hardcoded to have bottom floor image 

    addNormalFloor(0,-23.5,96,2);
    addNormalFloor(-49,37.5,2,125);
    addNormalFloor(49,37.5,2,125);
   
    //addNormalFloor(-49,67.75,2,62.5);
    //addNormalFloor(49,67.75,2,62.5);
    addNormalFloor(0,99,100,2);
    addNormalFloor(0,97,96,2);
    
}