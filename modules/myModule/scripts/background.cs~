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
    %background.SceneGroup = 1 ;
    
    // Sets the image to use for our background
    //%background.Image = "ToyAssets:skyBackground";
    %background.BackgroundColor = "Black";
    %background.UseBackgroundColor = true;
    // Create border collisions.
    %background.createEdgeCollisionShape( -50, -25, -50, 37.5 );
    %background.createEdgeCollisionShape( 50, -25, 50, 37.5);
    %background.createEdgeCollisionShape( -50, 37.5, 50, 37.5 );
    %background.createEdgeCollisionShape( -50, -25, 50, -25 );   
   
    //%background.setDefaultRestitution(1);
    // Add the sprite to the scene.
    myScene.add( %background );   
    
    
    
         // Create the sprite.
    %background = new Sprite();
    
    // Set the sprite as "static" so it is not affected by gravity.
    %background.setBodyType( static );

    // Set the object's center to coordinates 0 0 which corresponds to the center of the Scene
    // Remember that our camera is set to point to coordinates 0 0 as well

    %background.Position = "25 25";

    // Set the object's size. Notice that this corresponds to the size of our camera, which was created in
    // scenewindow.cs. The background will thus cover the entirety of our scenewindow.
    %background.Size = "100 10";
    
    // Set to the furthest background layer.
    %background.SceneLayer = 31;
    %background.SceneGroup = 1 ;
    %background.Friction=0;
    
    // Sets the image to use for our background
    //%background.Image = "ToyAssets:skyBackground";
    %background.BackgroundColor = "blue";
    %background.UseBackgroundColor = true;
    // Create border collisions.
    %background.createEdgeCollisionShape( -50, -5, -50, 5 );
    %background.createEdgeCollisionShape( 50, -5, 50, 5);
    %background.createEdgeCollisionShape( -50, 5, 50, 5);
    %background.createEdgeCollisionShape( -50, -5, 0, -5 );  
    %background.createEdgeCollisionShape( 25, -5, 50, -5 );   
   
    //%background.setDefaultRestitution(1);
    // Add the sprite to the scene.
    myScene.add( %background );  
    
}