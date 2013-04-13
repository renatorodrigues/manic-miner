function createMenu(){
	new GuiControl(menuGui) {
	   canSaveDynamicFields = "0";
	   Profile = "GuiDefaultProfile";   
	   HorizSizing = "right";
	   VertSizing = "bottom";
	   position = "0 1000";
	   Extent = "1024 768";
	   MinExtent = "8 2";
	   canSave = "1";
	   Visible = "1";
	   hovertime = "1000";
	};
 
	new GuiTextCtrl(scoreCounterTitle) {
      
      HorizSizing = "relative";
      VertSizing = "relative";
      position = "768 690";
      Extent = "110 40";
      text = "Score:";
      Visible = "1";
   };
   
    new GuiBitmapCtrl(backmenured) {
      
      HorizSizing = "relative";
      VertSizing = "relative";
      position = "0 660";
      Extent = "350 30";
      Visible = "1";
      bitmap="artwork/red.png";
   };
   
   
   new GuiControl(splashui) {
	   canSaveDynamicFields = "0";
	   Profile = "GuiDefaultProfile";   
	   HorizSizing = "right";
	   VertSizing = "bottom";
	   position = "0 0";
	   Extent = "1024 768";
	   MinExtent = "8 2";
	   canSave = "1";
	   Visible = "1";
	   hovertime = "1000";
	   isContainer=true;

	   
	    new GuiBitmapCtrl(splash) {
      
	      HorizSizing = "relative";
	      VertSizing = "relative";
	      position = "32 24";
	      Extent = "960 720";
	      Visible = "1";
	      bitmap="artwork/manic_vidal_splash copy.png";
	      isContainer=true;
	      
	    
	      	      
	      	      
	      	      
	      	 new GuiMLTextCtrl(subtitle){
	      	 	 HorizSizing = "relative";
		      VertSizing = "relative";
		      position = "960 680";
		      Extent = "20000 40";
		      Visible = "1";
		      text="DJCO 2013 #### Bruno Maia # Pedro Borges # Renato Rodrigues ### Music and soundfx from original Manic Miner for zx Spectrum by Matthew Smith";
	      	 };    
	      
	   };
	   
	   
   
	};
  
    new GuiBitmapCtrl(backmenugreen) {
      
      HorizSizing = "relative";
      VertSizing = "relative";
      position = "350 660";
      Extent = "674 30";
      Visible = "1";
      bitmap="artwork/green.png";
   };
   
   new GuiBitmapCtrl(backmenuwhite) {
      
      HorizSizing = "relative";
      VertSizing = "relative";
      position = "210 667";
      Extent = "780 15";
      maxWidth=780;
      value=780;
      Visible = "1";
      bitmap="artwork/white.png";
   };
   
   new GuiTextCtrl(fatCounterTitle) {
      
      HorizSizing = "relative";
      VertSizing = "relative";
      position = "2 655";
      Extent = "110 40";
      text = "Calories:";
      Visible = "1";                                         
   };
   
   new GuiTextCtrl(scoreValue) {
      
      HorizSizing = "relative";
      VertSizing = "relative";
      position = "920 690";
      Extent = "110 40";
      text = "0";
      Visible = "1";
   };
   
   new GuiBitmapCtrl(backmenu) {
      
      HorizSizing = "relative";
      VertSizing = "relative";
      position = "0 660";
      Extent = "1024 150";
      Visible = "1";
      bitmap="artwork/black.png";
   };
   new GuiTextCtrl(highScoreCounterTitle) {
      
      HorizSizing = "relative";
      VertSizing = "relative";
      position = "0 690";
      Extent = "220 40";
      text = "High Score:";
      Visible = "1";
   };
   
   new GuiTextCtrl(highScoreValue) {
      
      HorizSizing = "relative";
      VertSizing = "relative";
      position = "270 690";
      Extent = "110 40";
      text = "0";
      Visible = "1";
   };
   
   new GuiBitmapCtrl(life1) {
      
      HorizSizing = "relative";
      VertSizing = "relative";
      position = "0 720";
      Extent = "36 46";
      text = "0";
      Visible = "1";
      bitmap="artwork/fatguy-life.png";
   };
   new GuiBitmapCtrl(life2) {
      
      HorizSizing = "relative";
      VertSizing = "relative";
      position = "40 720";
      Extent = "36 46";
      text = "0";
      Visible = "1";
      bitmap="artwork/fatguy-life.png";
   };
   new GuiBitmapCtrl(life3) {
      
      HorizSizing = "relative";
      VertSizing = "relative";
      position = "80 720";
      Extent = "36 46";
      text = "0";
      Visible = "1";
      bitmap="artwork/fatguy-life.png";
   };
   
     new GuiTextCtrl(itemLable) {
      
      HorizSizing = "relative";
      VertSizing = "relative";
      position = "220 720";
      Extent = "190 40";
      text = "Items:  ";
      Visible = "1";
   };
   new GuiTextCtrl(itemCount) {
      
      HorizSizing = "right";
      VertSizing = "top";
      position = "360 720";
      Extent = "0 40";
      text = "0";
      Visible = "1";
   };
   
   
   

   menuGui.addGuiControl(backmenu);
   menuGui.addGuiControl(backmenured);
   menuGui.addGuiControl(backmenugreen);
   menuGui.addGuiControl(backmenuwhite);
   menuGui.addGuiControl(scoreCounterTitle);
   menuGui.addGuiControl(scoreValue);
   menuGui.addGuiControl(highScoreCounterTitle);
   menuGui.addGuiControl(highScoreValue);
   menuGui.addGuiControl(life1);
   menuGui.addGuiControl(life2);
   menuGui.addGuiControl(life3);
   menuGui.addGuiControl(itemLable);
   menuGui.addGuiControl(itemCount);
   menuGui.addGuiControl(fatCounterTitle);
   
   //menuGui.addGuiControl(splash);
 //  Canvas.pushDialog(menuGui);
  // menuGui.setVisible(false);
  // Canvas.pushDialog(splashui);
   
   
}


function showIngame(){
	GuiDefaultProfile.stopTimer();
	Canvas.BackgroundColor="black";
	Canvas.pushDialog(menuGui);
   
   Canvas.popDialog(splashui);

}


function GuiDefaultProfile::colorChange(){
	subtitle.position=myModule.xScroller SPC 680;
	if(myModule.tickSplash>getRandom(20,30)){
		myModule.tickSplash=0;
		myModule.colorB=getRandom(1,7);
		
		//black	blue	red 	magenta green	cyan yellow white
		if(myModule.colorB==0){
			Canvas.BackgroundColor="black";
		}
		
		if(myModule.colorB==1){
			Canvas.BackgroundColor="0 0 0.804 1";
			//Canvas.BackgroundColor="blue";
		}
		
		if(myModule.colorB==2){
			//Canvas.BackgroundColor="1 0 0 1";
			Canvas.BackgroundColor="red";
		}
		
		if(myModule.colorB==3){
			Canvas.BackgroundColor="0.804 0 0.047 1";
			//Canvas.BackgroundColor="magenta";
		}
		
		if(myModule.colorB==4){
			
			Canvas.BackgroundColor="0.172 1 0 1";
		}
		
		if(myModule.colorB==5){
			Canvas.BackgroundColor="0 0.804 0.804 1";
			//Canvas.BackgroundColor="cyan";
		}
		if(myModule.colorB==6){
			Canvas.BackgroundColor="0.804 0.804 0 1";
			//Canvas.BackgroundColor="yellow";
		}
		
		if(myModule.colorB==7){
			Canvas.BackgroundColor="0.804 0.804 0.804 1";
			Canvas.BackgroundColor="white";
		}
		
	}
	myModule.tickSplash++;
	myModule.xScroller=myModule.xScroller-4;
	if(myModule.xScroller<myModule.xScrollerlimit){
		myModule.xScroller=1200;
	}
	
	
	
	
}

function showSplash(){
	myModule.xScroller=1200;
	myModule.xScrollerlimit=-3500;
	GuiDefaultProfile.startTimer(colorChange,50);
	GuiDefaultProfile.colorChange();
	Canvas.popDialog(menuGui);
	Canvas.pushDialog(splashui);

}
