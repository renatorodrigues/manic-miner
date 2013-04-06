$platformFontType = ($platform $= "windows") ? "lucida console" : "monaco";
$platformFontSize = ($platform $= "ios") ? 18 : 12;

if(!isObject(GuiDefaultProfile)) new GuiControlProfile (GuiDefaultProfile){
	 // font
    fontType = $platformFontType;
    fontSize =40;

    fontColor = "255 255 255";
    fontColorHL = "32 100 100";
    fontColorNA = "0 0 0";
    fontColorSEL= "10 10 10";
    
     // used by guiTextControl
    modal = true;
    justify = "left";
    autoSizeWidth = false;
    autoSizeHeight = false;
    returnTab = false;
    numbersOnly = false;
    cursorColor = "0 0 0 255";
    
    
};  