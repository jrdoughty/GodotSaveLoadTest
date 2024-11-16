using Godot;
using System;

public partial class Main : Camera2D
{
	Sprite2D sprite;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		sprite = GetNode<Sprite2D>("Sprite2D");
		LoadSpriteLocation();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void LoadSpriteLocation()
	{
		GD.Print("Loading sprite location");
		GD.Print(sprite.Position);
		Vector2 pos = ResourceLoader.Load<SpritePos>("res://SpritePos.tres").Position;
		GD.Print(pos);
		// Load the sprite
		//sprite.Texture = GD.Load<Texture>("res://icon.png");
		//AddChild(sprite);

		// Set the sprite's position
		sprite.Position = pos;
	}

	public void OnButtonPressed()
	{
		sprite.Position = GetLocalMousePosition();
		GD.Print("Button pressed");
	}
	public override void _Notification(int what)
	{
		if (what == NotificationWMCloseRequest || what == NotificationApplicationPaused)
		{
			SaveSpriteLocation();
		}
	}
	public void SaveSpriteLocation()
	{
		GD.Print("Saving sprite location");
		ResourceSaver.Save(new SpritePos((int)sprite.Position.X, (int)sprite.Position.Y),"res://SpritePos.tres");
	}
}
