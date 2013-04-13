package pt.feup.djco.manicminer.manicparser;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Locale;
import java.util.Map;

import org.dom4j.Document;
import org.dom4j.DocumentException;
import org.dom4j.DocumentHelper;
import org.dom4j.Node;
import org.dom4j.XPath;
import org.dom4j.io.SAXReader;

public class ManicParser {
	public static final String INPUT_FILE =
			"C:\\Users\\Renato\\Desktop\\miner.svg";
	public static final String OUTPUT_FILE =
			"C:\\Users\\Renato\\Dropbox\\Workspace\\DJCO\\manic-miner\\modules\\myModule\\scripts\\level.cs";	
	
	public Document parse(String path) throws DocumentException {
		File xml = new File(path);
		SAXReader reader = new SAXReader();
		Document document = reader.read(xml);
		return document;
	}
	
	private static class Rectangle {
		double x_;
		double y_;
		double width_;
		double height_;
		String fill_;
		
		@Override
		public String toString() {
			return "x: " + x_ + " y: " + y_ + " width: " + width_ + " height: " + height_;
		}
	}
	
	public Rectangle[] getRectangles(Document document) throws DocumentException {
		Map<String, String> namespace_uris = new HashMap<String, String>();
		namespace_uris.put("svg", "http://www.w3.org/2000/svg");
		
		XPath x_path = DocumentHelper.createXPath("//svg:rect");
		x_path.setNamespaceURIs(namespace_uris);
		
		List rectangles_nodes = x_path.selectNodes(document);
		Rectangle[] rectangles = new Rectangle[rectangles_nodes.size()];
		
		Iterator<Node> iterator = rectangles_nodes.iterator();
		String x, y, width, height;
		int i = 0;
		while (iterator.hasNext()) {
			Node rectangle_node = iterator.next();
			
			Rectangle rectangle = new Rectangle();
			rectangle.x_ = (x = rectangle_node.valueOf("@x")) != "" ? Double.parseDouble(x) : 0;
			rectangle.y_ = (y = rectangle_node.valueOf("@y")) != "" ? Double.parseDouble(y) : 0;
			rectangle.width_ = (width = rectangle_node.valueOf("@width")) != "" ? Double.parseDouble(width) : 2;
			rectangle.height_ = (height = rectangle_node.valueOf("@height")) != "" ? Double.parseDouble(height) : 2;
			rectangle.fill_ = rectangle_node.valueOf("@fill");
			
			rectangles[i] = rectangle;
			++i;
		}
		
		return rectangles;
	}
	
	public enum BlockType {
		NormalFloor("#FF0000"),
		ClearingFloor("#7F1200"),
		MovingFloor("#009F32"),
		Brick("#B9BF00"),
		Stalagmite("#00A6E9"),
		Bush("#07FF00"),
		End("#060074"),
		Catchable("#DF0092"),
		BadGuy("#F0FF00"),
		GravityBadGuy("#F05900"),
		Guy("#858585");
		
		private String color_;
		
		BlockType(String color) {
			color_ = color;
		}
		
		public String getColor() {
			return color_;
		}
		
		public static BlockType fromString(String color) {
			if (color != null) {
				for (BlockType bt : BlockType.values()) {
					if (color.equalsIgnoreCase(bt.color_)) {
						return bt;
					}
				}
			}
			
			return null;
		}
	}
	
	private static Map<BlockType, String> functions_ = new HashMap<BlockType, String>();
	static {
		functions_.put(BlockType.NormalFloor, "addNormalFloor");
		functions_.put(BlockType.ClearingFloor, "addClearingFloor");
		functions_.put(BlockType.MovingFloor, "addMovingFloor");
		functions_.put(BlockType.Brick, "addNormalFloor");
		functions_.put(BlockType.Stalagmite, "addStalagmite");
		functions_.put(BlockType.Bush, "addBush");
		functions_.put(BlockType.End, "addEnd");
		functions_.put(BlockType.Catchable, "addCatchable");
		functions_.put(BlockType.BadGuy, "spawnBadGuy");
		functions_.put(BlockType.GravityBadGuy, "spawnGravityBadGuy");
		functions_.put(BlockType.Guy, "createGuy");
	}
	
	public void exportRectangles(Rectangle[] rectangles) throws IOException {
		File file = new File(OUTPUT_FILE);
		FileWriter writer = new FileWriter(file);
		writer.write("function createLevel() {\n");
		String output = null;
		for (Rectangle rect : rectangles) {
			rect.x_ = (rect.x_ / 10);
			rect.y_ = (rect.y_ / 10);
			rect.width_ = (rect.width_ / 10);
			rect.height_ =  (rect.height_ / 10);
			double center_x = (rect.x_ - 50) + rect.width_ / 2.0;
			double center_y = 137 - (rect.y_ + rect.height_ / 2.0) - 40;
			output = "";
			String function = functions_.get(BlockType.fromString(rect.fill_));
			System.out.println(function);
			if (function.equals("addMovingFloor")) {
				output = String.format(Locale.US,
						"%s(%.1f, %.1f, %.1f, %.1f, 7, 1);\n", function,
						center_x, center_y, rect.width_, rect.height_);
			} else if (function.equals("addNormalFloor") || function.equals("addClearingFloor")) {
				output = String.format(Locale.US,
						"%s(%.1f, %.1f, %.1f, %.1f);\n", function, center_x,
						center_y, rect.width_, rect.height_);
			} else {
				output = String.format(Locale.US, "%s(%.1f, %.1f);\n",
						function, center_x, center_y);
			}
			
			writer.write(output);
		}
		writer.write("}");
		writer.flush();
		writer.close();
	}
	
	public static void main(String[] args) {
		ManicParser parser = new ManicParser();
		try {
			Document document = parser.parse(INPUT_FILE);
			Rectangle[] rectangles = parser.getRectangles(document);
			parser.exportRectangles(rectangles);
		} catch (DocumentException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

}
