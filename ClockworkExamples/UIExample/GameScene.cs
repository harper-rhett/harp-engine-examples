using Clockwork;
using Clockwork.Graphics;
using Clockwork.UI;

public class GameScene : Scene
{
	private AlignmentContainer rootContainer;
	private Button cookieButton;
	private bool isHovering;

	public GameScene() : base(Colors.Tan)
	{
		CreateContainer();
		CreateCookie();
	}

	private void CreateContainer()
	{
		rootContainer = new AlignmentContainer();
		Panel panel = AddEntity(new Panel(rootContainer, DrawContext.Game));
	}

	private void CreateCookie()
	{
		cookieButton = new(Style.Invisible, Style.Invisible, Style.Invisible);
		cookieButton.Width = 256;
		cookieButton.Height = 256;
		cookieButton.HoverEntered += OnCookieHoverEntered;
		cookieButton.HoverExited += OnCookieHoverExited;
		cookieButton.Pressed += OnCookiePressed;
		cookieButton.Released += OnCookieReleased;
		cookieButton.Cancelled += OnCookieCancelled;

		TextureElement cookieElement = new("cookie.png");
		cookieButton.AddChild(cookieElement);

		rootContainer.AddChild(cookieButton);
		rootContainer.SetAlignment(
			cookieButton,
			new(HorizontalAlignment.Center, VerticalAlignment.Center)
		);
	}

	private void SetSize(int size)
	{
		cookieButton.Width = size;
		cookieButton.Height = size;
		rootContainer.ForceLayoutUpdate();
	}

	private void OnCookieHoverEntered()
	{
		isHovering = true;
		SetSize(270);
	}
	private void OnCookieHoverExited()
	{
		isHovering = false;
		SetSize(256);
	}

	private void OnCookiePressed()
	{
		SetSize(300);
	}

	private void OnCookieReleased()
	{
		if (isHovering) SetSize(270);
		else SetSize(256);
	}

	private void OnCookieCancelled()
	{
		if (isHovering) SetSize(270);
		else SetSize(256);
	}
}