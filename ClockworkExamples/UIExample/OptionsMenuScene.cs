using Clockwork;
using Clockwork.Graphics;
using Clockwork.UI;
using System;

public class OptionsMenuScene : Scene
{
	private UIExample uiExample;
	private VerticalStackContainer rootContainer;
	private TextToggle fullscreenToggle;
	private HorizontalTextSlider volumeSlider;
	private TextButton backButton;

	public OptionsMenuScene(UIExample uiExample) : base(Colors.Gray)
	{
		this.uiExample = uiExample;
		CreateContainer();
		CreateFullscreenToggle();
		CreateVolumeSlider();
		CreateBackButton();
	}

	private void CreateContainer()
	{
		rootContainer = new VerticalStackContainer
		{
			BackgroundColor = Colors.Clear,
			PaddingTop = 50,
			PaddingBottom = 50,
			PaddingLeft = 150,
			PaddingRight = 150,
			Spacing = 25
		};

		Panel panel = AddEntity(new Panel(rootContainer, DrawContext.Game));
		panel.HorizontalAlignment = HorizontalAlignment.Center;
	}

	private void CreateFullscreenToggle()
	{
		fullscreenToggle = new("FULLSCREEN");
		fullscreenToggle.ValueChanged += uiExample.SetFullscreen;
		rootContainer.AddChild(fullscreenToggle);
	}

	private void CreateVolumeSlider()
	{
		volumeSlider = new("VOLUME (0.50)");
		volumeSlider.ValueChanged += OnVolumeSliderChanged;
		rootContainer.AddChild(volumeSlider);
	}

	private void CreateBackButton()
	{
		backButton = new("BACK");
		backButton.Released += uiExample.CloseOptions;
		rootContainer.AddChild(backButton);
	}

	private void OnVolumeSliderChanged(float value)
	{
		volumeSlider.Text = $"VOLUME ({value:F2})";
	}

	public void Dispose()
	{
		backButton.Released -= uiExample.CloseOptions;
	}
}
