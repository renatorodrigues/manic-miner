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
      position = "768 660";
      Extent = "110 40";
      text = "Score:";
      Visible = "1";
   };
   
   new GuiTextCtrl(scoreValue) {
      
      HorizSizing = "relative";
      VertSizing = "relative";
      position = "878 660";
      Extent = "110 40";
      text = "0";
      Visible = "1";
   };
   
   new GuiTextCtrl(highScoreCounterTitle) {
      
      HorizSizing = "relative";
      VertSizing = "relative";
      position = "0 660";
      Extent = "220 40";
      text = "High Score:";
      Visible = "1";
   };
   
   new GuiTextCtrl(highScoreValue) {
      
      HorizSizing = "relative";
      VertSizing = "relative";
      position = "220 660";
      Extent = "110 40";
      text = "0";
      Visible = "1";
   };
   
   new GuiBitmapCtrl(life1) {
      
      HorizSizing = "relative";
      VertSizing = "relative";
      position = "0 700";
      Extent = "36 46";
      text = "0";
      Visible = "1";
      bitmap="artwork/fatguy-life.png";
   };
   new GuiBitmapCtrl(life2) {
      
      HorizSizing = "relative";
      VertSizing = "relative";
      position = "40 700";
      Extent = "36 46";
      text = "0";
      Visible = "1";
      bitmap="artwork/fatguy-life.png";
   };
   new GuiBitmapCtrl(life3) {
      
      HorizSizing = "relative";
      VertSizing = "relative";
      position = "80 700";
      Extent = "36 46";
      text = "0";
      Visible = "1";
      bitmap="artwork/fatguy-life.png";
   };
   
   
   menuGui.addGuiControl(scoreCounterTitle);
   menuGui.addGuiControl(scoreValue);
   menuGui.addGuiControl(highScoreCounterTitle);
   menuGui.addGuiControl(highScoreValue);
   menuGui.addGuiControl(life1);
   menuGui.addGuiControl(life2);
   menuGui.addGuiControl(life3);
   Canvas.pushDialog(menuGui);
   
}
